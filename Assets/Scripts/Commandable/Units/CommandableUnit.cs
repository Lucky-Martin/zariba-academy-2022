using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandableUnit : BaseUnit, IWorkerScript
{

    [SerializeField] protected GameObject closedPanelAtStart;
    protected string commandName = null;
    protected ResourceTypes? resourceType = null;
    protected string direction = null;

    protected Command StartCommand { get; set; }
    protected Command CurrentCommand { get; set; }

    [SerializeField] protected uint CommandLimit;
    [SerializeField] protected bool ShouldRepeatCommands = false;
    //protected bool ShouldRunCommands = true;

    public new void Start()
    {
        base.Start(); 
        if (transform.Find("Canvas-CommandPanel") != null)
        {
            transform.Find("Canvas-CommandPanel").gameObject.SetActive(false);
        }
    }

    public void setStartCommand(Command startCommand) {
        StartCommand = startCommand;
        CurrentCommand = StartCommand;
        Debug.Log("New Command Setted");
    }

    public void RunCommands() {
        ////If command execution should be stopped
        //if(!ShouldRunCommands) {
        //    return;
        //}
        //Debug.Log("After ShouldRunCommands");


        // in the start there is no command before the command is selected
        // so the should run commands is undeeded 

        // If there is no current command and we should repeat commands
        if(CurrentCommand == null) {
            //Debug.Log("Current Command is null");
            // CurrentCommand = StartCommand;
            if(ShouldRepeatCommands) {
                CurrentCommand = StartCommand;
            } 
            //else {
            //    ShouldRunCommands = false;
            //}
            return;
        }
        CurrentCommand.Execute(this);
        if(CurrentCommand.IsFinished(this)) {
            Debug.Log("Previous command was - " + CurrentCommand.Name);
            CurrentCommand = CurrentCommand.GetNextCommand(this);
            if(CurrentCommand == null) {
                Debug.Log("We have reached the end");
            }
        }
    }

    public void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0)) {
            Debug.Log("Click");
            transform.parent = null;
            if (transform.Find("Canvas-CommandPanel") != null)
            {
                transform.Find("Canvas-CommandPanel").gameObject.SetActive(true);

                // maybe we want it to sometimes be open on when giving another command to not 
                // put you in the beginning of the menu then this would not be needed
                closedPanelAtStart.SetActive(false);
            }

        }
    }

    public void SetCommandName(string name)
    {
        commandName = name;
        Debug.Log("SetCommandName: " + name);
    }

    public void SetResourceType(ResourceTypes resource)
    {
        resourceType = resource;
    }

    public void SetDirection(string direction)
    {
        this.direction = direction;
    }

    //OnSave
    public void ConstructCommand()
    {
        // in case full command hasn't been saved 
        if (commandName == null)
            return;

        Debug.Log(commandName + " Command is being constructed...");

        Vector3? directionVector = null;

        if (direction != null)
        {
            switch (direction)
            {
                case "East":
                    directionVector = new Vector3(1, 0, 0);
                    break;
                case "West":
                    directionVector = new Vector3(-1, 0, 0);
                    break;
                case "North":
                    directionVector = new Vector3(0, 0, 1);
                    break;
                case "South":
                    directionVector = new Vector3(0, 0, -1);
                    break;
            }
        }  

        if (directionVector != null)
        {
            Debug.Log("In direction " + (directionVector ?? new Vector3(0, 0, 0)));
        }


        // we have everything selected for a new resource collection command
        if (commandName == "Collect" && resourceType != null && directionVector != null)
        {
            Debug.Log("Wanted resource is " + resourceType);
            Command MoveCommandInDirection = new MoveCommand(Speed, directionVector ?? new Vector3(0, 0, 0));
            AConditionalCommand DoesSeeCommand = new SeeConditionalCommand(resourceType ?? ResourceTypes.Default);

            MoveCommandInDirection.SetNextCommand(DoesSeeCommand);
            DoesSeeCommand.SetFailureCommand(MoveCommandInDirection);

            setStartCommand(MoveCommandInDirection);
        }

    }
}

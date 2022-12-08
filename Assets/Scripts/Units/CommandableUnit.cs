using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandableUnit : BaseUnit, IWorkerScript
{
    protected Command StartCommand { get; set; }
    protected Command CurrentCommand { get; set; }

    [SerializeField] protected uint CommandLimit;
    [SerializeField] protected bool ShouldRepeatCommands = false;
    protected bool ShouldRunCommands = true;

    
    public void setStartCommand(Command startCommand) {
        StartCommand = startCommand;
        CurrentCommand = StartCommand;
    }

    public void RunCommands() {
        //If command execution should be stopped
        if(!ShouldRunCommands) {
            return;
        }

        //If there is no current command and we should repeat commands
        if(CurrentCommand == null) {
            // CurrentCommand = StartCommand;
            if(ShouldRepeatCommands) {
                CurrentCommand = StartCommand;
            } else {
                ShouldRunCommands = false;
            }
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
            GameObject panelObject = GameObject.Find("CommandPanel");
            CommandPanelScript script = panelObject.GetComponent<CommandPanelScript>();

            script.OpenPanel();
        }
    }
}

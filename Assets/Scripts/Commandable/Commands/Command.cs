using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{

    protected Command? NextCommand;
    //Only for debug purposes
    public string Name;

    public Command(string name)
    {
        Name = name; //for debug purposes
    }

    public abstract bool IsFinished(BaseUnit unit);

    public virtual void Execute(BaseUnit unit)
    {
        Debug.Log("Command \"" + Name + "\" - Game Object" + unit);
    }

    public virtual Command? GetNextCommand(BaseUnit unit)
    {
        Debug.Log("Default GetNextCommand");
        return NextCommand;
    }

    public void SetNextCommand(Command command)
    {
        NextCommand = command;
    }
}
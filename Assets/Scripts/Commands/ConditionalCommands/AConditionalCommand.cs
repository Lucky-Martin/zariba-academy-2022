using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AConditionalCommand : Command
{
    protected Command? SuccessCommand;
    protected Command? FailureCommand;

    public AConditionalCommand(string name): base(name) {}

    public abstract bool IsConditionTruthful(BaseUnit unit);

    public override Command? GetNextCommand(BaseUnit unit)
    {
        Debug.Log("Is Condition Truthful" + IsConditionTruthful(unit));
        return IsConditionTruthful(unit) ? SuccessCommand : FailureCommand;
    }

    public void SetSuccessCommand(Command newCommand) 
    {
        SuccessCommand = newCommand;
    }

    public void SetFailureCommand(Command newCommand)
    {
        FailureCommand = newCommand;
    }

    public override bool IsFinished(BaseUnit unit)
    {
        return true;
    }
}

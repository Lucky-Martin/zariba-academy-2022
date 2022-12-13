using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AConditionalCommand : Command
{
    protected Command? SuccessCommand;
    protected Command? FailureCommand;
    protected bool HasFinished = false;
    protected decimal RemainingTime = 0;
    
    public AConditionalCommand(string name): base(name)
    {
        RemainingTime = TimeBeforeFinish();
    }

    public abstract bool IsConditionTruthful(BaseUnit unit);
    public abstract decimal TimeBeforeFinish();

    public override void Execute(BaseUnit unit)
    {
        if(RemainingTime > 0) {
            unit.setAnimationState(AnimationStates.Search, true);
            RemainingTime -= (decimal)Time.deltaTime;
        } else {
            unit.setAnimationState(AnimationStates.Search, false);
            HasFinished = true;
            RemainingTime = TimeBeforeFinish();
        }
        //Debug.Log("Command \""+Name+"\" - Game Object" + unit);
    }

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
        if(HasFinished) {
            HasFinished = false;
            return true;
        }
        return false;
    }
}

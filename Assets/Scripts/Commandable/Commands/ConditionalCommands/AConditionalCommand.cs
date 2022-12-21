using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AConditionalCommand : Command
{
    protected Command? SuccessCommand;
    protected Command? FailureCommand;
    protected bool HasFinished = false;
    protected decimal RemainingTime = 0;
    protected ResourceTypes typeWanted;
    
    public AConditionalCommand(string name, ResourceTypes type): base(name)
    {
        RemainingTime = TimeBeforeFinish();
        typeWanted = type;
    }

    public abstract bool IsConditionTruthful(BaseUnit unit, ResourceTypes wantedType);
    public abstract decimal TimeBeforeFinish();

    public override void Execute(BaseUnit unit)
    {
        if(RemainingTime > 0) { //leaving this time at 0 so it doesn't attack for looking around
            unit.setAnimationState(AnimationStates.Attacking, true);
            RemainingTime -= (decimal)Time.deltaTime;
        } else {
            unit.setAnimationState(AnimationStates.Attacking, false);
            HasFinished = true;
            RemainingTime = TimeBeforeFinish();
        }
        //Debug.Log("Command \""+Name+"\" - Game Object" + unit);
    }

    public override Command? GetNextCommand(BaseUnit unit)
    {
        // do we want this somewhat heavy command going on twice
        // maybe uncomment later for debugging purposes 
        // Debug.Log("Is Condition Truthful" + IsConditionTruthful(unit, typeWanted));
        return IsConditionTruthful(unit, typeWanted) ? SuccessCommand : FailureCommand;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractResourceCommand : Command
{
    protected int resourceToughness;
    protected int workerStrength;
    protected decimal remainingTime = 0;
    protected bool hasFinished = false;

    public ExtractResourceCommand(Resource resource, BaseUnit unit) : base("ResourceExtractionCommand")
    {
        resourceToughness = resource.ResourceToughness;
        workerStrength = unit.GetStrength();
        if (workerStrength != 0)
        {
            remainingTime = (decimal)resourceToughness / (decimal)workerStrength;
        }
    }

    public override void Execute(BaseUnit unit)
    {
        if (remainingTime > 0)
        {
            //Why is the attack animation called search XD
            unit.setAnimationState(AnimationStates.CarryAttack, true);
            remainingTime -= (decimal)Time.deltaTime;
            //it's hitting just once and not more cause the animation is not repeating?
            Debug.Log("Remaining time : " + remainingTime);
        }
        else
        {
            unit.setAnimationState(AnimationStates.CarryAttack, false);
            Debug.Log("Resource Extraction Complete!");
            hasFinished = true;
        }
    }

    public override bool IsFinished(BaseUnit unit)
    {
        if (hasFinished)
        {
            hasFinished = false;
            return true;
        }
        return false;
    }
}
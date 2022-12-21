using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtractResourceCommand : Command
{
    protected int resourceToughness;
    protected int workerStrength;
    protected decimal remainingTime = 0;
    protected bool hasFinished = false;
    protected bool carryingWood;

    public ExtractResourceCommand(Resource resource, BaseUnit unit) : base("ResourceExtractionCommand")
    {
        carryingWood = false;
        resourceToughness = resource.ResourceToughness;
        if (resource.type == ResourceTypes.Wood)
        {
            carryingWood = true;
            Debug.Log("Carrying wood is true");
        }

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
            ExtractCmdSettingAnimationStates(unit, true);
            remainingTime -= (decimal)Time.deltaTime;
            //Debug.Log("Remaining time : " + remainingTime);
        }
        else
        {
            ExtractCmdSettingAnimationStates(unit, false);
            Debug.Log("Resource Extraction Complete!");
            hasFinished = true;
            carryingWood = false;
        }
    }

    public override bool IsFinished(BaseUnit unit)
    {
        if (hasFinished) {
            hasFinished = false;
            return true;
        }
        return false;
    }

    protected void ExtractCmdSettingAnimationStates(BaseUnit unit, bool offOrOn)
    {
        if (carryingWood)
        {
            unit.setAnimationState(AnimationStates.CarryWoodAttack, offOrOn);
            //Debug.Log("Setting animation to CarryWoodAttack or back - " + offOrOn);
        } else {
            unit.setAnimationState(AnimationStates.CarryBagAttack, offOrOn);
            //Debug.Log("Setting animation to CarryBagAttack or back - " + offOrOn);
        }
    }
}
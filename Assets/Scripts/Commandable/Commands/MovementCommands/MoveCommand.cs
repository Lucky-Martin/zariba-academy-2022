using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{

    //protected Vector3? startPosition;
    protected Vector3? endPosition;
    protected int Step;
    protected Vector3 Direction;
    protected bool carryingWood;
    protected bool carryingNotWood;

    public MoveCommand(int step, Vector3 direction, bool carryingWood = false, bool carryingNotWood = false) : base("MovementCommand")
    {
        Step = step;
        Direction = direction;
        this.carryingWood = carryingWood;
        this.carryingNotWood = carryingNotWood;
    }

    public override void Execute(BaseUnit unit)
    {
        //if(startPosition == null) {
        //    startPosition = unit.transform.position;
        //    endPosition = unit.transform.position + Step * (Direction);
        //    unit.setAnimationState(AnimationStates.Walk, true);
        //}

        //startPosition = unit.transform.position;

        if(endPosition == null)
        {
            endPosition = unit.transform.position + Step * (Direction);
        }

        MoveCmdSettingAnimationStates(unit, true);

        unit.transform.position = Vector3.MoveTowards(unit.transform.position, endPosition ?? Vector3.one, unit.GetSpeed() * Time.deltaTime);

        // Vector3 rotationDirection = endPosition - unit.transform.position;
        Quaternion toRotation = Quaternion.FromToRotation(unit.transform.position, endPosition ?? Vector3.one);
        //Debug.Log(toRotation);
        unit.transform.rotation = Quaternion.Lerp(unit.transform.rotation, toRotation, 2000 * Time.deltaTime);

        unit.transform.LookAt(endPosition ?? Vector3.one);
    }

    public void SetEndPosition(Vector3 endPosition)
    {
        if (endPosition != null)
        {
            this.endPosition = endPosition - new Vector3((float)-0.5, 0, 1);
        }
    }


    public override bool IsFinished(BaseUnit unit)
    {
        if(unit.transform.position != endPosition) {
            return false;
        }

        MoveCmdSettingAnimationStates(unit, false);

        //startPosition = null;
        endPosition = null;
        carryingWood = false;
        carryingNotWood = false;

        return true;
    }

    protected void MoveCmdSettingAnimationStates(BaseUnit unit, bool offOrOn)
    {
        if (carryingWood)
        {
            unit.setAnimationState(AnimationStates.CarryWood, offOrOn);
            //Debug.Log("Setting animation to CarryWood walking or back - " + offOrOn);
        }

        else if (carryingNotWood)
        {
            unit.setAnimationState(AnimationStates.CarryBag, offOrOn);
            //Debug.Log("Setting animation to CarryBag walking or back - " + offOrOn);
        }
        else
        {
            unit.setAnimationState(AnimationStates.Walk, offOrOn);
            //Debug.Log("Setting animation as normal walking or back - " + offOrOn);
        }

    }
}

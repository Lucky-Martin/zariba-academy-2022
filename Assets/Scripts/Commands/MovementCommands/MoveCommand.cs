using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{

    protected Vector3? startPosition;
    protected Vector3? endPosition;
    protected int Step;
    protected Vector3 Direction;

    public MoveCommand(int step, Vector3 direction) : base("MovementCommand")
    {
        Step = step;
        Direction = direction;
    }

    public override void Execute(BaseUnit unit)
    {
        if(startPosition == null) {
            startPosition = unit.transform.position;
            endPosition = unit.transform.position + Step * (Direction);
            unit.setAnimationState(AnimationStates.Walk, true);
        }
       
        unit.transform.position = Vector3.MoveTowards(unit.transform.position, endPosition ?? Vector3.one , unit.GetSpeed() * Time.deltaTime);

        // // Vector3 rotationDirection = endPosition - unit.transform.position;
        // Quaternion toRotation = Quaternion.FromToRotation(unit.transform.position, endPosition ?? Vector3.one);
        // Debug.Log(toRotation);
        // unit.transform.rotation = Quaternion.Lerp(unit.transform.rotation, toRotation, 2000 * Time.deltaTime);

        // unit.transform.LookAt(endPosition ?? Vector3.one);
    }

    public override bool IsFinished(BaseUnit unit)
    {
        if(unit.transform.position != endPosition) {
            return false;
        }

        unit.setAnimationState(AnimationStates.Walk, false);
        startPosition = null;
        endPosition = null;

        return true;
    }
}

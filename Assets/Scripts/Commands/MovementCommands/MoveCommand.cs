using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{

    protected Vector3? startPosition;
    protected Vector3? endPosition;
    protected int Step;

    public MoveCommand(int step) : base("MovementCommand")
    {
        Step = step;
    }

    public override void Execute(BaseUnit unit)
    {
        if(startPosition == null) {
            startPosition = unit.transform.position;
            endPosition = unit.transform.position + Step * (Vector3.forward);
        }
        
        unit.transform.position = Vector3.MoveTowards(unit.transform.position, endPosition ?? Vector3.one , unit.GetSpeed() * Time.deltaTime);
    }

    public override bool IsFinished(BaseUnit unit)
    {
        if(unit.transform.position != endPosition) {
            return false;
        }

        startPosition = null;
        endPosition = null;

        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeConditionalCommand : AConditionalCommand
{
    //Time as float
    protected decimal LookAroundTime = 2;

    public SeeConditionalCommand() : base("See command") {}

    public override bool IsConditionTruthful(BaseUnit unit)
    {
        Collider[] collidedObjects = Physics.OverlapSphere(unit.transform.position, unit.GetSightRange());
        foreach (Collider collidedObject in collidedObjects)
        {
            if(collidedObject.tag == "Resource") {
                Debug.Log("Found resource");
                return true;
            }
        }

        return false;
    }

    public override decimal TimeBeforeFinish()
    {
        return LookAroundTime;
    }
}

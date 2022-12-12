using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackConditionalCommand : AConditionalCommand
{   //Time as float
    protected decimal LookAroundTime = 2;

    public AttackConditionalCommand() : base("Attack command") { }

    public override bool IsConditionTruthful(BaseUnit unit)
    {
        Collider[] collidedObjects = Physics.OverlapSphere(unit.transform.position, unit.GetSightRange());
        foreach (Collider collidedObject in collidedObjects)
        {
            if (collidedObject.tag == "Player")
            {
                Debug.Log($"Player found at pos {collidedObject.transform.position}");
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

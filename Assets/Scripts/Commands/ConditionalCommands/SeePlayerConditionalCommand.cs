using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeePlayerConditionalCommand : AConditionalCommand
{   //Time as float
    protected decimal LookAroundTime = 2;
    [SerializeField] public float speed = 1.0f;

    public SeePlayerConditionalCommand() : base("Attack command") { }

    public override bool IsConditionTruthful(BaseUnit unit)
    {
        Collider[] collidedObjects = Physics.OverlapSphere(unit.transform.position, unit.GetSightRange());
        foreach (Collider collidedObject in collidedObjects)
        {
            if (collidedObject.tag == "Player")
            {
                //Animator animator = unit.GetComponent<Animator>();
                //Vector3 unitPosition = unit.transform.position;
                //Vector3 targetPosition = collidedObject.transform.position;
                //Debug.Log($"Player found at pos {targetPosition}");

                //animator.SetBool("Running", true);
                //var step = speed * Time.deltaTime;
                //unit.transform.position = Vector3.MoveTowards(unitPosition, targetPosition, step);

                //if (Vector3.Distance(unitPosition, targetPosition) < 0.001f)
                //{
                //    animator.SetBool("Running", false);
                //    animator.SetBool("Attacking", true);
                //}

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

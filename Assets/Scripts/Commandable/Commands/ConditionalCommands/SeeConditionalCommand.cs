using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeeConditionalCommand : AConditionalCommand
{
    //Time as float
    protected decimal LookAroundTime = 0;

    public SeeConditionalCommand(ResourceTypes typeWanted) : base("See command", typeWanted) {}

    public override bool IsConditionTruthful(BaseUnit unit, ResourceTypes wantedType)
    {
        Collider[] collidedObjects = Physics.OverlapSphere(unit.transform.position, unit.GetSightRange());
        foreach (Collider collidedObject in collidedObjects)
        {
            // The second will get checked only of the first is correct so the error that the
            // game object has no such type will not come forth
            if(collidedObject.tag == "Resource" && collidedObject.gameObject.GetComponent<Resource>().type == wantedType) 
            {
                Debug.Log("Found resource" + wantedType);

                MoveCommand goToResourceCommand = new MoveCommand(unit.GetSpeed(), collidedObject.transform.position);
                goToResourceCommand.SetEndPosition(collidedObject.transform.position);

                ExtractResourceCommand cutTree = new ExtractResourceCommand(collidedObject.gameObject.GetComponent<Resource>(), unit);
                goToResourceCommand.SetNextCommand(cutTree);

                GameObject[] barns = GameObject.FindGameObjectsWithTag("Barn");
                // maybe some sort of safety mechanism should be implemented in case not all 'barn' tagged elements have 
                // been correctly given the barn script
                int highestCapacity = 0;
                int highestCapacityIndex = 0;
                for ( int i = 0; i < barns.Length; i++)
                {
                    if (barns[i].gameObject.GetComponent<Barn>().resourceCapacityLeft > highestCapacity)
                    {
                        highestCapacity = barns[i].GetComponent<Barn>().resourceCapacityLeft;
                        highestCapacityIndex = i;
                    }
                }

                bool carryingWood = false;
                bool carryingNotWood = false;
                if (wantedType == ResourceTypes.Wood)
                    carryingWood = true;
                else
                    carryingNotWood = true;

                MoveCommand goToBarn = new MoveCommand(unit.GetSpeed(), barns[highestCapacityIndex].transform.position, carryingWood, carryingNotWood);
                goToBarn.SetEndPosition(barns[highestCapacityIndex].transform.position);
                cutTree.SetNextCommand(goToBarn);

                GameObject player = GameObject.FindWithTag("Player");
                if (player != null)
                {
                    MoveCommand goToPlayer = new MoveCommand(unit.GetSpeed(), player.transform.position);
                    goToPlayer.SetEndPosition(player.transform.position);
                    goToBarn.SetNextCommand(goToPlayer);

                }

                SetSuccessCommand(goToResourceCommand);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class AttackPlayerCommand : Command
{
    private Vector3 targetPosition;
    private bool running = false;
    private bool attacking = false;

    public AttackPlayerCommand() : base("RunCommand")
    {}

    public override void Execute(BaseUnit unit)
    {
        if (!running)
        {
            unit.setAnimationState(AnimationStates.Run, true);
            running = true;
        }
        targetPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        //Debug.Log($"Direction {Direction} Position {endPosition}");

        // Attack player
        if (Vector3.Distance(unit.transform.position, targetPosition) < 1f)
        {
            attacking = true;

            unit.setAnimationState(AnimationStates.Attack, true);
        }
        else 
        {
            attacking = false;
            // Run to player
            unit.transform.position = Vector3.MoveTowards(unit.transform.position, targetPosition, unit.GetSpeed() * Time.deltaTime);

            Vector3 direction = targetPosition - unit.transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            unit.transform.rotation = Quaternion.Lerp(unit.transform.rotation, rotation, unit.GetRotationSpeed() * Time.deltaTime);
        }
    }

    public override bool IsFinished(BaseUnit unit)
    {
        if (attacking)
        {
            unit.setAnimationState(AnimationStates.Run, false);
        }
        else
        {
            unit.setAnimationState(AnimationStates.Run, true);
        }

        return false;
    }
}

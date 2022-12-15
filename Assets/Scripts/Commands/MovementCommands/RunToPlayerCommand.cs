using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class RunToPlayerCommand : Command
{

    protected Vector3 startPosition;
    protected Vector3 endPosition;
    protected Vector3 Direction;

    private Vector3 targetPosition;
    private bool running = false;

    public RunToPlayerCommand() : base("RunCommand")
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

        unit.transform.position = Vector3.MoveTowards(unit.transform.position, targetPosition, unit.GetSpeed() * Time.deltaTime);

        Vector3 direction = targetPosition - unit.transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        unit.transform.rotation = Quaternion.Lerp(unit.transform.rotation, rotation, unit.GetRotationSpeed() * Time.deltaTime);
    }

    public override bool IsFinished(BaseUnit unit)
    {
        if (!(Vector3.Distance(unit.transform.position, targetPosition) < 1f))
        {
            return false;
        }

        unit.setAnimationState(AnimationStates.Run, false);

        return true;
    }
}

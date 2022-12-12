using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UDWorkerUnit : CommandableUnit
{
    // Start is called before the first frame update
    void Start()
    {

        base.Start();
         //Debug comand
         Command MoveCommandForward = new MoveCommand(2, Vector3.forward);
         AConditionalCommand AttackCommand = new AttackConditionalCommand();

         MoveCommandForward.SetNextCommand(AttackCommand);
         AttackCommand.SetFailureCommand(MoveCommandForward);
         AttackCommand.SetSuccessCommand(MoveCommandForward);

         setStartCommand(AttackCommand);
    }

    // Update is called once per frame
    new void Update()
    {
        RunCommands();
    }
}

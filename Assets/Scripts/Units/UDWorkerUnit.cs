using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UDWorkerUnit : CommandableUnit
{
    // Start is called before the first frame update
    // void Start()
    // {
        
    //     base.Start();
    //     // //Debug comand
    //     // Command MoveCommandForward = new MoveCommand(2, Vector3.forward);
    //     // Command MoveCommandLeft = new MoveCommand(10, Vector3.left);
    //     // AConditionalCommand DoesSeeCommand = new SeeConditionalCommand();

    //     // MoveCommandForward.SetNextCommand(DoesSeeCommand);
    //     // DoesSeeCommand.SetFailureCommand(MoveCommandForward); 
    //     // DoesSeeCommand.SetSuccessCommand(MoveCommandLeft);

    //     // setStartCommand(MoveCommandForward);
    // }

    // Update is called once per frame
    new void Update()
    {
        RunCommands();
    }
}

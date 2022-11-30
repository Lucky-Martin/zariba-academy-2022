using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UDWorkerUnit : CommandableUnit
{
    // Start is called before the first frame update
    void Start()
    {
        
        base.Start();
        Command MoveCommandForward = new MoveCommand(1, Vector3.forward);
        Command MoveCommandLeft = new MoveCommand(10, Vector3.left);
        AConditionalCommand DoesSeeCommand = new SeeConditionalCommand();

        MoveCommandForward.SetNextCommand(DoesSeeCommand);
        DoesSeeCommand.SetFailureCommand(MoveCommandForward); 
        DoesSeeCommand.SetSuccessCommand(MoveCommandLeft);

        setStartCommand(MoveCommandForward);
    }

    // Update is called once per frame
    void Update()
    {
        RunCommands();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UDWorkerUnit : CommandableUnit
{
    // Start is called before the first frame update
    void Start()
    {
        
        Animator animatorController = GetComponent<Animator>();
        animatorController.Play("UD_worker_01_idle_A");
        

        Command MoveCommand = new MoveCommand(1);
        AConditionalCommand DoesSeeCommand = new SeeConditionalCommand();
        MoveCommand.SetNextCommand(DoesSeeCommand);
        DoesSeeCommand.SetFailureCommand(MoveCommand); 

        setStartCommand(MoveCommand);
    }

    // Update is called once per frame
    void Update()
    {
        RunCommands();
    }
}

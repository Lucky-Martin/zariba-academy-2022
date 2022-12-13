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
        AConditionalCommand seePlayerCommand = new SeePlayerConditionalCommand();
        RunToPlayerCommand runToPlayerCommand = new RunToPlayerCommand();

        seePlayerCommand.SetSuccessCommand(runToPlayerCommand);

        setStartCommand(seePlayerCommand);
    }

    // Update is called once per frame
    void Update()
    {
        RunCommands();
    }
}

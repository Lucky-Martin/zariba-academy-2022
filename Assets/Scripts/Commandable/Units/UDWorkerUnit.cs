using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UDWorkerUnit : CommandableUnit
{
    // Start is called before the first frame update
    new void Start()
    {

        base.Start();
        
        //Command MoveCommandForward = new MoveCommand(2, Vector3.forward);
        //Command MoveCommandLeft = new MoveCommand(10, Vector3.left);
        //AConditionalCommand DoesSeeCommand = new SeeConditionalCommand();

        //MoveCommandForward.SetNextCommand(DoesSeeCommand);
        //DoesSeeCommand.SetFailureCommand(MoveCommandForward);

        //DoesSeeCommand.SetSuccessCommand(MoveCommandLeft);
        //I think the success command should be put inside the SeeConditionalCommand
        //Once the unit sees the object they found and want to go to

        //setStartCommand(MoveCommandForward);
    }

    // Update is called once per frame
    new void Update()
    {
        RunCommands();
    }

    public void CollectWoodAndReturn(Vector3 direction) { }
    public void CollectSunflowerAndReturn(Vector3 direction) { }
    public void CollectOreAndReturn(Vector3 direction) { }
    public void BuildNewBarn(Vector3 Position) { } //
    // the build command can be on the barn. That way it will also show as information what resources we want/need more

}

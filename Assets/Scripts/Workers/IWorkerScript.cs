using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWorkerScript
{
    void setStartCommand(Command startCommand);
    void RunCommands();
}

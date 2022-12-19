using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : ABaseStatsScript
{
    public override void HandleEvent(Component sender, object data)
    {
        Debug.Log("Handle");
        Debug.Log(data);
        Debug.Log(data is float);
        if(data is float) {
            triggerValueIncrease((float) data);
        }
    }
}

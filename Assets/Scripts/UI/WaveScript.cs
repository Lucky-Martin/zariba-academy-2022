using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : ABaseStatsScript
{
    public override void HandleEvent(Component sender, object data)
    {
        Debug.Log("WaveScript");
        if(data is float) {
            triggerValueIncrease(-1 * (FinalValue - (float) data));
        }
    }
}

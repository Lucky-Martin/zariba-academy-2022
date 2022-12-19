using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceScript : ABaseStatsScript
{
    public override void HandleEvent(Component sender, object data)
    {
        if(data is float) {
            triggerValueIncrease((float) data);
        }
    }
}

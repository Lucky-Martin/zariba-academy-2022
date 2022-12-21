using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseDead : ASkill
{


    public GameObject raiseDeadVFX;
    public GameObject commandableUndeadPrefab;

    [Range(1, 10)]
    public float animationTimes = 2f;

    [Range(1,100)]
    public int maximumLevel = 5;
    [Range(1,100)]
    public int perLevelUpCost = 10;

    [Range(0,100)]
    public float perLevelCooldownReduction = 1;

    [Range(1,100)]
    public float cooldownTime = 10f;
    private float nextAvailableTime = 0f;

    public override string getSkillName() {
        return "Raise Dead";
    }

    public override SkillType getSkillType()
    {
        return SkillType.RaiseDead;
    }

    public override int getLevelUpSkillCost() {
        return (currentLevel + 1) * 40;
    }
    
    public override int getMaximumSkillLevel()
    {
        return maximumLevel;
    }

    public override string getToolTip() {
        return "Raised an undead minion to serve you.";
    }

    public float getCooldownTime()
    {
        return cooldownTime - (currentLevel * perLevelCooldownReduction);
    }

     public override void castSkill(GameObject caster)
    {
        //13:42
        //14:01
        
        if(Time.time < nextAvailableTime) {
            return;
        }
        nextAvailableTime = Time.time + getCooldownTime();

        // Debug.Log("Raise Dead");

        handleVFX(caster);
        if(commandableUndeadPrefab) {
            Instantiate(
                commandableUndeadPrefab,
                caster.transform.forward,
                Quaternion.Inverse(caster.transform.rotation)
            );
        }
    }

    public void handleVFX(GameObject caster)
    {
        GameObject thunderClapEffect = Instantiate(
            raiseDeadVFX,
            (
                caster.transform.forward
            ),
            Random.rotation
        );
 
        // thunderClapEffect.transform.localScale;
        Destroy(thunderClapEffect, animationTimes);
    }
}

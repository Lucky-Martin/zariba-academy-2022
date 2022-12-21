using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderclapSkill : ASkill
{
    public GameObject ThunderClapVFX;
    [Range(1,20)]
    public float ThunderClapVFXTime = 3;
    public Vector3 ThunderClapScale = new Vector3(0.40f, 0.40f, 0.40f);
    
    [Range(1,100)]
    public int maximumLevel = 5;
    [Range(1,100)]
    public int perLevelUpCost = 10;

    [Range(0,100)]
    public float perLevelCooldownReduction = 1;

    [Range(1,100)]
    public float cooldownTime = 10f;
    private float nextAvailableTime = 0f;

    public void Start()
    {

    }
    public override string getSkillName() {
        return "Thunderclap";
    }

    public override SkillType getSkillType()
    {
        return SkillType.Thunderclap;
    }

    public override int getLevelUpSkillCost() {
        return (currentLevel + 1) * perLevelUpCost;
    }
    
    public override int getMaximumSkillLevel()
    {
        return maximumLevel;
    }

    public override string getToolTip() {
        return "Strikes the earth around with Lightning";
    }

    public float getCooldownTime()
    {
        return cooldownTime - (currentLevel * perLevelCooldownReduction);
    }


    public override void castSkill(GameObject caster)
    {
        
        if(Time.time < nextAvailableTime) {
            return;
        }
        nextAvailableTime = Time.time + getCooldownTime();


        handleEffects(caster);
    }

    protected void handleEffects(GameObject caster) 
    {    
        GameObject thunderClapEffect = Instantiate(
            ThunderClapVFX,
            (
                caster.transform.position
            ),
            new Quaternion(
                Random.Range(0, 360),
                0,
                Random.Range(0, 360),
                1
            )
        );
 
        thunderClapEffect.transform.localScale += currentLevel * ThunderClapScale;
        Destroy(thunderClapEffect, ThunderClapVFXTime);
    }
}

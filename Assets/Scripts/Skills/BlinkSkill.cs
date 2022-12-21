using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkSkill : ASkill
{
    public int baseMoveDistance = 10;
    public GameObject oldPositionVFX;
    public GameObject newPositionVFX;
    
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
        return "Blink";
    }

    public override SkillType getSkillType()
    {
        return SkillType.Blink;
    }

    public override int getLevelUpSkillCost() {
        return currentLevel * 10;
    }
    
    public override int getMaximumSkillLevel()
    {
        return maximumLevel;
    }

    public override string getToolTip() {
        return "Moves a short distance";
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

        instantiateAnimation(caster, oldPositionVFX);
        caster.transform.position += caster.transform.forward * baseMoveDistance;
        instantiateAnimation(caster, newPositionVFX);
    }

    public void instantiateAnimation(GameObject caster, GameObject animation)
    {
        if(animation) {
            GameObject instantiatedAnimation = Instantiate(
                    animation, 
                    caster.transform.position, 
                    caster.transform.rotation
                );
            
            instantiatedAnimation.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            Destroy( instantiatedAnimation, animationTimes );
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{

    [SerializeField] protected int CurrentHP;
    [SerializeField] protected int Speed;
    [SerializeField] protected int RotationSpeed;
    [SerializeField] protected int SightRange;
    [SerializeField] protected int AttackRange;
    [SerializeField] protected int MaxHP;

    protected Animator animatorController;
    // Start is called before the first frame update
    public void Start()
    {
        animatorController = GetComponent<Animator>();

    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public int GetSpeed()
    {
        return Speed;
    }

    public int GetSightRange()
    {
        return SightRange;
    }

    public int GetRotationSpeed()
    {
        return RotationSpeed;
    }

    public void startSearching()
    {

    }

    public void toggleAnimatorBool(string boolName)
    {
        bool boolValue = animatorController.GetBool(boolName);
        animatorController.SetBool(boolName, !boolValue);
    }

    public void setAnimationState(AnimationStates state, bool value)
    {
        switch(state) {
            case AnimationStates.Walk:
                animatorController.SetBool("Walking", value);
            break;
            case AnimationStates.Search:
                animatorController.SetBool("Searching", value);
            break;
            case AnimationStates.Run:
                animatorController.SetBool("Running", value);
            break;
            case AnimationStates.Attack:
                animatorController.SetTrigger("Attack");
            break;
        }
    }

    // public void startSearching()
    // {
    //     animatorController.toggleAnimatorBool("IsSearching");
    // }

    // public void stopSearching();

    public void startMoving()
    {
        // Debug.Log(animatorController);
        // Debug.Log(animatorController.GetBool("IsMoving"));
        // if( animatorController.GetBool("IsMoving") ) {
        //     return;
        // }
        // animatorController.SetBool("IsMoving", true);
    }
    
    public void stopMoving() 
    {
        // if( !animatorController.GetBool("IsMoving") ) {
        //     return;
        // }
        // animatorController.SetBool("IsMoving", false);
    }

}

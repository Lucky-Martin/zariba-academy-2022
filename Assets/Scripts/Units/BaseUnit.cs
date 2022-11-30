using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{

    [SerializeField] protected int CurrentHP;
    [SerializeField] protected int Speed;
    [SerializeField] protected int SightRange;
    [SerializeField] protected int AttackRange;
    [SerializeField] protected int MaxHP;

    protected Animator animatorController;
    // Start is called before the first frame update
    public void Start()
    {
        animatorController = GetComponent<Animator>();
        Debug.Log("AAAAAAAAAAAAAAA!", animatorController);

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

    public void startMoving()
    {
        Debug.Log(animatorController);
        Debug.Log(animatorController.GetBool("IsMoving"));
        if( animatorController.GetBool("IsMoving") ) {
            return;
        }
        animatorController.SetBool("IsMoving", true);
    }
    
    public void stopMoving() 
    {
        if( !animatorController.GetBool("IsMoving") ) {
            return;
        }
        animatorController.SetBool("IsMoving", false);
    }

}

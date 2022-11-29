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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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


}

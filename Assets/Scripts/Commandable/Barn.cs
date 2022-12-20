using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barn : MonoBehaviour
{
    public int resourceCapacity = 40;
    public int resourceCapacityLeft = 40;
    public int minionCapacity = 5; // is the amount of units we can have is tied to the amount and quality of barns
    // Start is called before the first frame update
    [SerializeField] protected int currentHP; // if they can be attacked
    [SerializeField] protected int minionCapacityLeft = 40; // possibly there should be a main barn that keeps count off in all

    [SerializeField] protected uint availableWood;
    [SerializeField] protected uint availableOre;
    [SerializeField] protected uint availableSunflower;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddResource(Resource toAdd)
    {
        if (resourceCapacityLeft < toAdd.Amount)
            return;

        switch(toAdd.type)
        {
            case ResourceTypes.Wood:
                availableWood += toAdd.Amount;
                break;
            case ResourceTypes.Ore:
                availableOre += toAdd.Amount;
                break;
            case ResourceTypes.Sunflower:
                availableSunflower += toAdd.Amount;
                break;
        }
    }
}

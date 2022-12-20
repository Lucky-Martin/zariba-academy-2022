using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public ResourceTypes type;
    public bool IsGatherable;
    public uint Amount;
    public int ResourceToughness;


    public void Update()
    {
        // TODO:
        // destroying the resource when the amount and toughness gets to 0
    }
}



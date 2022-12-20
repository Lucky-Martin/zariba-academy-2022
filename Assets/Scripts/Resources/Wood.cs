using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Resource
{

    public Wood()
    {
        type = ResourceTypes.Wood;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        // TODO:
        // if the wood is cut down, but not all of it is carried away 
        // change prefab to the cut logs
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRecourseGathering : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] collidedObjects = Physics.OverlapSphere(transform.position, 20);
        foreach (Collider collidedObject in collidedObjects)
        {
            if (collidedObject.tag == "Resource")
            {
                Debug.Log("Found resource");
                return;
            }
        }
    }
}

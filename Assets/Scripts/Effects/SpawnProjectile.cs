using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void Update()
    {
        if(Input.GetMouseButton(0)) {
            SpawnVFX();
        }
    }

    public void SpawnVFX()
    {
        // GameObject vfx;

        // if(firePoint == null) {
        //     Debug.Log("No fire point");
        //     return;
        // }

        
    }
}

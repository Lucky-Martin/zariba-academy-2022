using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProjectileSpeed : MonoBehaviour
{

    public float speed = 10;
    public List<Action<GameObject, Collision>> collisionHandlers = new List<Action<GameObject, Collision>>(); 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddCollisionHandler(Action<GameObject, Collision> handler) {
        collisionHandlers.Add(handler);
    }

    // Update is called once per frame
    void Update()
    {
        if(speed != 0 ) {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        speed = 0;
        Debug.Log("Collided with" + collision.gameObject.name);

        foreach(Action<GameObject,Collision> action in collisionHandlers) {
            action.Invoke(transform.gameObject, collision);
        }

        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCameraView : MonoBehaviour
{
    [SerializeField] public Vector3 viewingAngle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        Camera.main.transform.rotation = Quaternion.Euler(viewingAngle.x, viewingAngle.y, viewingAngle.z);
    }
}

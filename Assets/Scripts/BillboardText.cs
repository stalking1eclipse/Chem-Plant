using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardText : MonoBehaviour
{
    Vector3 rotationLook;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotationLook = transform.position - Camera.main.transform.position;
        rotationLook.y = 0;
        transform.rotation = Quaternion.LookRotation(rotationLook);

    }
}

using UnityEngine;

public class BillboardText : MonoBehaviour
{
    Vector3 rotationLook;
    // Update is called once per frame
    void Update()
    {
        rotationLook = transform.position - Camera.main.transform.position;
        rotationLook.y = 0; 
        transform.rotation = Quaternion.LookRotation(rotationLook);

    }
}

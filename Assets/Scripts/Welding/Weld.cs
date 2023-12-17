using UnityEngine;

public class Weld : MonoBehaviour
{
    [SerializeField]
    LayerMask layer_mask;
    RaycastHit hit;

    [SerializeField]
    GameObject weldBuldge;
    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, -transform.forward, out hit, 15f, layer_mask))
        {
            Instantiate(weldBuldge, hit.point, Quaternion.LookRotation(hit.normal));
        }
        
        Debug.DrawRay(transform.position, -transform.forward, Color.green);        
    }
}

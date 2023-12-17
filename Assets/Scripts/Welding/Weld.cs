using UnityEngine;

public class Weld : MonoBehaviour
{
    [SerializeField]
    LayerMask layer_mask;
    Ray ray;
    RaycastHit hit;
    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(transform.position, -transform.forward, out hit, 15f, layer_mask);
        
        Debug.DrawRay(transform.position, -transform.forward, Color.green);
        
    }
}

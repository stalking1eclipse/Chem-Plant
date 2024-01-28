using UnityEngine;

public class RotatePipes : MonoBehaviour
{
    [SerializeField] private WeldingManagement WeldingManagement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PositiveRotation()
    {
        if (WeldingManagement.IsConnectorEnabled)
            gameObject.transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z + 45f);
    }

    public void NegativeRotation()
    {
        if (WeldingManagement.IsConnectorEnabled)
            gameObject.transform.Rotate(transform.rotation.x, transform.rotation.y, transform.rotation.z - 45f);
    }
}

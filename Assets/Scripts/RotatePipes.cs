using UnityEngine;
using UnityEngine.InputSystem;

public class RotatePipes : MonoBehaviour
{
    [SerializeField] 
    private WeldingManagement WeldingManagement; 
    
    [SerializeField]
    InputActionProperty rightActivate;

    [SerializeField]
    private Vector3 rotationVector;

    // Update is called once per frame
    void Update()
    {
        PositiveRotation();
    }

    public void PositiveRotation()
    {
        if (WeldingManagement.IsConnectorEnabled && rightActivate.action.ReadValue<float>() > 0.1f)
            gameObject.transform.Rotate(rotationVector * Time.deltaTime);
    }

    public void NegativeRotation()
    {
        if (WeldingManagement.IsConnectorEnabled && rightActivate.action.ReadValue<float>() > 0.1f)
            gameObject.transform.Rotate(-rotationVector * Time.deltaTime);
    }
}

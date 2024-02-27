using UnityEngine;
using UnityEngine.InputSystem;

public class RotatePipes : MonoBehaviour
{
    [SerializeField] 
    private WeldingManagement WeldingManagement; 
    
    [SerializeField]
    InputActionProperty rightActivate, leftActivate;

    [SerializeField]
    private Vector3 rotationVector;

    bool rotatePositively = false
        , rotateNegatively = false;

    // Update is called once per frame
    void Update()
    {
        PositiveRotation();
        if (rotatePositively)
        {
            if (rotateNegatively)
                rotateNegatively = !rotateNegatively;
            
            PositiveRotation();
        }
        else if (rotateNegatively)
        {
            if (rotatePositively)
                rotatePositively = !rotatePositively;

            NegativeRotation();
        }        
    }

    private void PositiveRotation()
    { 
        Debug.Log("Positive Rotation");
        gameObject.transform.Rotate(rotationVector * Time.deltaTime);
    }

    private void NegativeRotation()
    {
        Debug.Log("Negative Rotation");
        gameObject.transform.Rotate(-rotationVector * Time.deltaTime);
    }

    public void RotatePositive()
    {
        rotatePositively = true;
    }

    public void RotateNegative()
    {
        rotateNegatively = true;
    }

    public void PauseRotation()
    {
        rotatePositively = false;
        rotateNegatively = false;
    }
}

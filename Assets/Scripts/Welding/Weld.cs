using UnityEngine;
using UnityEngine.InputSystem;

public class Weld : MonoBehaviour
{
    [SerializeField]
    LayerMask layer_mask;
    RaycastHit hit;

    [SerializeField]
    ParticleSystem BlowTorch;

    [SerializeField]
    GameObject weldBuldge;

    [SerializeField]
    WeldingManagement weldingManagement;

    [SerializeField]
    InputActionProperty rightActivate;

    [SerializeField]
    float flameLength = 10f;

    bool IsTorchGrasped;

    // Update is called once per frame
    void Update()
    {
        if ((rightActivate.action.ReadValue<float>() > 0.1f && IsTorchGrasped) || transform.name == "Test Torch")
        {
            if (!BlowTorch.gameObject.activeSelf)
            {
                BlowTorch.gameObject.SetActive(true);
            }

            if (Physics.Raycast(transform.position, -transform.forward, out hit, flameLength, layer_mask))
            {
                if (BlowTorch.CompareTag("Sparks Particle"))
                    BlowTorch.Play();

                GameObject buldgeObject = Instantiate(weldBuldge, hit.point, Quaternion.LookRotation(hit.normal));
                buldgeObject.transform.parent = weldingManagement.Connector.transform;
            }
            
            if (BlowTorch.CompareTag("Flame Particle"))
                BlowTorch.Play();
        }
        else
        {
            BlowTorch.Stop();
        }

        Debug.DrawRay(transform.position, -transform.forward, Color.green);        
    }

    public void GraspTorch()
    {
        IsTorchGrasped = true;
    }

    public void ReleaseTorch()
    {
        IsTorchGrasped = false;
    }
}

using System.Collections;
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
        //if (weldingManagement.IsFullyTacked() && !weldingManagement.IsFullyWelded())
        //{
        //    weldingManagement.Connector.SetActive(true);
        //}

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


                if (weldingManagement.Connector.activeSelf)
                {
                    if (!weldingManagement.IsFullyWelded())
                    {
                        //
                        hit.transform.TryGetComponent(out MeshRenderer renderer);

                        if (hit.transform != null && renderer.enabled == false)
                        {
                            hit.transform.TryGetComponent(out WeldPoint weldPoint);
                            Debug.Log("Hit some weld point");
                            if (weldPoint != null)
                            {
                                weldPoint.UpdateWeldPointOccupation(true);
                                weldPoint.UpdateTackPointOccupation(true);
                            }
                                
                        }
                            
                        if (renderer != null)
                            if (!renderer.enabled)
                                renderer.enabled = true;
                    }
                }
                else if (weldingManagement.TackConnector.activeSelf)
                {
                    if (!weldingManagement.IsFullyTacked())
                    {
                        
                        hit.transform.TryGetComponent(out MeshRenderer renderer);
                        WeldPoint weldPoint = hit.transform.GetComponent<WeldPoint>();
                        weldPoint.UpdateTackPointOccupation(true);

                        if (renderer != null)
                            if (!renderer.enabled)
                                renderer.enabled = true;
                    }                    
                }
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
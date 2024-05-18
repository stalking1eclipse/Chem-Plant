using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class WeldingManagement : MonoBehaviour
{
    [Header("Placement Objects")]
    [SerializeField]
    private SetPlateInPlace MainWeldingPlacementArea;
    [SerializeField]
    private SetPlateInPlace LeftComponent;
    [SerializeField]
    private SetPlateInPlace RightComponent;
    [SerializeField]
    private SetPlateInPlace TackComponentLeft;
    [SerializeField]
    private SetPlateInPlace TackComponentRight;

    [Header("Connectors")]
    public GameObject Connector;
    public GameObject TackConnector;

    [Header("Lists")]
    [SerializeField]
    List<GameObject> WeldPoints;
    [SerializeField]
    List<GameObject> TackPoints;
    [SerializeField]
    List<GameObject> TackedObjects;
    
    [Header("Components")]
    [SerializeField]
    private GameObject WeldedComponent;
    [SerializeField]
    private GameObject TackedComponent;
    [SerializeField]
    private GameObject RotationInputs;
        
    private bool IsConnectorEnabled = false, FullyWelded = false, FullyTacked = false;

    // Update is called once per frame
    void Update()
    {
        MonitorConnectorState();

        if (IsConnectorEnabled)
        {
            if (RotationInputs != null && !RotationInputs.activeSelf)
            {
                RotationInputs.SetActive(true);
            }
        }

        if (FullyWelded)
        {
            destroyTempWeldBuldges();
            Connector.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        int index = WeldPoints.ToArray().Length;
        int tackIndex = TackPoints.ToArray().Length;
        int i = 0, ti = 0;

        foreach(GameObject weldPoint in WeldPoints)
        {
            if (weldPoint != null && !FullyWelded)
            {
                if (!weldPoint.GetComponent<WeldPoint>().getPointState())
                {
                    FullyWelded = false;
                    break;
                }
                else
                {
                    i++;
                }
            }            
        }

        foreach(GameObject tackPoint in TackPoints)
        {
            if (tackPoint != null && !FullyTacked)
            {
                if (!tackPoint.GetComponent<WeldPoint>().getPointState())
                {
                    FullyTacked = false;
                    break;
                }
                else
                {
                    ti++;
                }
            }
        }

        if (i == index)
            FullyWelded = true;

        if (ti == tackIndex)
        {
            FullyTacked = true;
            if (TackedComponent != null)
            {
                if (TackedComponent.GetComponent<MeshRenderer>().enabled)
                    TackedComponent.GetComponent<MeshRenderer>().enabled = false;
                if (TackedComponent.TryGetComponent(out Rigidbody rb))
                {
                    if (rb != null)
                    {
                        if (!rb.isKinematic)
                            rb.isKinematic = true;
                        else
                            rb.isKinematic = false;

                        if (!rb.useGravity)
                            rb.useGravity = true;
                    }
                }
                foreach (GameObject tackedObject in TackedObjects)
                {
                    tackedObject.transform.parent = TackedComponent.transform;
                    tackedObject.gameObject.GetComponent<Collider>().enabled = false;
                }
            }           
        }

        if (WeldedComponent != null)
            WeldedComponent.SetActive(FullyWelded);

        if (TackedComponent != null)
            TackedComponent.SetActive(FullyTacked);
    }

    public bool IsFullyWelded()
    {
        return FullyWelded;
    }

    public bool IsFullyTacked()
    {
        return FullyTacked;
    }

    private void MonitorConnectorState()
    {

                 
        if (MainWeldingPlacementArea == null)
        {
            if (LeftComponent.getSpaceState() && RightComponent.getSpaceState())
            {
                IsConnectorEnabled = true;
            }
            else
            {
                IsConnectorEnabled = false;
            }
        }
        else if (MainWeldingPlacementArea != null)
        {
            if (MainWeldingPlacementArea.getSpaceState())
                IsConnectorEnabled = true;
            else
                IsConnectorEnabled = false;
        }
        Connector.SetActive(IsConnectorEnabled);
    }

    private void destroyTempWeldBuldges()
    {
        GameObject[] WeldedBuldges = GameObject.FindGameObjectsWithTag("Welded Buldge");

        foreach(GameObject WeldedBuldge in WeldedBuldges)
        {
            if (WeldedBuldge.transform.parent == Connector)
                Destroy(WeldedBuldge);
        }
    }
}

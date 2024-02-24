using System.Collections.Generic;
using UnityEngine;

public class WeldingManagement : MonoBehaviour
{
    [SerializeField]
    private SetPlateInPlace LeftComponent, RightComponent;
    public GameObject Connector;
    [SerializeField]
    List<GameObject> WeldPoints;
    [SerializeField]
    private GameObject WeldedComponent;
    [SerializeField]
    private GameObject RotationInputs;
        
    public bool IsConnectorEnabled = false, FullyWelded = false;

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

        WeldedComponent.SetActive(FullyWelded);
        if (FullyWelded)
        {
            destroyTempWeldBuldges();
            Connector.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        foreach(GameObject weldPoint in WeldPoints)
        {
            if (weldPoint != null && !FullyWelded)
            {
                WeldPoint _welpoint = weldPoint.GetComponent<WeldPoint>();
                if (!_welpoint.getPointState())
                {
                    FullyWelded = false;
                    break;
                }
                else
                {
                    FullyWelded = true;
                }
            }
        }
    }

    public bool IsFullyWelded()
    {
        return FullyWelded;
    }

    private void MonitorConnectorState()
    {
                 
        if (LeftComponent.getSpaceState() && RightComponent.getSpaceState())
        {
            IsConnectorEnabled = true;
        }
        else
        {
            IsConnectorEnabled = false;
        }
        Connector.SetActive(IsConnectorEnabled);
    }

    private void destroyTempWeldBuldges()
    {
        GameObject[] WeldedBuldges = GameObject.FindGameObjectsWithTag("Welded Buldge");

        foreach(GameObject WeldedBuldge in WeldedBuldges)
        {
            Destroy(WeldedBuldge);
        }
    }
}

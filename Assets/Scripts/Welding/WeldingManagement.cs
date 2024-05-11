using System.Collections.Generic;
using UnityEngine;

public class WeldingManagement : MonoBehaviour
{
    [SerializeField]
    private SetPlateInPlace LeftComponent, RightComponent, TackComponent;
    public GameObject Connector;
    [SerializeField]
    List<GameObject> WeldPoints, TackPoints;
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

        if (FullyWelded)
        {
            destroyTempWeldBuldges();
            Connector.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        int index = WeldPoints.ToArray().Length;
        int i = 0;

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

        if (i == index)
            FullyWelded=true;
            WeldedComponent.SetActive(FullyWelded);
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
            if (WeldedBuldge.transform.parent == Connector)
                Destroy(WeldedBuldge);
        }
    }
}

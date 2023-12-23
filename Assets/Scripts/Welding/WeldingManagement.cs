using System.Collections.Generic;
using UnityEngine;

public class WeldingManagement : MonoBehaviour
{
    [SerializeField]
    private SetPlateInPlace LeftPlate, RightPlate;
    [SerializeField]
    private GameObject Connector;
    [SerializeField]
    List<GameObject> WeldPoints;
    [SerializeField]
    private GameObject WeldedPlates;
        
    private bool IsConnectorEnabled = false, FullyWelded = false;

    // Update is called once per frame
    void Update()
    {
        MonitorConnectorState();

        //Debug.Log("Fully Welded: " + FullyWelded);

        WeldedPlates.SetActive(FullyWelded);
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
            if (weldPoint != null)
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
                 
        if (LeftPlate.getSpaceState() && RightPlate.getSpaceState())
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

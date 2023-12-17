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
        
    private bool IsConnectorEnabled = false, FullyWelded = false;

    // Update is called once per frame
    void Update()
    {
        MonitorConnectorState();

        Debug.Log("Fully Welded: " + FullyWelded);

        if (FullyWelded)
        {
            LeftPlate.transform.parent = gameObject.transform;
            RightPlate.transform.parent = gameObject.transform;
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


    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == LeftPlate.tag)
    //    {
    //        other.gameObject.transform.parent = LeftPlate.transform;
    //    }
        
    //    if (other.tag == RightPlate.tag)
    //    {
    //        other.gameObject.transform.parent = RightPlate.transform;
    //    }
    //}


    private void MonitorConnectorState()
    {
        if (!IsConnectorEnabled)
        {
            if (LeftPlate != null && RightPlate != null)
            {
                if (LeftPlate.getSpaceState() && RightPlate.getSpaceState())
                {
                    IsConnectorEnabled = true;
                }
                else
                {
                    IsConnectorEnabled = false;
                }
            }
        }
        Connector.SetActive(IsConnectorEnabled);
    }
}

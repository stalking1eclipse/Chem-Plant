using UnityEngine;

public class WeldingManagement : MonoBehaviour
{
    [SerializeField]
    private SetPlateInPlace LeftPlate, RightPlate;

    [SerializeField]
    private GameObject Connector;

    private bool IsConnectorEnabled = true;

    // Update is called once per frame
    void Update()
    {
        MonitorConnectorState();
    }

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
            }            
        }
        Connector.SetActive(IsConnectorEnabled);
    }
}

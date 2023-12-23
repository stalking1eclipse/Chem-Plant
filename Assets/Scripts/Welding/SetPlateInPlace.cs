using UnityEngine;

public class SetPlateInPlace : MonoBehaviour
{
    private bool IsSpaceOccupied { set; get; }
    [SerializeField]
    private WeldingManagement weldingManagement;

    private void Start()
    {
        IsSpaceOccupied = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other != null && other.transform.tag == transform.tag)
        {
            other.transform.rotation = transform.rotation;
            other.transform.position = transform.position;

            gameObject.GetComponent<MeshRenderer>().enabled = false;
            IsSpaceOccupied = true;

            if (weldingManagement.IsFullyWelded())
            {
                Destroy(other.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.transform.tag == transform.tag)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            IsSpaceOccupied = false;
        }
    }

    public bool getSpaceState()
    {
        return IsSpaceOccupied;
    }
}

using UnityEngine;

public class SetPlateInPlace : MonoBehaviour
{
    private bool IsSpaceOccupied { set; get; }

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
            IsSpaceOccupied = true;
        }
        Debug.Log(other.name);
    }

    public bool getSpaceState()
    {
        return IsSpaceOccupied;
    }
}

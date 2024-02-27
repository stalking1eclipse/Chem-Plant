using UnityEngine;

public class SetPlateInPlace : MonoBehaviour
{
    private bool IsSpaceOccupied { set; get; }
    [SerializeField]
    private WeldingManagement weldingManagement;
    [SerializeField]
    private Transform head;
    [SerializeField]
    private float spawnDistance = 2;
    [SerializeField]
    private GameObject menu;

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
                        
            if (menu.activeSelf && IsSpaceOccupied)
            {
                menu.SetActive(!menu.activeSelf);
            }

            if (weldingManagement.IsFullyWelded())
            {
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
        else if (other != null && other.transform.tag != transform.tag && !IsSpaceOccupied)
        {
            Debug.Log("Incorrect object placement");

            if (!menu.activeSelf)
            {
                menu.SetActive(true);
            }

            menu.transform.position = head.position + new Vector3(head.forward.x, 0f, head.forward.z).normalized * spawnDistance;

            menu.transform.LookAt(new Vector3(head.position.x, head.position.y, head.position.z));
            menu.transform.forward *= -1;
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

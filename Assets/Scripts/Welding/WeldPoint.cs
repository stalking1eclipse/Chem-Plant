using UnityEngine;

public class WeldPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject TagReference;

    private bool IsPointOccupied { set; get; }
    

    private void OnTriggerStay(Collider other)
    {
        if (TagReference.tag == other.tag) 
        { 
            IsPointOccupied = true;
        }
    }

    public bool getPointState()
    {
        return IsPointOccupied;
    }
}

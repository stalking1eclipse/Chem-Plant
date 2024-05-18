using UnityEngine;

public class WeldPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject TagReference;

    private bool IsWeldPointOccupied { set; get; } = false;
    private bool IsTackPointOccupied { set; get; } = false;
    

    private void OnTriggerStay(Collider other)
    {
        if (TagReference.tag == other.tag) 
        {
            IsWeldPointOccupied = true;
        }
    }

    private void Update()
    {
        GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.black, 2f * Time.deltaTime);
    }

    public bool GetPointState()
    {
        return IsWeldPointOccupied;
    }

    public bool GetTackPointState()
    {
        return IsTackPointOccupied;
    }

    public void UpdateTackPointOccupation(bool updateTack)
    {
        IsTackPointOccupied = updateTack;
    }

    public void UpdateWeldPointOccupation(bool updateTack)
    {
        IsWeldPointOccupied = updateTack;
    }
}

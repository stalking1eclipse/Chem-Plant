using UnityEngine;

public class WeldPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject TagReference;

    private bool IsWeldPointOccupied { set; get; } = false;
    private bool IsTackPointOccupied { set; get; } = false;
    float tick =0;

    private void Update()
    {        
        tick += Time.deltaTime * .2f;
        if (IsTackPointOccupied && tick <1)
        {
            GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.black, tick);
        }        
    }

    private void OnTriggerStay(Collider other)
    {
        if (TagReference.tag == other.tag) 
        {
            IsWeldPointOccupied = true;
        }
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

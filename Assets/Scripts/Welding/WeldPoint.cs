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

    public bool getPointState()
    {
        return IsWeldPointOccupied;
    }

    public bool getTackPointState()
    {
        return IsTackPointOccupied;
    }

    public void updateTackPointOccupation(bool updateTack)
    {
        IsTackPointOccupied = updateTack;
    }
}

using UnityEngine;

public class RemoveDebrisOnContact : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Debris"))
        {
            Debug.Log(other.gameObject.name);
            Destroy(other.gameObject);
        }
    }
}

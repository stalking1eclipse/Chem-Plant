using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField]
    float TimeBeforeSelfDestruct = 10f;
    [SerializeField]
    Color StartColor, EndColor;

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == transform.tag)
        {
            float tick = 0;
            while (gameObject.GetComponent<Renderer>().material.color != EndColor ) 
            {
                tick += Time.deltaTime * 5f;
                //gameObject.GetComponent<Renderer>().material.color = Color.Lerp(StartColor, EndColor, tick);
            }
            Destroy(gameObject, TimeBeforeSelfDestruct);
        }
    }
}

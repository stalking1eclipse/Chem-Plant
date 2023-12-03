using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceAppearance : MonoBehaviour
{
    bool isSurfaceClean  {get;set;}

    [SerializeField]
    Material cleanMaterial;
    [SerializeField]
    Material debrisMaterial;

    Collider[] debris;
    // Start is called before the first frame update
    void Start()
    {
        isSurfaceClean = true;
    }

    // Update is called once per frame
    void Update()
    {
        SetMaterial();
        
        debris = Physics.OverlapBox(transform.position, new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z));

        foreach (Collider collider in debris)
        {
            if (collider != null)
            {
                if (collider.CompareTag("Debris"))
                    isSurfaceClean = false;
                else
                    isSurfaceClean = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z));
    }

    void SetMaterial()
    {
        if (isSurfaceClean)
            transform.gameObject.GetComponent<Renderer>().material = cleanMaterial;
        else
            transform.gameObject.GetComponent<Renderer>().material = debrisMaterial;
    }
}

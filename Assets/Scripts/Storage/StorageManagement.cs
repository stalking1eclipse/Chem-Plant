using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageManagement : MonoBehaviour
{
    bool hasSurfaceAppearance;
    SurfaceAppearance _surfaceApp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Storage Area"))
        {
            hasSurfaceAppearance = other.TryGetComponent(out _surfaceApp);

            if (hasSurfaceAppearance )
            {

            }
        }
    }
}

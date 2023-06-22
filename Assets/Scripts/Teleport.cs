using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    RaycastHit hit;
    GameObject[] locations;
    LayerMask _layerMask = ~(1 << 10);
    Vector3 _position;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 10000000, _layerMask))
            {
                Debug.Log(hit.transform.name);
                locations = GameObject.FindGameObjectsWithTag("Telepad");

                foreach (GameObject location in locations)
                {
                    if (hit.transform.name + " Destination" == location.name)
                    {
                        _position = location.transform.position;
                        break;
                    }
                }

                Debug.Log(transform.position + " Old position");
                transform.position = _position;
                transform.SetPositionAndRotation(_position, transform.rotation);
                Debug.Log(transform.position + " New position");
            }
        }
    }
}

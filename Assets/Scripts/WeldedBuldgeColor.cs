using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeldedBuldgeColor : MonoBehaviour
{
    private void Update()
    {
        if (GetComponent<Renderer>().material.color != Color.black)
            GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.black, 5f);
    }
}

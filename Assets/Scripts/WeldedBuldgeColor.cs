using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeldedBuldgeColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeBuldgeColor());
    }

    IEnumerator ChangeBuldgeColor()
    {
        GetComponent<Renderer>().material.color = Color.Lerp(Color.red, Color.black, 5f);
        yield return new WaitForSeconds(7f);
    }
}

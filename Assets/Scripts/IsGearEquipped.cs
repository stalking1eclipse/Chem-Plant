using System.Collections.Generic;
using UnityEngine;

public class IsGearEquipped : MonoBehaviour
{
    public List<GameObject> barriers;
    public bool ChemplantHardhat = false, 
                ChemplantVest = false, 
                ChemplantGoggles = false, 
                ChemplantGloves = false, 
                ChemplantBoots = false,
                ChemplantMask = false,
                plantAccess = false;

    [SerializeField]
    GameObject leftSide, northSide;

    // Update is called once per frame
    void Update()
    {
        if (!ChemplantHardhat || !ChemplantVest || !ChemplantGloves || !ChemplantBoots || !ChemplantMask || !ChemplantGoggles)
        {
            plantAccess = false;
        }
        else
        {
            plantAccess = true;
        }

        if (leftSide && northSide)
        {
            leftSide.SetActive(!plantAccess);
            northSide.SetActive(!plantAccess);
        }

        if (plantAccess)
        {
            foreach (GameObject barrier in barriers)
            {
                barrier.transform.rotation = Quaternion.Euler(new Vector3(0, 90, -90));
            }
        }
    }
}

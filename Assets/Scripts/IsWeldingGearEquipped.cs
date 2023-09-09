using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsWeldingGearEquipped : MonoBehaviour
{
    //public List<GameObject> barriers;
    public bool WeldingWorkshopHelmet = false,
                WeldingWorkshopVest = false,
                WeldingWorkshopGoggles = false,
                WeldingWorkshopGloves = false,
                WeldingWorkshopBoots = false,
                WeldingWorkshopMask = false,
                workshopAccess = false;

    [SerializeField]
    GameObject leftSide, northSide;

    // Update is called once per frame
    void Update()
    {
        if (!WeldingWorkshopHelmet || !WeldingWorkshopVest || !WeldingWorkshopGoggles || !WeldingWorkshopGloves || !WeldingWorkshopBoots || !WeldingWorkshopMask)
        {
            workshopAccess = false;
        }
        else
        {
            workshopAccess = true;
        }

        if (leftSide && northSide)
        {
            leftSide.SetActive(!workshopAccess);
            northSide.SetActive(!workshopAccess);
        }

        //if (workshopAccess)
        //{
        //    foreach (GameObject barrier in barriers)
        //    {
        //        barrier.transform.rotation = Quaternion.Euler(new Vector3(0, 90, -90));
        //    }
        //}
    }

}

using System.Collections.Generic;
using UnityEngine;

public class IsWeldingGearEquipped : MonoBehaviour
{
    //public List<GameObject> barriers;
    public bool WeldingWorkshopHelmet = false,
                WeldingWorkshopVest = false,
                WeldingWorkshopGloves = false,
                WeldingWorkshopBoots = false,
                WeldingWorkshopRespirator = false,
                WeldingWorkshopEarProtectiveHeadphones = false,
                WeldingWorkshopFireproofClothes = false,
                workshopAccess = false;

    [SerializeField]
    List<GameObject> BarrierSides;

    // Update is called once per frame
    void Update()
    {
        if (!WeldingWorkshopHelmet || !WeldingWorkshopVest || !WeldingWorkshopEarProtectiveHeadphones || !WeldingWorkshopGloves || !WeldingWorkshopBoots || !WeldingWorkshopRespirator || !WeldingWorkshopFireproofClothes)
        {
            workshopAccess = false;
        }
        else
        {
            workshopAccess = true;
        }

        foreach (GameObject barrierSide in BarrierSides) 
        { 
            if (barrierSide)
            {
                barrierSide.SetActive(!workshopAccess);
            }
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

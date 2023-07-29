using System.Collections.Generic;
using UnityEngine;

public class IsGearEquipped : MonoBehaviour
{
    public List<GameObject> barriers;
    public bool hardhat = false, 
                vest = false, 
                goggles = false, 
                gloves = false, 
                boots = false, 
                mask = false,
                plantAccess = false;

    [SerializeField]
    GameObject leftSide, northSide;


    [SerializeField]
    GameObject  objHardhat, 
                objVest,
                objGoggles,
                objGloves,
                objBoots,
                objMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hardhat || !vest || !gloves || !boots || !mask || !goggles) 
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

        /*objHardhat.SetActive(hardhat);
        objVest.SetActive(vest);
        objGloves.SetActive(gloves);
        objBoots.SetActive(boots);
        objMask.SetActive(mask);
        objGoggles.SetActive(goggles);*/
    }
}

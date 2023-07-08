using UnityEngine;

public class IsGearEquipped : MonoBehaviour
{
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

        leftSide.SetActive(!plantAccess);
        northSide.SetActive(!plantAccess);

        /*objHardhat.SetActive(hardhat);
        objVest.SetActive(vest);
        objGloves.SetActive(gloves);
        objBoots.SetActive(boots);
        objMask.SetActive(mask);
        objGoggles.SetActive(goggles);*/
    }
}

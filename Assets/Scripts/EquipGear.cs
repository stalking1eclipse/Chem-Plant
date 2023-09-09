using UnityEngine;

public class EquipGear : MonoBehaviour
{
    [SerializeField]
    IsGearEquipped isGearEquipped;

    [SerializeField]
    IsWeldingGearEquipped isWeldingGearEquipped;

    #region Chemical Plant
    public void equipChemplantHardhat()
    {
        isGearEquipped.ChemplantHardhat = true;
    }

    public void equipChemplantVest()
    {
        isGearEquipped.ChemplantVest = true;
    }

    public void equipChemplantGoggles()
    {
        isGearEquipped.ChemplantGoggles = true;
    }

    public void equipChemplantGloves()
    {
        isGearEquipped.ChemplantGloves = true;
    }

    public void equipChemplantBoots()
    {
        isGearEquipped.ChemplantBoots = true;
    }

    public void equipChemplantMask()
    {
        isGearEquipped.ChemplantMask = true;
    }
    #endregion

    #region welding workshop
    public void equipWeldingWorkshopHelmet()
    {
        isWeldingGearEquipped.WeldingWorkshopHelmet = true;
    }

    public void equipWeldingWorkshopVest()
    {
        isWeldingGearEquipped.WeldingWorkshopVest = true;
    }

    public void equipWeldingWorkshopEarProtectiveHeadphones()
    {
        isWeldingGearEquipped.WeldingWorkshopEarProtectiveHeadphones = true;
    }

    public void equipWeldingWorkshopGloves()
    {
        isWeldingGearEquipped.WeldingWorkshopGloves = true;
    }

    public void equipWeldingWorkshopBoots()
    {
        isWeldingGearEquipped.WeldingWorkshopBoots = true;
    }

    public void equipWeldingWorkshopMask()
    {
        isWeldingGearEquipped.WeldingWorkshopMask = true;
    }

    public void equipWeldingWorkshopRespirator()
    {
        isWeldingGearEquipped.WeldingWorkshopRespirator = true;
    }

    public void equipWeldingWorkshopFireProofClothes()
    {
        isWeldingGearEquipped.WeldingWorkshopFireproofClothes = true;
    }

    #endregion
}

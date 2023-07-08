using UnityEngine;

public class EquipGear : MonoBehaviour
{
    [SerializeField]
    IsGearEquipped isGearEquipped;
    public void equipHardHat()
    {
        isGearEquipped.hardhat = true;
    }

    public void equipVest()
    {
        isGearEquipped.vest = true;
    }

    public void equipGoggles()
    {
        isGearEquipped.goggles = true;
    }

    public void equipGloves()
    {
        isGearEquipped.gloves = true;
    }

    public void equipBoots()
    {
        isGearEquipped.boots = true;
    }

    public void equipMask()
    {
        isGearEquipped.mask = true;
    }
}

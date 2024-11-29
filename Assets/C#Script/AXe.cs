using UnityEngine;

[CreateAssetMenu(fileName = "New AXE", menuName = "Items/Weapons/AXE")]
public class AXE : WeaponBase
{
    public int DiceSides = 20;

    public override string ItemName => "AXE";

    public override int GetAttackDamage()
    {
        return Random.Range(1, DiceSides + 1);
    }
    public override void UseItem() 
    {
        Debug.Log("Axe"); 
    }
}


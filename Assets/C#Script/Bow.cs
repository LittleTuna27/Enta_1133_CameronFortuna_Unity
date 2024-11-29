using UnityEngine;

[CreateAssetMenu(fileName = "New Bow", menuName = "Items/Weapons/Bow")]
public class Bow : WeaponBase
{
    public int DiceSides = 8;
    public override string ItemName => "Bow";
    public override int GetAttackDamage()
    {
        return Random.Range(1, DiceSides + 1);
    }
    public override void UseItem() 
    {
        Debug.Log("Bow");
    }
}


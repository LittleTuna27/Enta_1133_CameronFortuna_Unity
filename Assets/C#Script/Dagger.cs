using NUnit.Framework.Interfaces;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dagger", menuName = "Items/Weapons/Dagger")]
public class Dagger : WeaponBase
{
    public int DiceSides = 8;
    
    public override string ItemName => "Dagger";

    public override int GetAttackDamage()
    {
        return Random.Range(1, DiceSides + 1);
    }
    public override void UseItem()
    {
        Debug.Log("Dagger");
        ActionPoints = GetAttackDamage();
        User.playerDamage = ActionPoints;
        ItemUsed = true;
    }
}




using UnityEngine;


[CreateAssetMenu(fileName = "New StraightSword", menuName = "Items/Weapons/StraightSword")]
public class StraightSword : WeaponBase
{
    public int DiceSides = 12;

    public override string ItemName => "StraightSword";
    
    public override int GetAttackDamage()
    {
        return Random.Range(1, DiceSides + 1);
    }
    public override void UseItem()
    {
        Debug.Log("StraightSword");
        ActionPoints = GetAttackDamage();
        //combatRoom.computerhealth -= ActionPoints;
    }
}


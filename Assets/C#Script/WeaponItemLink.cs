using UnityEngine;
using static Item;

public class WeaponItemLink : MonoBehaviour
{
    public ScriptableObject ItemData;

    public void PrintItemDetails()
    {
        if (ItemData is WeaponBase weapon)
        {
            Debug.Log($"Weapon: {weapon.ItemName}");
        }
        else if (ItemData is Consumable consumable)
        {
            Debug.Log($"Consumable: {consumable.ItemName}");
        }
        else
        {
            Debug.Log("Unknown item type.");
        }
    }

    public int GetItemEffect()
    {
        if (ItemData is WeaponBase weapon)
        {
            int damage = weapon.GetAttackDamage();
            Debug.Log($"Weapon {weapon.ItemName} deals {damage} damage.");
            return damage;
        }
        else if (ItemData is Consumable consumable)
        {
            int healthBoost = consumable.GetHealthBoost();
            Debug.Log($"Consumable {consumable.ItemName} restores {healthBoost} health.");
            return healthBoost;
        }

        Debug.Log("Item has no effect.");
        return 0;
    }
}

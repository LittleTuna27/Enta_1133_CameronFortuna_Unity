using UnityEngine;

public abstract class Item : ScriptableObject
{
    public abstract string ItemName { get; }
    public abstract bool HasBeenUsed { get; }
    public abstract void UseItem();
    public bool ItemUsed = false;
    public int ActionPoints;
    
    public User User;
    public void PutPlayerInvetory(User user)
    {
        User = user;
    }
} 

public abstract class WeaponBase : Item
{
    public override bool HasBeenUsed => false;
    public abstract int GetAttackDamage();
}

public abstract class Consumable : Item
{
    public override bool HasBeenUsed => true;
    public abstract int GetHealthBoost();
}

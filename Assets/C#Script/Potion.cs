using UnityEngine;


[CreateAssetMenu(fileName = "New HealthPotion", menuName = "Items/Consumables/HealthPotion")]
public class HealthPotion : Consumable
{
    public int MaxHeal = 25;
    private GameManager manager;
   
    public void SetGameManager(GameManager NONmanager)
    {
        manager = NONmanager;
    }
    public override string ItemName => "Health Potion";

    public override int GetHealthBoost()
    {
        return Random.Range(1, MaxHeal + 1);
    }
    public override void UseItem() 
    {
        Debug.Log("Potion");
        ActionPoints = GetHealthBoost();
        manager.User.currentHP += ActionPoints;
     }
}



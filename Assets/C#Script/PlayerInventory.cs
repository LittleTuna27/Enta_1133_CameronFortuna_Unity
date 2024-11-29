using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    public Transform InventoryUIParent; // Parent for inventory buttons
   
    public static PlayerInventory Instance { get; private set; }
    public List<Item> UserInventory = new List<Item>();
    public List<ItemButtonScript> itembuttons = new List<ItemButtonScript>();
    public Item Item;
    public int playerDamage;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }

        UserInventory.Add(new Dagger());
        UserInventory.Add(new StraightSword());
        UserInventory.Add(new Bow());
        UserInventory.Add(new AXE());
        UserInventory.Add(new HealthPotion());

       for(int i = 0; i < UserInventory.Count; i++)
        {
            itembuttons[i].thisItem = UserInventory[i];
        }
        setPlayerInventory();
    }
    public void setPlayerInventory()
    {
        Item.PutPlayerInvetory(this);
    }
    public Dictionary<string, int> CountItems()
    {
        // Group items by their name and count occurrences
        return UserInventory
            .GroupBy(item => item.ItemName)
            .ToDictionary(group => group.Key, group => group.Count());
    }

    public void AddItem(Item newItem)
    {
        Debug.LogWarning("WE ADDED ITEM?");
        UserInventory.Add(newItem);
    }
    public void RemoveItem(Item ItemData)
    {
        UserInventory.Remove(ItemData);
    }

}

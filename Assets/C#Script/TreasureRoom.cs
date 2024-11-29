using System.Collections.Generic;
using UnityEngine;

public class TreasureRoom : BaseRoom
{
    public bool treasureChestOpen = true;

    public override void OnRoomSearched()
    {
        AddItemToPlayer();
    }

    public void AddItemToPlayer()
    {
        if (treasureChestOpen)
        {
            ItemGeneration();
            ItemGeneration();
            ItemGeneration();
            ItemGeneration();
            treasureChestOpen = false;
        }
        else
        {
            RoomMessage = "You have already searched this room.";
        }
        
    }

    private Item GenerateRandomItem()
    {
        List<Item> itemList = new List<Item>()
        {
            new Dagger(),
            new StraightSword(),
            new AXE(),
            new Bow(),
            new HealthPotion()
        };

        int randomIndex = Random.Range(0, itemList.Count);
        return itemList[randomIndex];
    }

    public void ItemGeneration()
    {
        if (treasureChestOpen)
        {
            
                Debug.LogWarning("WE DID WE DID ADD A ITEM?");
                Item newItem = GenerateRandomItem();
                PlayerInventory.Instance.AddItem(newItem); // Access the static instance
        }
        else
        {
            RoomMessage = "Yus Have Searched Here";
        }
    }
}
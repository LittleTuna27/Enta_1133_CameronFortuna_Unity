using System;
using System.Collections.Generic;
using static BasicItems;



//private MapManager gameMap;
public class Player//a class to hold the players stats
    {
        
        public int currentHP = 25;//a int for the players current hp
        public int maxHp = 50; //players max health
        public int playerDamage = 0;// a int for players damadge
        public bool combatStart = false;

        public string? input; 

        public List<Item> InventoryList = new List<Item> //creating a starting list and for my players inventory
        {
             new Daggers(),
             new StraightSword(),
             new GreatSword(),
             new Bow(),
             new HealthPotion()
        };
       

        public void NoDice()//a function for if they select a unavalible dice or a imput that isnt allowed to reset the choice
        {
            UseItem();//getting player input on which weapon they want to use

        }
        public void UseItem()
        {
  
            // Check if the inventory has items
            if (InventoryList.Count == 0)//if they have no items in the inventory list
            {
                Console.WriteLine("Your inventory is empty.");
                return;
            }

            // Display the player's inventory with index numbers
            Console.WriteLine("Choose an item to use from your inventory:");
            for (int i = 0; i < InventoryList.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {InventoryList[i].ItemName}");//show item name and index for use
            }

            // Get the player's choice
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > InventoryList.Count)//if they didnt pick a item that is listed via a number
            {
                Console.WriteLine("Invalid selection.");
                return;
            }

            // Get the chosen item
            Item selectedItem = InventoryList[choice - 1];

            // Check if the item is a consumable
            if (selectedItem is Consumables consumable)
            {
                int healthGiven = 0;
                consumable.GiveHealth(ref healthGiven);
                Console.WriteLine($"You used a {consumable.ItemName} and healed {healthGiven} health points.");
                GetHealth(healthGiven); // Update player's health

                // Remove the item from the inventory after it's used
                InventoryList.RemoveAt(choice - 1);
            }

            //checking if weapon has Weapon inheritence
            else if (selectedItem is WeaponBase weapon)
            {
                    int damage = 0; //starting int for damadge
                    weapon.AttackDamage(ref damage);// calls for specific weapons damadge
                    Console.WriteLine($"You attacked with {weapon.ItemName} and dealt {damage} damage.");
                    InventoryList.RemoveAt(choice - 1); // Remove the item from the inventory after it's used
                    playerDamage = damage; //takes damadge roll and sets it to player damadge

                }
              
                
            
            else
            {
                Console.WriteLine("This item cannot be used.");
                NoDice();
            }
        }
        //displays players inventory
        public void DisplayInventory()
        {
            Console.WriteLine("Your Inventory:");
            Console.WriteLine($"You have {currentHP} hp of your {maxHp}");//display player hp
            foreach (var item in InventoryList) //for each item in the player inventory display it
            {
                Console.WriteLine(item.ItemName);
            }
            Console.WriteLine("Do you wish to use a item?");
            Console.WriteLine("1 = yes,2=no");
            string? input = Console.ReadLine();//getting if they want to use a item

            if (int.TryParse(input, out int ItemUseage))
            {
                if (ItemUseage == 1)
                { UseItem(); }

            }
        }
        
        public void GetHealth(int healAmount)
        {
            currentHP += healAmount;//increase hp base of of heal amount
            if (currentHP > 50)
            { // If PlayerLife is greater than 50 the PlayerLife will be 50
                currentHP = 50;
            }
            Console.WriteLine($"You healed {healAmount} life points. Current life: {currentHP}");
            Console.WriteLine($"Now you have {currentHP} of life");

        }
        public void AddItemToInventory()
        {
            Item item = RandomItem(); // Get a random item
            InventoryList.Add(item); // Add to the player's inventory
            Console.WriteLine($"You found a {item.ItemName}");
        }
        public Item RandomItem()//randomly select an item to add to players inventory
        {
            List<Item> possibleItems = new List<Item>//a list of items to get out of the treasure chest
            {
                new Daggers(),
                new StraightSword(),
                new GreatSword(),
                new Bow(),
                new HealthPotion()
             };
            Random rnd = new Random();
            int randomIndex = rnd.Next(possibleItems.Count); //gets random value
            return possibleItems[randomIndex];//returns what item was picked

        }
        
    }


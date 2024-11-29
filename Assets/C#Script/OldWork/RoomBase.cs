using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static base_room_script;


public class RoomBase
    {
        
        public ComputerProfile CPU = new ComputerProfile();
        public GameManagerV1 manager = new GameManagerV1();
        public bool combatStart = false;
        public bool treasureChestOpen = true;
        public bool runesUsed = true;
        public abstract class DungeonRoomLayout
        {
            
            public bool combatStart = false;
            public bool treasureChestOpen = true;
            public bool runesUsed = true;
            // Every roomScript will have a description
            public string? RoomDescription { get; set; }

            // RunRoom should display the roomScript description and handle interaction
            public virtual void OnRoomEntered()
            {
                Console.WriteLine(RoomDescription);
                OnRoomSearched();
            }

            // OnRoomSearched should handle roomScript-specific logic but NOT call RunRoom again
            public virtual void OnRoomSearched()
            {

            }
            public virtual void OnRoomExit()
            {
            
            }
        }
        public class Room1 : DungeonRoomLayout
        {
           
            public override void OnRoomEntered()
            {
                Console.Write("This room is completely empty.");
            }

        }

        public class Room2 : DungeonRoomLayout
        {
           
            public override void OnRoomEntered()
            {
                Console.Write("This room is completely empty.");
            }
        }
        public class Room3 : DungeonRoomLayout 
        {
            public int step = 0;
            public override void OnRoomEntered()
            {
                Console.WriteLine("You see some weird runes on the ground");
                OnRoomSearched();
            }
            public override void OnRoomSearched()
            {
                base.OnRoomSearched();
                if (runesUsed)
                {
                    Console.WriteLine("Do you step on them");//set up a chance for a heal room or a damaedge room base on what u pick
                    Console.WriteLine("1-Yes, 2-No");
                    string? heal;
                    heal = Console.ReadLine();
                    if (int.TryParse(heal, out int choice))
                    {
                        if (choice == 1)
                        {
                            Random randome = new Random();
                            step = randome.Next(0, 2);//fifty fifty choice on heal or damage
                            switch (step)
                            {
                                case 0:
                                    Random randoma = new Random();
                                    int healed = randoma.Next(0, 10);
                                    GameManagerV1.player.currentHP += healed;
                                    Console.WriteLine($"You healed {healed}");

                                    break;
                                case 1:
                                    Random random = new Random();
                                    int damadged = random.Next(0, 10);
                                    GameManagerV1.player.currentHP -= damadged;
                                    Console.WriteLine($"You took {damadged} damage");
                                    break;
                            };
                        }
                        else
                        {
                            Console.WriteLine("That was probably for the best");
                            Console.WriteLine("But WHOOOO KNOWSSSS");
                        }
                    }
                    else 
                    { 
                        Console.WriteLine("you've searched this room");
                    }

                }
            }
        }
        public class Room4 : DungeonRoomLayout 
        {
            
            public override void OnRoomEntered()
            {
                Console.Write("This room is completely empty.");
            }
        }
        public class Room5 : DungeonRoomLayout
        {
           
            public override void OnRoomEntered()
            {
                Console.Write("This room is completely empty.");
            }
        }
        public class Room6 : DungeonRoomLayout
        {
           
            public override void OnRoomEntered()
            {
                Console.Write("This room is completely empty.");
            }
        }
        public class Room7 : DungeonRoomLayout
        {
            public override void OnRoomEntered()
            {
                Console.Write("This room is completely empty.");
            }
        }
        public class Room8 : DungeonRoomLayout
        {
            public override void OnRoomEntered()
            {
                Console.WriteLine("You see a treasure chest");

                OnRoomSearched();
            }
            public override void OnRoomSearched()
                {

                if (treasureChestOpen)
                {
                    Console.WriteLine("Do you want to open the chest?");
                    Console.WriteLine("Yes or No");
                    string? input = Console.ReadLine();

                    if (input.ToLower() == "yes" || input.ToLower() == "y" || input.ToLower() == "1")
                    {
                        treasureChestOpen = false;
                        GameManagerV1.player.AddItemToInventory();  // Add item to the player's existing inventory
                        GameManagerV1.player.AddItemToInventory();
                        GameManagerV1.player.AddItemToInventory();
                        GameManagerV1.player.AddItemToInventory();
                    }
                    else
                    {
                        //is they dont open the chest
                        Console.WriteLine("That's fine");
                    }
                }
                else
                {
                    //display 
                    Console.WriteLine("You have already searched this room.");
                } 
            }
           }

        public class Room9 : DungeonRoomLayout
        {
            public ComputerProfile CPU = new ComputerProfile();
            public GameManagerV1 manager = new GameManagerV1();
            public override void OnRoomEntered()
            {
                Console.WriteLine("Something jumps at you from the shadows!");
                OnRoomSearched();
            }
            public override void OnRoomSearched()
            {
                manager.Gamecombat();  // Throws a null reference if manager is not initialized.
            }
            public override void OnRoomExit()
            {
                Console.WriteLine("You Wanna Go Again"); //asking player to play again
                Console.WriteLine("Yes or No");
                string? Replay; //a string to take hold their reply
                Replay = Console.ReadLine(); //allowing the player to input


                if (Replay == "Yes" || Replay == "yes" || Replay == "y" || Replay == "Y" || Replay == "1") //if yes then reset all variables to there start
                {
                    GameManagerV1 gameManager = new GameManagerV1();
                    CPU.computerHealth = 25; //resetting my integers back to starting state

                    gameManager.Intro();


                }
                else //ends game with a tank you
                {
                    manager.roundContinue = false; //ends game with a tank you
                    Console.WriteLine("We understand your and thank you for your time partner"); //thank you message
                    Environment.Exit(0);//closses game
                }
            }

        }
    }

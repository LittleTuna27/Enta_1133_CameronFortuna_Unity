using System;
using System.Collections.Generic;
using static RoomBase;
using UnityEngine;

public class base_room_script
    {

        public int verticalMovement = 1;
        public int horizontalMovement = 1;
        

        //DungeonRoomLayout dungoenLayout = new DungeonRoomLayout();
       
        RoomBase roomSort = new RoomBase();

        public bool northMovementPossible = false;
        public bool southMovementPossible = false;
        public bool eastMovementPossible = false;
        public bool westMovementPossible = false;

        public bool wantToPlay = true;

        public int playerPickDice = 0;
        public string? input;
        

        GameManagerV1 manager = new GameManagerV1();

        DungeonRoomLayout[,] grid = new DungeonRoomLayout[3, 3]; // Array of Rooms

        public void DefualtList()
        {
            List<DungeonRoomLayout> dungeonRooms = new List<DungeonRoomLayout> //list for the rooms
        { new Room1(), new Room2(), new Room3(), new Room4(), new Room5(), new Room6(), new Room7(), new Room8(), new Room9()};

            /*Random random = new Random();
            int rooms = dungeonRooms.Count;

            List<DungeonRoomLayout> randomizedRooms = new List<DungeonRoomLayout>();//new list for order of randomized rooms
            for (int r = 0; r < rooms; r++)
            {
                int selectedRoom = random.Next(0, dungeonRooms.Count);//randomly select a room from the dunfon list based on the count of the items in the list
                randomizedRooms.Add(dungeonRooms[selectedRoom]);//adds whatever room to the list
                dungeonRooms.RemoveAt(selectedRoom);// removes item from the list
            }*/

            // Assign rooms to grid (no negative indices)
            grid[0, 0] = dungeonRooms[0]; // Top left
            grid[0, 1] = dungeonRooms[1]; // Top middle
            grid[0, 2] = dungeonRooms[2]; // Top right

            grid[1, 0] = dungeonRooms[3]; // Middle left
            grid[1, 1] = dungeonRooms[4]; // Middle middle (Start Room)
            grid[1, 2] = dungeonRooms[5]; // Middle right

            grid[2, 0] = dungeonRooms[6]; // Bottom left
            grid[2, 1] = dungeonRooms[7]; // Bottom middle
            grid[2, 2] = dungeonRooms[8]; // Bottom right
        }
    public void GameLoop(Player player)
        {
            DefualtList();
            do
            {
                DisplayCurrentRoom();  // Show the current roomScript info
                MapDisplay();//display map
                PlayerWantToDo(player);// Check valid movement options
                PlayermMovementChoice();  // Move the player
            }
            while (wantToPlay == true);
        }
        public void DisplayCurrentRoom()
        {
            Console.WriteLine($"You are in room at position [{verticalMovement}, {horizontalMovement}]");//display players cordinets
            DungeonRoomLayout currentRoom = grid[verticalMovement, horizontalMovement]; //
            currentRoom.OnRoomEntered(); // Display current roomScript description
          
        }
        public void NoMovementPicked()
        {
            PlayermMovementChoice();
        }
        public void PlayerWantToDo(Player player)
        {
            
            Console.WriteLine("What do you want to do");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("1 - Check inventory");
            Console.WriteLine("2 - Move to new room");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        // Ensure that player is not null before calling DisplayInventory
                        if (player != null)
                        {
                            player.DisplayInventory();  // Use the player object passed from GameManagerV1
                        }
                        else
                        {
                            Console.WriteLine("WHAAAAT NO ITEMS");
                        }
                        break;
                    case 2:
                        PLayerChoice();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a number between 1 and 4.");
            }
        }
        public void PLayerChoice()
        {
            Console.WriteLine("Where do you want to go? 1=North, 2=East, 3=South, 4=West");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int direction))
            {
                switch (direction)
                {
                    case 1: // North
                        if (CanMoveNorth()) verticalMovement--;//checks for null room and if it isnt moves the player
                        Console.WriteLine("you moved North!");
                        Console.Clear();  // Clear screen for next round
                        break;
                    case 2: // East
                        if (CanMoveEast()) horizontalMovement++;//checks for null room and if it isnt moves the player
                        Console.WriteLine("you moved East!");
                        Console.Clear();  // Clear screen for next round
                        break;
                    case 3: // South
                        if (CanMoveSouth()) verticalMovement++;//checks for null room and if it isnt moves the player
                        Console.WriteLine("you moved South!");
                        Console.Clear();  // Clear screen for next round
                        break;
                    case 4: // West
                        if (CanMoveWest()) horizontalMovement--;//checks for null room and if it isnt moves the player
                        Console.WriteLine("you moved West!");
                        Console.Clear();  // Clear screen for next round
                        break;
                    default://checks for null room and if it isnt say no ggod
                        Console.WriteLine("Invalid direction.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a number between 1 and 4.");
                NoMovementPicked();
            }
        }
      
        public bool CanMoveNorth() => verticalMovement > 0;//  This method checks if the player can move north by verifying if the verticalMovement value is greater than 0
        public bool CanMoveEast() => horizontalMovement < 2;// if true return true if false retrun false
        public bool CanMoveSouth() => verticalMovement < 2;//
        public bool CanMoveWest() => horizontalMovement > 0;//

        public void PlayermMovementChoice()
        {
            if (grid[verticalMovement, horizontalMovement] != null)//saying the grid cannot equal a null value and if it does do the else statement
            {
                Console.WriteLine($"Moved to room at [{verticalMovement}, {horizontalMovement}]");
            }
            else
            {
                Console.WriteLine("This is an empty space. Can't move there.");
            }
        }
    
    public void MapDisplay()
        {
            Console.WriteLine();
            Console.WriteLine("You Are Here");
            Console.WriteLine();
            MapDisplayTopLeft();
            MapDisplayTopMiddle();
            MapDisplayTopRight();
            MapDisplayMiddleLeft();
            MapDisplayMiddleRight();
            MapDisplayMiddleMiddle();
            MapDisplayBottomRight();
            MapDisplayBottomLeft();
            MapDisplayBottomMiddle();
        }
        public void MapDisplayTopLeft()
        {
            if (verticalMovement == 0 && horizontalMovement == 0)
            {
                Console.WriteLine(@"______________________________
|         |         |         |
|    X    |         |         |
|_________|_________|_________|
|         |         |         |
|         |         |         |
|_________|_________|_________|
|         |         |         |
|         |         |         |
|_________|_________|_________|
");
            }

        }
        public void MapDisplayTopMiddle()
        {
            if (verticalMovement == 0 && horizontalMovement == 1)
            {
                Console.WriteLine(@" ______________________________
|         |         |         |
|         |    X    |         |
|_________|_________|_________|
|         |         |         |
|         |         |         |
|_________|_________|_________|
|         |         |         |
|         |         |         |
|_________|_________|_________|
");

            }
        }
        public void MapDisplayTopRight()
        {
            if (verticalMovement == 0 && horizontalMovement == 2)
            {
                Console.WriteLine(@" ______________________________
|         |         |         |
|         |         |    X    |
|_________|_________|_________|
|         |         |         |
|         |         |         |
|_________|_________|_________|
|         |         |         |
|         |         |         |
|_________|_________|_________|
");
                //set up strings to display in my map with an array so that so that in the box the string would be called to display the x if the variables 
            }

        }
        public void MapDisplayMiddleLeft()
        {
            if (verticalMovement == 1 && horizontalMovement == 0)
            {
                Console.WriteLine(@" ______________________________
|         |         |         |
|         |         |         |
|_________|_________|_________|
|         |         |         |
|    X    |         |         |
|_________|_________|_________|
|         |         |         |
|         |         |         |
|_________|_________|_________|
");
            }

        }
        public void MapDisplayMiddleMiddle()
        {
            if (verticalMovement == 1 && horizontalMovement == 1)
            {
                Console.WriteLine(@" ______________________________
|         |         |         |
|         |         |         |
|_________|_________|_________|
|         |         |         |
|         |    X    |         |
|_________|_________|_________|
|         |         |         |
|         |         |         |
|_________|_________|_________|
");
            }
        }
        public void MapDisplayMiddleRight()
        {
            if (verticalMovement == 1 && horizontalMovement == 2)
            {
                Console.WriteLine(@" ______________________________
|         |         |         |
|         |         |         |
|_________|_________|_________|
|         |         |         |
|         |         |    X    |
|_________|_________|_________|
|         |         |         |
|         |         |         |
|_________|_________|_________|
");
            }

        }
        public void MapDisplayBottomLeft()
        {
            if (verticalMovement == 2 && horizontalMovement == 0)
            {
                Console.WriteLine(@" ______________________________
|         |         |         |
|         |         |         |
|_________|_________|_________|
|         |         |         |
|         |         |         |
|_________|_________|_________|
|         |         |         |
|    X    |         |         |
|_________|_________|_________|
");
            }
        }
        public void MapDisplayBottomMiddle()
        {
            if (verticalMovement == 2 && horizontalMovement == 1)
            {
                Console.WriteLine(@" ______________________________
|         |         |         |
|         |         |         |
|_________|_________|_________|
|         |         |         |
|         |         |         |
|_________|_________|_________|
|         |         |         |
|         |    X    |         |
|_________|_________|_________|
");
            }

        }
        public void MapDisplayBottomRight()
        {
            if (verticalMovement == 2 && horizontalMovement == 2)
            {
                Console.WriteLine(@" ______________________________
|         |         |         |
|         |         |         |
|_________|_________|_________|
|         |         |         |
|         |         |         |
|_________|_________|_________|
|         |         |         |
|         |         |    X    |
|_________|_________|_________|
");
            }

        }
    }

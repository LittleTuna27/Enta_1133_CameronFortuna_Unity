using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;



public class PlayerVSComputer
    {
        public string? username;


        public bool whoGoFirst = true;


        public bool TurnOrder() //a function to randomly pick between who starts
        {
            Random random = new Random();  //calling for a new random instance
            if (random.Next(0, 2) == 0) //giving me a random value between 1 and 0 and if that value is 0 then set whoGoFirst to true
            {
                Console.WriteLine($"{username} Goes First");// saying the player goes first
                whoGoFirst = true;// setting boolean to true so that the when we call for WhatThatTurnDo it knows to play the sequnce where the player functions are first
            }
            else
            {
                Console.WriteLine("Computer Goes First");// saying the CPU goes first
                whoGoFirst = false;// setting boolean to false so that the when we call for WhatThatTurnDo it knows to play the sequnce where the CPU functions are first
            }

            return whoGoFirst; //returning the value to change the value of the boolean to whatever it is
        }
        public void WhatThatTurnDo(Player player, ComputerProfile CPU, GameManagerV1 manager) //calling a sequence of functions based on who goes first
        {
            
            if (whoGoFirst == true)//if the player goes first
            {
                do
                {
                    CPU.DisplayHealth(); //displays enemies health
                    manager.combatStart = true;
                    player.UseItem();//getting player input on which weapon they want to use
                    DamagePlayer(player, CPU);//deal damandge to enemy from players choice
                    CPU.CPUDiceSelect();//getting computers random  input on which weapon they will select
                    CPU.CPUDiceHas();//using whatever input that is to use said gun/dice
                    DamageComputer(player, CPU); //damadge of computer applied to player
                } while (player.currentHP >= 0 && CPU.computerHealth >= 0);
            }
            else
            {
                do //start at zero then check if i is past turns 
                {
                    CPU.DisplayHealth();
                    manager.combatStart = true;
                    CPU.CPUDiceSelect();
                    CPU.CPUDiceHas();
                    DamageComputer(player, CPU);
                    player.UseItem();
                    DamagePlayer(player, CPU);
                } while (player.currentHP >= 0 && CPU.computerHealth >= 0);
                
            }
            ScoreRound( player,  CPU);
            PlayAgain(player, CPU);
        }
        public static void DamageComputer(Player player, ComputerProfile CPU)
        { 
            player.currentHP -= CPU.computerDamadge;
        }
        public static void DamagePlayer(Player player, ComputerProfile CPU)
        {
            CPU.computerHealth -= player.playerDamage;
        }
        public void ScoreRound(Player player, ComputerProfile CPU) //comparing the players score to the computers to see who won
        {
            if (player.currentHP > CPU.computerHealth) //if the players score is greater then the computers display win message
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($"The ogre has {CPU.computerHealth} health left");//display of the CPU round score
                Console.WriteLine($"While you have {player.currentHP} health");//display of the players round score
                Console.WriteLine("so you Survive the fight!!!");
                Console.WriteLine("-------------------------------------------");
            }
           
            else if (player.currentHP < CPU.computerHealth)//if the players score is less then the computers display lose message
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($"The ogre has {CPU.computerHealth} health left");//display of the CPU round score
                Console.WriteLine($"While you have {player.currentHP} health");//display of the players round score
                Console.WriteLine("so you LOSE OH NOOOOOOOO");
                Console.WriteLine("-------------------------------------------");
                
            

            }
        }
        public void PlayAgain(Player player, ComputerProfile CPU)
        {
            GameManagerV1 gameManager = new GameManagerV1(); //making a new game manager to start loop again if needed
            RoomBase RoomBase = new RoomBase();
            Console.WriteLine("You Wanna Go Again"); //asking player to play again
            Console.WriteLine("Yes or No");
            string? Replay; //a string to take hold their reply
            Replay = Console.ReadLine(); //allowing the player to input


            if (Replay == "Yes" || Replay == "yes" || Replay == "y" || Replay == "Y" || Replay == "1") //if yes then reset all variables to there start
            {
              
                player.playerDamage = 0;
               
                CPU.computerHealth = 25; //resetting my integers back to starting state

                gameManager.Intro();


            }
            else //ends game with a tank you
            {
                gameManager.roundContinue = false; //ends game with a tank you
                Console.WriteLine("We understand your and thank you for your time partner"); //thank you message
                Environment.Exit(0);//closses game
            }
        }

    }


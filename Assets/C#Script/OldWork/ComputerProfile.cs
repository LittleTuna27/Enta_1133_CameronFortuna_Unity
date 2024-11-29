using System;
using System.Collections.Generic;
using static BasicItems;


public class ComputerProfile
    {
        
        public int computerHealth = 30; //enemy health
        public int computerDamadge = 0; //enemy damadge
        public int computerDicePicked = 0; 

        List<DiceRoller> computerDiceList = new List<DiceRoller>// a list for all the computers 
        {

            new DiceRoller(6),// a instance of dice roller to sed the side count to 6
            new DiceRoller(8),
            new DiceRoller(12),


         };
        public void DiceReturn()// re runs code to select and use dice
        {
            CPUDiceSelect();
            CPUDiceHas();
        }
        internal int CPUDiceSelect()// a function to randomly pick a attack
        {
            Random computerChoice = new Random(); 
            computerDicePicked = computerChoice.Next(0, 3);
            return computerDicePicked;

        }
        public void DisplayHealth()//displays computers current health
        {
            Console.WriteLine($"The Ogre Has {computerHealth} hp left");
        }

        public int CPUDiceHas()
        {
            if (computerDicePicked == 0) //if the computers input was a one then and they havent used this dice then proced
            {
                Console.WriteLine("-------------------------------------------");
                int randomD6Roll = computerDiceList[0].RandomDiceRoll(); //rolls dice
                Console.WriteLine($"Ogre yelled Dealing {computerDiceList[0].previousResults} damage"); //saying what they rolled 
                computerDamadge = computerDiceList[0].previousResults;// adding said roll to their score

            }

            else if (computerDicePicked == 1)
            {
                Console.WriteLine("-------------------------------------------");
                int randomD8Roll = computerDiceList[1].RandomDiceRoll();
                Console.WriteLine($"Ogre kicked Dealing {computerDiceList[1].previousResults} damage");
                computerDamadge = computerDiceList[1].previousResults;


            }

            else if (computerDicePicked == 2)
            {
                Console.WriteLine("-------------------------------------------");
                int randomD12Roll = computerDiceList[2].RandomDiceRoll();
                Console.WriteLine($"Ogre punched dealing {computerDiceList[2].previousResults} damage");
                computerDamadge = computerDiceList[2].previousResults;
            }
            else
            {
                DiceReturn();
            }
            return computerDamadge;
        }
    }

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DiceRoller
    {

        public int totalSides = 8;  //setting the integer from the list to the total sides of the dice
                    
        public int previousResults = 0; //a variable for the dice result
        public Random rollInstance = new Random();//a instance for random in my dice roller
        public DiceRoller(int sides)
        {
            totalSides = sides;
        }
        public int RandomDiceRoll()// a function to call for when they need the value of their roll
         {
            previousResults = rollInstance.Next(1, totalSides + 1);//saying that the previous results is = to the roll
            return previousResults;// returns said output so it can be called
         }
    }


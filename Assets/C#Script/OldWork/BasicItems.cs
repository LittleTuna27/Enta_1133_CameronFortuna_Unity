using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class BasicItems
    {
        
        public abstract class Item //what is an item
        {
            public DiceRoller dice = new DiceRoller(6);
            public abstract string ItemName { get; }
            public abstract bool HasBeenUsed { get; }
        }

        public abstract class WeaponBase : Item
        {
            public override bool HasBeenUsed { get; } = false;
            public abstract void AttackDamage(ref int damage);
        }

        public abstract class Consumables : Item
        {
            public override bool HasBeenUsed { get; } = true;
            public abstract void GiveHealth(ref int healthGiven);
        }

        public class Daggers : WeaponBase
        {
            public override string ItemName { get; } = "Daggers";//weapon name
            public override void AttackDamage(ref int damage)
            {
                dice.totalSides = 8;//weapon dice size
                damage = dice.RandomDiceRoll();//get weapon damage
            }
        }

        public class StraightSword : WeaponBase
        {
            public override string ItemName { get; } = "StraightSword";

            public override void AttackDamage(ref int damage)
            {
                dice.totalSides = 12;
                damage = dice.RandomDiceRoll();
            }
        }

        public class GreatSword : WeaponBase
        {
            public override string ItemName { get; } = "GreatSword";

            public override void AttackDamage(ref int damage)
            {
                dice.totalSides = 20;
                damage = dice.RandomDiceRoll();
            }
        }
        public class Bow : WeaponBase
        {
            public override string ItemName { get; } = "Bow";

            public override void AttackDamage(ref int damage)
            {
                dice.totalSides = 8;
                damage = dice.RandomDiceRoll();
            }
        }


        public class HealthPotion : Consumables
        {
            public override string ItemName { get; } = "Heal Potion";
            public override void GiveHealth(ref int healthGiven)
            {
                dice.totalSides = 25;
                healthGiven = dice.RandomDiceRoll();
            }
        }

    }


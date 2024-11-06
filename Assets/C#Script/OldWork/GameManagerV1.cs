using static Player;
using System;
using System.Collections.Generic;
using UnityEngine;


public class GameManagerV1 : MonoBehaviour
{
        public static Player player = new Player();//making it static so i can refrence it withou needing to make a new version of it 
        PlayerVSComputer bigTurn = new PlayerVSComputer();
        ComputerProfile CPU = new ComputerProfile();
        public static base_room_script roomScript = new base_room_script();
        internal bool roundContinue = true;
        public bool combatStart = false; //tried setting up a bool so if the player wasnt in combat they couldn't use there items but couldnt get it to work

   
    public void Intro() //the start of code for the intro
    {
        Console.WriteLine("-------------------------------------------");
        Console.WriteLine("Hello, World"); //just a simple greeting
        Console.WriteLine("I'm Cameron Fortuna in Enta 1133 GD12"); //just an intoduction of myself 
        Console.WriteLine("Welcome to ");
        Console.WriteLine(@" ▄██████▄     ▄█    █▄          ▄█     █▄     ▄████████  ▄█        ▄█      
███    ███   ███    ███        ███     ███   ███    ███ ███       ███      
███    ███   ███    ███        ███     ███   ███    █▀  ███       ███      
███    ███  ▄███▄▄▄▄███▄▄      ███     ███  ▄███▄▄▄     ███       ███      
███    ███ ▀▀███▀▀▀▀███▀       ███     ███ ▀▀███▀▀▀     ███       ███      
███    ███   ███    ███        ███     ███   ███    █▄  ███       ███      
███    ███   ███    ███        ███ ▄█▄ ███   ███    ███ ███▌    ▄ ███▌    ▄
 ▀██████▀    ███    █▀          ▀███▀███▀    ██████████ █████▄▄██ █████▄▄██
                                                                           ");
        Console.WriteLine("Who Are You adventurer");
        bigTurn.username = Console.ReadLine();
        Console.WriteLine($"Welcome {bigTurn.username}");
        Console.WriteLine("You have just be dumped into a pit by your party beleiveing you are dead");
        Console.WriteLine("Now you must try and survive");
        Console.WriteLine("Lets Get going adventurer");
        Console.WriteLine("-------------------------------------------");
        roomScript = new base_room_script();
        roomScript.GameLoop(player);
    }
    public void Gamecombat()//this functions wholl purpose is to randomize the turn order then with that result okay which sequence of turns
         {
            do
            {
                bigTurn.TurnOrder(); //this function is calling for who rolls first
                bigTurn.WhatThatTurnDo(player, CPU, this);//this one plays said turn order
            }
            while (roundContinue == true);
         }

        
        public void Outro() //a simple function to play a thank you for playing
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Thanks for playing my game");
            Console.WriteLine(bigTurn.username); //call their name again
            Console.WriteLine("Goodbye");
            Console.WriteLine("-------------------------------------------");
            Environment.Exit(0);
           
        }
    }


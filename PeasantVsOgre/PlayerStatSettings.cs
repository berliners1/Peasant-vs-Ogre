using System;
using System.Collections.Generic;
using System.Text;

namespace PeasantVsOgre
{
    public class PlayerStatSettings
    {
        //initial variables
        public string name;
        public double hp;
        public double attack;
        public double block;
        public double speed;

        //constructor
        public PlayerStatSettings(string name, double hp, double attack, double block, double speed)
        {
            this.name = name;
            this.hp = hp;
            this.attack = attack;
            this.block = block;
            this.speed = speed;
        }


        /*functionality methods*/

        //RNG functionality -- the D20 roll
        public int RandomNumberGeneration()
        {
            Random random = new Random();
            return random.Next(0, 21); //random number between 1 and 20
        }

        //Attack functionality
        public double Attack()
        {
            var TheNum = RandomNumberGeneration();

            switch (TheNum)
            {
                case var x when x <= 5:
                    attack = 2;
                    Console.WriteLine($"{name} Attacks for {attack} damage");
                    return attack;
                case var x when x <= 15:
                    attack = 8;
                    Console.WriteLine($"{name} Attacks for {attack} damage");
                    return attack;
                case var x when x <= 19:
                    attack = 16;
                    Console.WriteLine($"{name} Attacks for {attack} damage");
                    return attack;
                case var x when x == 20:
                    attack = 40;
                    Console.WriteLine($"{name} Attacks for {attack} damage (Critical roll!!!)");
                    return attack;
                default:
                    Console.WriteLine($"{name} attack What happened? TheNum {TheNum}");
                    return attack;
            }

        }

        //Block functionality
        public double Block()
        {
            var TheNum = RandomNumberGeneration();

            switch (TheNum)
            {
                case var x when x <= 5:
                    block = 1.0;
                    Console.WriteLine($"{name} Fails to block any incoming damage");
                    return block;
                case var x when x <= 15:
                    block = 0.75;
                    Console.WriteLine($"{name} Blocks 25% of incoming damage");
                    return block;
                case var x when x <= 19:
                    block = 0.5;
                    Console.WriteLine($"{name} Blocks 50% of incoming damage");
                    return block;
                case var x when x == 20:
                    block = 0.0;
                    Console.WriteLine($"{name} Blocks 100% of incoming damage (Critical roll!!!)");
                    return block;
                default:
                    Console.WriteLine($"{name} block What happened? TheNum {TheNum}");
                    return block;
            }
        }
        
        //Value resets
        public void AttackReset()
        {
            attack = 0;
        }
        public void BlockReset()
        {
            block = 1;
        }
    }
}

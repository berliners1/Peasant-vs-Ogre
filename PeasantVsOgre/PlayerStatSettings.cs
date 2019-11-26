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

        public double counter;

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

        //RNG functionality
        public int RandomNumberGenerationD20()
        {
            Random random = new Random();
            return random.Next(1, 21); //random number between 1 and 20
        }
        public int RandomNumberGenerationD4()
        {
            Random random = new Random();
            return random.Next(1, 5); //random number between 1 and 4
        }

        //Attack functionality
        public double Attack()
        {
            var D20Roll = RandomNumberGenerationD20();

            switch (D20Roll)
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
                    Console.WriteLine($"{name} attack What happened? D20Roll {D20Roll}");
                    return attack;
            }

        }

        //Counterattack functionality
        public double CounterAttack(double opponentAttack)
        {
            var D4Roll = RandomNumberGenerationD4();

            switch (D4Roll)
            {
                case var x when x == 1:
                    Console.WriteLine($"Also, {name} fails to counter.");
                    return 0; //no counter attack damage
                case var x when x == 2:
                    Console.WriteLine($"Also, {name} counters back 20% of incoming {opponentAttack} damage, which is {opponentAttack * 0.20}");
                    return opponentAttack * 0.20; //20% counter attack damage
                case var x when x == 3:
                    Console.WriteLine($"Also, {name} counters back 40% of incoming {opponentAttack} damage, which is {opponentAttack * 0.40}");
                    return opponentAttack * 0.40; //40% counter attack damage
                case var x when x == 4:
                    Console.WriteLine($"Also, {name} counters back 100% of incoming {opponentAttack} damage, which is {opponentAttack * 1}");
                    return opponentAttack; //100% counter attack damage
                default:
                    Console.WriteLine($"Is this ever happening? D4Roll is {D4Roll}");
                    return 1;
            }
        }

        //Block functionality
        public double Block()
        {
            var D20Roll = RandomNumberGenerationD20();

            switch (D20Roll)
            {
                case var x when x <= 5:
                    block = 1.0;
                    Console.WriteLine($"{name} Fails to block or counter any incoming damage.");
                    return block;
                case var x when x <= 15:
                    block = 0.75;
                    Console.WriteLine($"{name} Blocks 25% of incoming damage.");
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
                    Console.WriteLine($"{name} block What happened? D20Roll {D20Roll}");
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

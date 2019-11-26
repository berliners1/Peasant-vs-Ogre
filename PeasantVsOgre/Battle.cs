using System;
using System.Collections.Generic;
using System.Text;

namespace PeasantVsOgre
{
    class Battle
    {
        ////StartFight
        //recieve both players' attributes
        //loop giving each player a chance to attack and block each round until one dies.
        public static void StartFight(PlayerStatSettings peasant, PlayerStatSettings ogre)
        {
            int round = 0;
            while (true)
            {
                if (round >= 1 && GetAttackResult(peasant, ogre) == "game over")
                {
                    Console.WriteLine("Game Over");
                    break;
                }
                if (round >= 100)
                {
                    Console.WriteLine("Yikes, it's round 100. You both just drop dead and die of boredom. Game over.");
                    break;
                }

                round++;
                Console.WriteLine("");
                Console.WriteLine($"---------ROUND {round}---------");

                Console.WriteLine("Peasant: Attack or Block?");
                var userChoice = Console.ReadLine();
                var ogreChoice = ogre.RandomNumberGenerationD20(); //Ogre is AI

                Console.WriteLine("");

                switch (userChoice)
                {
                    case var x when x == "Attack":
                        peasant.Attack();
                        peasant.BlockReset();
                        break;
                    case var x when x == "Block":
                        peasant.Block();
                        peasant.AttackReset();
                        break;
                    default:
                        Console.WriteLine("Invalid input, select again");
                        continue;
                }

                switch (ogreChoice) //Ogre is AI
                {
                    case var x when x <= 10:
                        ogre.Attack();
                        ogre.BlockReset();
                        break;
                    case var x when x > 10:
                        ogre.Block();
                        ogre.AttackReset();
                        break;
                    default:
                        Console.WriteLine("Ogre froze.");
                        continue;
                }

                if (userChoice == "Block" && ogreChoice > 10)
                {
                    Console.WriteLine("Both players chose to block, so nothing happened this round.");
                }
            }
        }

        //GetAttackResults
        public static string GetAttackResult(PlayerStatSettings peasant, PlayerStatSettings ogre) {

            //Figure out amount to block. 
            var peasantBlockVal = ogre.attack - (ogre.attack * peasant.block);
            var ogreBlockVal = peasant.attack - (peasant.attack * ogre.block);

            double ogreCounterVal = 0;
            double peasantCounterVal = 0;

            if(ogreBlockVal > 0)
            {
                Console.WriteLine("");
                ogreCounterVal = ogre.CounterAttack(peasant.attack);
            }
            if(peasantBlockVal > 0)
            {
                Console.WriteLine("");
                peasantCounterVal = peasant.CounterAttack(ogre.attack);
            }

            Console.WriteLine("");

            //calculate new player hp, factoring in amount that opponent dealt, along with amount player blocked.
            var peasanthp = peasant.hp -= (ogre.attack - peasantBlockVal) + ogreCounterVal;
            var ogrehp = ogre.hp -= (peasant.attack - ogreBlockVal) + peasantCounterVal;

            Console.WriteLine($"---ROUND RESULTS---");


            Console.WriteLine($"Peasant hp: {peasanthp} -- took {ogre.attack - peasantBlockVal + ogreCounterVal} damage, down from {(ogre.attack - peasantBlockVal + ogreCounterVal) + peasanthp}");
            Console.WriteLine($"Ogre hp: {ogrehp} -- took {peasant.attack - ogreBlockVal + peasantCounterVal} damage, down from {(peasant.attack - ogreBlockVal + peasantCounterVal) + ogrehp}");
            Console.WriteLine("-----------");
            Console.WriteLine("Press Enter for Next Round...");
            Console.ReadLine();
            Console.Clear();

            if (ogrehp <= 0 || peasanthp <= 0)
            {
                return "game over";
            }
            return "another round";
            
        }
    }
}

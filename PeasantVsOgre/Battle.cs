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
                var ogreChoice = ogre.RandomNumberGeneration(); //Ogre is AI

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

                Console.WriteLine($"---Results for round {round}---");
            }
        }

        ////GetAttackResults
        //Calculate what each player did.
        //Calculate 1 player's attacks or blocks.
        //Calculate what % to take off incoming attack, if any.
        //Output change in health for each player.
        //Check if either player fell below 0. If so end loop above by returning "game over";
        public static string GetAttackResult(PlayerStatSettings peasant, PlayerStatSettings ogre) {

            //Figure out amount to block. 
            var peasantBlockVal = ogre.attack - (ogre.attack * peasant.block);
            var ogreBlockVal = peasant.attack - (peasant.attack * ogre.block);

            //calculate new player hp, factoring in amount that opponent dealt, along with amount player blocked.
            var peasanthp = peasant.hp -= (ogre.attack - peasantBlockVal);
            var ogrehp = ogre.hp -= (peasant.attack - ogreBlockVal);

            
            /*
            Console.WriteLine("---");
            Console.WriteLine($"peasantBlockVal {peasantBlockVal}");
            Console.WriteLine($"ogreBlockVal {ogreBlockVal}");
            Console.WriteLine("---");
            Console.WriteLine($"peasant.block {peasant.block}");
            Console.WriteLine($"peasant.attack {peasant.attack}");
            Console.WriteLine("---");
            Console.WriteLine($"ogre.block {ogre.block}");
            Console.WriteLine($"ogre.attack {ogre.attack}");
            Console.WriteLine("---");
            Console.WriteLine($"peasant.hp {peasant.hp}");
            Console.WriteLine($"peasanthp after {peasanthp}");
            Console.WriteLine($"ogre.hp {ogre.hp}");
            Console.WriteLine($"ogrehp after {ogrehp}");
            Console.WriteLine("---");
            */

            Console.WriteLine($"Peasant hp: {peasanthp} -- took {ogre.attack - peasantBlockVal} damage, down from {(ogre.attack - peasantBlockVal) + peasanthp}");
            Console.WriteLine($"Ogre hp: {ogrehp} -- took {peasant.attack - ogreBlockVal} damage, down from {(peasant.attack - ogreBlockVal) + ogrehp}");
            Console.WriteLine("-----------");
            Console.WriteLine("Press Enter for Next Round...");
            Console.ReadLine();

            if (ogrehp <= 0 || peasanthp <= 0)
            {
                return "game over";
            }
            return "another round";
            
        }
    }
}

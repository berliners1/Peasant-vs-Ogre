using System;

namespace PeasantVsOgre
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Features to add:
             - Refactor. Put the input sections of StartFight into PlayerInputSettings.
             - Make an option for Ogre to be a player 2.
             - Add a "Heal" move to Player.cs
             - Make high blocks do counter attacks.
             -- In case both do blocks with counter attacks, utilize "speed" stat to cancel out the counter attack from the player with lesser speed.
             -- Add mechanism for lowering opponent speed or raising your own speed. Maybe all critical moves (getting a D20) raise yours and lower theirs.
             */

            Console.WriteLine("Peasant vs. Ogre, a text-based boss battle game.");
            
                                      //name, HP, attack, block, speed
            PlayerStatSettings peasant = new PlayerStatSettings("Peasant", 100, 0, 1, 10);
            PlayerStatSettings ogre =    new PlayerStatSettings("Ogre",    100, 0, 1, 5);

            Battle.StartFight(peasant, ogre); //primary functionality loops

            /*closing program text*/
            Console.WriteLine("");
            Console.WriteLine("-----------");
            Console.WriteLine("END PROGRAM");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PeasantVsOgre
{
    class PlayerInputSettings
    {
        //Is Ogre playable or AI?
        public static bool IsOgrePlayable()
        {
            var i = 0;
            while (i < 1)
            {
                Console.WriteLine("1 or 2 players? (Enter either '1' or '2')");
                string ogreAi = Console.ReadLine();
                switch (ogreAi)
                {
                    case var x when x == "1":
                        i = 1;
                        Console.WriteLine("1 Player only. Ogre will be AI.");
                        return true;
                    case var x when x == "2":
                        i = 1;
                        Console.WriteLine("2 players. Ogre is not AI.");
                        return false;
                    default:
                        Console.WriteLine("Invalid input. Enter just '1' or '2'.");
                        continue;
                }
            }

            return false;
        }
    }
}

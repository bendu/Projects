using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Useful things to copy when working on C#
namespace Stuff
{
    class UsefulThings
    {

        /// <summary>
        /// Seeded random object.
        /// </summary>
        /// <returns>A new random object</returns>
        public static Random seededRandom()
        {
            return new Random(Guid.NewGuid().GetHashCode());
        }


        /// <summary>
        /// Blocking delayed write line
        /// </summary>
        /// <param name="s">String to write</param>
        /// <param name="ms">Delay. Default 500ms</param>
        public static void DelayedWriteLine(string s, int ms = 500)
        {
            Thread.Sleep(500);
            Console.WriteLine(s);
        }
    }
}
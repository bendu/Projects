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

        public static int Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException();

            int f = 1;

            for (int i = 2; i <= n; i++)
            {
                f *= i;
            }

            return f;
        }


        public static string RotateString(string s, int n = 1)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("n is out of range");

            char[] build = new char[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                int nx = (i - n) >= 0 ? (i - n) : s.Length + i - n;
                build[nx] = s[i];
            }

            return new string(build);
        }

        public static T[][] Permutations<T>(T[] a)
        {
            return Permutations(a, 0);
        }

        private static T[][] Permutations<T>(T[] a, int index)
        {
            if (index >= a.Length)
            {
                // array with one empty array inside
                T[][] basecase = new T[1][];
                basecase[0] = new T[0];
                return basecase;
            }

            T[][] result  = new T[Factorial(a.Length - index)][];
            int next = 0;

            T[][] results = Permutations(a, index + 1);

            for (int j = 0; j < results.Length; j++)
            {   
                T[] someResult = results[j];
                for (int k = 0; k <= someResult.Length; k++)
                {
                    result[next] = spliceIn(someResult, k, a[index]);
                    next++;
                }
            }

            return result;
        }

        public static T[] spliceIn<T>(T[] a, int pos, T val)
        {
            T[] spliced = new T[a.Length + 1];
            for (int i = 0; i < pos; i++)
            {
                spliced[i] = a[i];
            }
            
            spliced[pos] = val;

            for (int i = pos; i < a.Length; i++)
            {
                spliced[i + 1] = a[i];
            }

            return spliced;
        }
    }
}
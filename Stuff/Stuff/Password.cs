using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stuff
{
    class Password
    {
        public static void Start()
        {
            Console.Write("Secret phrase: ");
            string secret = Console.ReadLine();

            Console.Write("Website: ");
            string website = Console.ReadLine();

            Console.Write("Login: ");
            string login = Console.ReadLine();

            string[] candidates = StringGen.Generate6Strings(login, website, secret);

            foreach (string s in candidates)
            {
                Console.WriteLine(s);
            }

            UsefulThings.DelayedWriteLine("Thanks for using Password Keeper!", 3000);
        }
    }
}

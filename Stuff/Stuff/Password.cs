using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stuff
{
    class Password
    {
        static void Main(string[] args)
        {
            UsefulThings.DelayedWriteLine("Remembering passwords is tricky", 200);
            UsefulThings.DelayedWriteLine("This should fix it");

            Console.Write("Secret phrase: ");
            string secret = Console.ReadLine();

            Console.Write("Website: ");
            string website = Console.ReadLine();

            Console.Write("Login: ");
            string login = Console.ReadLine();

            


            UsefulThings.DelayedWriteLine("Thanks for using Password Keeper!", 3000);
        }
    }
}

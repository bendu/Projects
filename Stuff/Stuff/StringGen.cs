using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

/// Deterministic string generating. Hopefully meets
/// the ever increasing password requirements
/// 
namespace Stuff
{

    class StringGen
    {
        public const int StringLength = 10;


        public static string[] Generate6Strings(string login, string site, string secret)
        {
            string[] things = {login + 2201, site + 18882, secret + 544845};
            string[][] permutations = UsefulThings.Permutations(things);

            string[] gen = new string[6];

            SHA256Managed sha = new SHA256Managed();

            for (int i = 0; i < permutations.Length; i++)
            {
                string hash = sha256_hash(permutations[i][0] + permutations[i][1] + permutations[i][2]).Substring(0, StringLength);
                char[] charArr = hash.ToCharArray();
                Capitalize(charArr);
                gen[i] = new String(charArr);
            }


            return gen;
        }


        static void Capitalize(char[] s)
        {
            for (int i = 1; i < s.Length; i += 2)
            {
                s[i] = GetModifiedKey(s[i]);
            }
        }

        [DllImport("user32.dll")]
        static extern short VkKeyScan(char c);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int ToAscii(
            uint uVirtKey,
            uint uScanCode,
            byte[] lpKeyState,
            out uint lpChar,
            uint flags
            );

        static char GetModifiedKey(char c)
        {
            short vkKeyScanResult = VkKeyScan(c);

            // a result of -1 indicates no key translates to input character
            if (vkKeyScanResult == -1)
                throw new ArgumentException("No key mapping for " + c);

            // vkKeyScanResult & 0xff is the base key, without any modifiers
            uint code = (uint)vkKeyScanResult & 0xff;

            // set shift key pressed
            byte[] b = new byte[256];
            b[0x10] = 0x80;

            uint r;
            // return value of 1 expected (1 character copied to r)
            if (1 != ToAscii(code, code, b, out r, 0))
                throw new ApplicationException("Could not translate modified state");

            return (char)r;
        }

        public static String sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}

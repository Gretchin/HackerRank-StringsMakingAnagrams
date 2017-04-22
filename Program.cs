using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringsMakingAnagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            Console.WriteLine(Anag(a, b));
        }

        //S4itaet skolko nujno udalit' simvolov 4tobi 'a' stala anagrammoi 'b'
        static int Anag(string a, string b)
        {
            StringBuilder strA = new StringBuilder(a, a.Length);
            StringBuilder strB = new StringBuilder(b, b.Length);
            int anagLength = 0;
            int i = 0;
            while (i < strA.Length)
            {
                int j = 0;
                while (j < strB.Length)
                {
                    if (strA[i] == strB[j])
                    {
                        anagLength++;
                        strA.Remove(i, 1);
                        strB.Remove(j, 1);
                        i--;
                        break;
                    }
                    else
                        j++;
                }
                i++;
            }
            return a.Length - anagLength + b.Length - anagLength;
        }
    }
}

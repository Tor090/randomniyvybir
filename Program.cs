using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace randomvybor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input symvol");
            string input = Console.ReadLine();
            if (input.Length > 12*2-1)
            {
                Console.WriteLine("Too many symvols \nInput again");
                input = Console.ReadLine();
            }
            List<char> symvols = new List<char>();
            create(symvols, input);
            List<string> comb = new List<string>();
            File.Delete("labka.txt");
            foreach (var s in AddAllFrom(symvols, symvols.Count))
                {
                comb.Add(s);
                }
            File.AppendAllLines("labka.txt", comb);
            
        }
        

        static IEnumerable<string> AddAllFrom(List<char> chars, int n)
        {
            if (n == 0)
                yield return "";
            foreach (var c in chars.ToList())
            {
                chars.Remove(c);
                foreach (var s in AddAllFrom(chars, n - 1))
                    yield return c + s;
                chars.Add(c);
            }
        }
        public static void create(List<char> a,string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if(s[i] != ',' || s[i] != ',' && s[i+1] != ',')
                a.Add(s[i]);
            }
        }
    }
}

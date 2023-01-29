using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab08
{
    class StringProcessing
    { 
        public static string str {get; set;}
        public static void DeleteSymbols()
        {
            str = Regex.Replace(str, @"[(.,/\-{};:?)]", "");
            Console.WriteLine(str);
        }
        public static void AddSymbols()
        {
            str = str.Insert(str.Length, "$");
            Console.WriteLine(str);
        }
        public static void DeleteSpace()
        {
            str = Regex.Replace(str, @"\s+", " ");
            Console.WriteLine(str);
        }
        public static void ToUpperCase()
        {
            str = str.ToUpper();
            Console.WriteLine(str);
        }
        public static void ToLowerCase()
        {
            str = str.ToLower();
            Console.WriteLine(str);
        }
    }
}

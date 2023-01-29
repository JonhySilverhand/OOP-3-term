using System;

namespace Lab08
{
    class Program
    {
        static void Main(string[] args)
        {
            Soft soft1 = new Soft("Visual Studio");
            Soft soft2 = new Soft("Brackets");
            Soft soft3 = new Soft("IntelliJ IDEA");

            User.StartWorkWithSoft(soft1);
            soft1.ShowInfo();
            soft2.ShowInfo();
            soft3.ShowInfo();
            Console.WriteLine("\n--------------------------------------\n");
            User.StartWorkWithSoft(soft2);
            soft1.ShowInfo();
            soft2.ShowInfo();
            soft3.ShowInfo();
            Console.WriteLine("\n--------------------------------------\n");
            User.StartWorkWithSoft(soft3);
            soft1.ShowInfo();
            soft2.ShowInfo();
            soft3.ShowInfo();
            Console.WriteLine("\n--------------------------------------\n");
            User.EndWorkWithSoft(soft3);
            User.UpgradeSoft(soft1, "1.3");
            User.EndWorkWithSoft(soft1);
            User.EndWorkWithSoft(soft2);
            soft1.ShowInfo();
            soft2.ShowInfo();
            soft3.ShowInfo();

            Console.WriteLine("\n--------------------------------------\n");

            string str = "Au..-d/i   R(S4).;{";
            StringProcessing.str = str;
            Action editstr = () => StringProcessing.DeleteSymbols();
            editstr += StringProcessing.AddSymbols;
            editstr += StringProcessing.DeleteSpace;
            editstr += StringProcessing.ToUpperCase;
            editstr += StringProcessing.ToLowerCase;
            editstr.Invoke();
        }
    }
}

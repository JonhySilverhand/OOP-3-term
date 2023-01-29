using System;
using Lab07;
using Lab10;

namespace Lab11
{
    public class Program
    {
        static void Main(string[] args)
        {
            Reflector.ClearFile();
            Reflector.WriteAssemblyName("Lab07.Cookie, Lab07");
            Reflector.PublicConstructors("Lab07.Cookie, Lab07");
            Reflector.PublicMethods("Lab07.Cookie, Lab07");
            Reflector.FieldsAndProperties("Lab07.Cookie, Lab07");
            Reflector.Interfaces("Lab07.Cookie, Lab07");
            Reflector.MethodsWithUserParametr("Lab07.Cookie, Lab07", "");

            Reflector.WriteAssemblyName("Lab10.Airline, Lab10");
            Reflector.PublicConstructors("Lab10.Airline, Lab10");
            Reflector.PublicMethods("Lab10.Airline, Lab10");
            Reflector.FieldsAndProperties("Lab10.Airline, Lab10");
            Reflector.MethodsWithUserParametr("Lab10.Airline, Lab10", "airaft");
            
            Reflector.WriteAssemblyName("System.Object");
            Reflector.PublicConstructors("System.Object");
            Reflector.PublicMethods("System.Object");
            Reflector.FieldsAndProperties("System.Object");
            Reflector.MethodsWithUserParametr("System.Object", "");

            Console.ForegroundColor = ConsoleColor.White;
            Reflector.Invoke("Lab11.SalesAuto", "SaleAuto");

            Console.ForegroundColor = ConsoleColor.Yellow;
            object obj = Reflector.Create("Lab11.SalesAuto");
            Console.WriteLine(obj.GetType().Name);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {

            //1. Задайте массив типа string, содержащий 12 месяцев (June, July, May, 
            //December, January ….). Используя LINQ to Object напишите запрос выбирающий 
            //последовательность месяцев с длиной строки равной n, запрос возвращающий 
            //только летние и зимние месяцы, запрос вывода месяцев в алфавитном порядке,
            //запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4-х..

            string[] months = { 
                "January", "February", "March", 
                "April", "May", "June", 
                "July", "August", "September", 
                "October", "November", "December" 
            };

            var month = months.Where(x => x.Length == 5);
            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬Months▬▬▬▬▬▬▬▬▬▬");

            foreach(string m in month)
                Console.WriteLine(m);
            Console.WriteLine("\n**************************");
            var sw = from m in months 
                         where Array.IndexOf(months, m) < 2 || Array.IndexOf(months, m) > 4 && Array.IndexOf(months, m) < 8 || Array.IndexOf(months, m) == 11
                     select m;
            Console.WriteLine("Winter and summer months\n");
            foreach(string m in sw)
                Console.WriteLine(m);
            Console.WriteLine("**************************");

            Console.WriteLine("Alphabet order\n");
            month = months.OrderBy(x => x);
            foreach(string m in month)
                Console.WriteLine(m);
            Console.WriteLine("\n**************************");

            Console.WriteLine("u and length > 4\n");
            month = months.Where(x => x.Contains('u') && x.Length > 4);
            foreach (string m in month)
                Console.WriteLine(m);

            Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            //#########################################

            //2.Создайте коллекцию List<T> и параметризируйте ее типом (классом)
            //из лабораторной №2(при необходимости реализуйте нужные интерфейсы).
            //Заполните ее минимум 10 элементами.
            List<Airline> air = new List<Airline>();
            air.Add(new Airline("Istambul", 233, "Boeing-713", "00:44", "Thursday"));
            air.Add(new Airline("Georgia", 100, "Airbus A340", "06:30", "Monday"));
            air.Add(new Airline("Romania", 178, "Boeing-777", "03:50", "Sunday"));
            air.Add(new Airline("Japan", 245, "Tu-160", "18:20", "Friday"));
            air.Add(new Airline("Norway", 222, "Boeing-777", "16:05", "Friday"));
            air.Add(new Airline("Russia", 177, "Airbus A380", "23:30", "Saturday"));
            air.Add(new Airline("Japan", 112, "Boeing-777", "03:50", "Wednesday"));
            air.Add(new Airline("Turkey", 243, "Tu-160", "02:20", "Friday"));
            air.Add(new Airline("Belarus", 269, "Airbus A350", "11:05", "Friday"));
            air.Add(new Airline("Italy", 110, "Airbus A380", "07:44", "Saturday"));

            //3.На основе LINQ сформируйте следующие запросы по вариантам.

            //1)Cписок рейсов для заданного пункта назначения
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---Fly to Japan---");
            var Air = from d in air
                      where d.Dest == "Japan" select d;
            foreach (var dest in Air)
                Console.WriteLine($"{dest.FNum}, {dest.AirT}, {dest.DTime}, {dest.DOTW}");

            //2)Список рейсов для заданного дня недели
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---Departure on Friday---");
            Air = from d in air
                  where d.DOTW == "Friday"
                  select d;
            foreach (var day in Air)
                Console.WriteLine($"{day.DTime}, {day.Dest}, {day.FNum}, {day.AirT}");

            //3)Максимальный по дню недели рейс
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n---Кол-во вылетов---\n");
            var countair = air.Where(x => x.AirT == "Boeing-777").Count();
            Console.WriteLine(countair);

            //4)Все рейсы в определенный день недели и с самым поздним временем вылета
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("---Поздний вылет---");
            var airtimedest = air.OrderBy(x => x.DTime).Where(x => x.Dest == "Japan").TakeLast(1);
            foreach (var item in airtimedest)
                Console.WriteLine(item);
            
            //5)Упорядоченные по дню и времени рейсы
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n---Упорядоченность по дню---\n");
            Air = air.OrderBy(x => x.DOTW);
            foreach(var sd in Air)
                Console.WriteLine(sd);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("---Упорядоченность по времени---");
            Air = air.OrderBy(x => x.DTime);
            foreach (var st in Air)
                Console.WriteLine(st);

            //6)Количество рейсов для заданного типа самолета
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Flights to Tu-160");
            Air = from c in air
                  where c.AirT == "Tu-160"
                  select c;
            foreach(var at in Air)
                Console.WriteLine($"{at.Dest}, {at.DOTW}, {at.DTime}, {at.FNum}, {at.AirT}");


            //4.Придумайте и напишите свой собственный запрос, в котором было
            //бы не менее 5 операторов из разных категорий: условия, проекций, 
            //упорядочивания, группировки, агрегирования, кванторов и разбиения
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n---Собственный запрос---\n");
            var str = air.OrderBy(x => x.Dest).Where(x => x.FNum > 190).Skip(2);
            foreach (var item in str)
                Console.WriteLine(item);

            //5. Придумайте запрос с оператором Join
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("---Join---");
            var airList = new List<Airline>
            {
                new Airline("Japan", 245, "Tu-160", "18:20", "Friday"),
                new Airline("Norway", 230, "АН-124", "16:05", "Friday")
            };

            var airTList = new List<Airplane>
            {
                new Airplane("Пассажирский", "Tu-160"),
                new Airplane("Грузовой", "АН-124")  
            };

            var resultair = from a in airList
                            join at in airTList on a.AirT equals at.NumberAir
                            select new { Type = at.Type, Data = a.DOTW, AirType = a.AirT };
            foreach (var item in resultair)
                Console.WriteLine(item.ToString());
        }
    }
}

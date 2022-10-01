using System;

namespace Lab02
{
    class Program
    {
        static void Main(string[] args)
        {
            Airline air1 = new Airline("Moscow", 145, "Boeing-737", "02:48", "Monday, Wendesday");
            Airline air2 = new Airline();
            Airline air3 = new Airline(178);
            Console.WriteLine(air1.ToString());
            Console.WriteLine("---------------------");
            Console.WriteLine(air2.ToString());
            Console.WriteLine("---------------------");
            Console.WriteLine(air3.ToString());
            Console.WriteLine("---------------------");
            Console.WriteLine($"air1 равен air2? - {air1.Equals(air2)}");
            Console.WriteLine($"Тип первого самолета - {air1.GetType()}");
            string airtype1 = air1.AirType;
            air1.FlightChange(out airtype1, "Airbus A340");
            Console.WriteLine($"Смена типа самолета: {airtype1}");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Class info:");
            Airline.ShowInfo();
            Console.WriteLine("----------------------------");
            var arr = new Airline[6];
            arr[0] = new Airline("Istambul", 233, "Boeing-713", "00:44", "Sunday, Thuesday, Thursday" );
            arr[1] = new Airline("Georgia", 100, "Airbus A340", "6:30", "Monday");
            arr[2] = new Airline("Romania", 178, "Boeing-777", "03:50", "Sunday");
            arr[3] = new Airline("Japan", 245, "Tu-160", "18:20", "Friday");
            arr[4] = new Airline("Norway", 222, "Airbus A350", "16:05", "Tuesday, Friday");
            arr[5] = new Airline("Russia", 177, "Airbus A380", "23:30", "Saturday");
            foreach(var air in arr)
                if(air.FNum == 245)
                    Console.WriteLine($"{air.AirT} flies to {air.Dest} on {air.DOTW}");
            //Создание и вызов анонимного типа
            var airtype = new { Type = "Boeing-777", Flight = 234 };
            Console.WriteLine($"Рейс номер {airtype.Flight} на самолете типа {airtype.Type}");





        }
    }
}

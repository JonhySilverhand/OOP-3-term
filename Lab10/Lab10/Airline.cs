using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10
{
    public class Airline
    {
        //Поля класса
        public string Destination;
        private int FlightNumber;
        public string AirType;
        private string DepartureTime;
        private string DaysOfTheWeek;
        //Поле для чтения
        public readonly int airID;
        //Поле-константа
        public const string BrandAirplane = "Ту-154";
        //Статическое поле, хранящее кол-во объектов
        public static int count;
        //----------Конструкторы----------//
        public Airline()
        {
            Console.WriteLine("Вызван конструктор по умолчанию");
            Destination = "USA";
            FlightNumber = 100;
            AirType = "Boeing-717";
            DepartureTime = "9:00";
            DaysOfTheWeek = "Monday";
            airID = GetHashCode();
            count++;
        }
        public Airline(string Destination, int FlightNumber, string AirType, string DepartureTime, string DaysOfTheWeek)
        {
            if (FlightNumber > 0 && Destination.Length != 0)
            {
                this.Destination = Destination;
                this.FlightNumber = FlightNumber;
                this.AirType = AirType;
                this.DepartureTime = DepartureTime;
                this.DaysOfTheWeek = DaysOfTheWeek;
                airID = GetHashCode();
                count++;
            }
            else
                throw new ArgumentException();
        }
        public Airline(int FlightNumber = 177, string DaysOfTheWeek = "Saturday")
        {
            Destination = "Kiev";
            AirType = "Boeing-747";
            DepartureTime = "23:34";
            this.FlightNumber = FlightNumber;
            this.DaysOfTheWeek = DaysOfTheWeek;
            airID = GetHashCode();
            count++;
        }
        //Статический конструктор(конструктор типа)
        static Airline()
        {
            count = 0;
        }

        //private Airline() { }

        public string Dest
        {
            get { return this.Destination; }
            set
            {
                if (this.Destination.Length > 0)
                    this.Destination = value;
                else
                    this.Destination = "Minsk";
            }
        }
        public int FNum
        {
            get { return this.FlightNumber; }
            private set
            {
                if (this.FlightNumber > 0)
                    this.FlightNumber = value;
                else
                    this.FlightNumber = 100;
            }
        }
        public string AirT
        {
            get { return this.AirType; }
            set
            {
                if (this.AirType.Length > 0)
                    this.AirType = value;
                else
                    this.AirType = "Boeing-737";
            }
        }
        public string DTime
        {
            get { return this.DepartureTime; }
            set
            {
                if (this.DepartureTime.Length > 0)
                    this.DepartureTime = value;
                else
                    this.DepartureTime = "01:00";
            }
        }
        public string DOTW
        {
            get { return this.DaysOfTheWeek; }
            set
            {
                if (this.DaysOfTheWeek.Length > 0)
                    this.DaysOfTheWeek = value;
                else
                    this.DaysOfTheWeek = "Monday";
            }
        }

        public void FlightChange(out string airb, string airaft)
        {
            airb = airaft;
        }
        public static void ShowInfo()
        {
            Console.WriteLine($"-----Поля класса-----\n" +
                $"->airID\n" +
                $"->Destination\n" +
                $"->FlightNumber\n" +
                $"->AirType\n" +
                $"->DepartureTime\n" +
                $"->DaysOfTheWeek\n" +
                $"-----Методы класса-----\n" +
                $"->FlightChange\n");
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                throw new NullReferenceException();

            Airline air = obj as Airline;
            return air.airID == this.airID;
        }
        public override int GetHashCode()
        {
            int Hash = (FlightNumber * Convert.ToInt32(Math.PI)) / Convert.ToInt32(Math.Pow(Math.E, 3));
            return Hash;
        }

        public override string ToString()
        {
            return $"Пункт назначения: {this.Destination}\n" +
                   $"Номер рейса: {this.FlightNumber}\n" +
                   $"Тип самолета: {this.AirType}\n" +
                   $"Время вылета: {this.DepartureTime}\n" +
                   $"Air ID: {this.airID}\n" +
                   $"Дни недели: {this.DaysOfTheWeek}\n";
        }
    }
}

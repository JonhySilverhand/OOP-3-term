using System;

namespace Lab02
{
    public partial class Airline
    {
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

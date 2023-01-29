using System;
using System.Collections.Generic;
using System.Text;

namespace Lab06
{
    class Candies
    {
        private struct CandiesSpecification
        {
            string type;
            string AmountOfSugar;
            int Weight;
            public CandiesSpecification(string type, string AmountOfSugar, int Weight)
            {
                this.type = type;
                this.AmountOfSugar = AmountOfSugar;
                this.Weight = Weight;
            }
            public void Specification()
            {
                Console.WriteLine($"Тип сладости -- {this.type}, Масса - {this.Weight}, Содержание сахара -- {this.AmountOfSugar}");
            }
        }
    }
}

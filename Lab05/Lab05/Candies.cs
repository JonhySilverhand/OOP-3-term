using System;
using System.Collections.Generic;
using System.Text;

namespace Lab05
{
    class Candies
    {
        private struct CandiesSpecification
        {
            string type;
            string AmountOfSugar;
            public CandiesSpecification(string type, string AmountOfSugar)
            {
                this.type = type;
                this.AmountOfSugar = AmountOfSugar;
            }
            public void Specification()
            {
                Console.WriteLine($"Тип сладости -- {this.type}, Содержание сахара -- {this.AmountOfSugar}");
            }
        }
    }
}

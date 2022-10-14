using System;
using System.Collections.Generic;
using System.Text;

namespace Lab06
{
    class PresentExeption : Exception
    {
        //1) Создайте иерархию классов исключений (собственных) – 3 типа и более. 
        //Сделайте наследование пользовательских типов исключений от
        //стандартных классов.Net(например, Exception, IndexOutofRange).
        public string ErrorInClass { get; private set; }
        public PresentExeption(string message, string errorInClass) : base(message)
        {
            ErrorInClass = errorInClass;
        }
    }
    class SugarCostExeption : PresentExeption
    {
        public int SugarCost { get; private set; }
        public SugarCostExeption(string message, string errorInClass, int sugarcost) : base(message, errorInClass)
        {
            SugarCost = sugarcost;
        }
    }
    class ConfectionaryWeightExeption : PresentExeption
    {
        public int Weight { get; private set; }
        public ConfectionaryWeightExeption(string message, string errorInClass, int weight) : base(message, errorInClass)
        {
            Weight = weight;
        }
    }

}

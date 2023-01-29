using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10
{
    public class Airplane
    {
        public string NumberAir { get; set; }
        public string Type { get; set; }
        private Airplane() { }
        public Airplane(string type, string numair)
        {
            Type = type;
            NumberAir = numair;
        }
    }
}

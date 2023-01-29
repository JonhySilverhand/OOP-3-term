using System;
using System.Collections.Generic;
using System.Text;

namespace Lab11
{
    class SalesAuto
    {
        public string Name { get; set; }
        public SalesAuto() { }
        public void SaleAuto(List<string> modelAuto)
        {
            foreach (var mauto in modelAuto)
                Console.WriteLine($"Продан автомобиль марки {mauto}");
        }
    }
}

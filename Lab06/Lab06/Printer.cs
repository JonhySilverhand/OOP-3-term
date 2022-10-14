using System;
using System.Collections.Generic;
using System.Text;

namespace Lab06
{
    class Printer
    {
        public void IAmPrinting(Confectionery confectionery)
        {
            Console.WriteLine(confectionery.ToString());
        }
    }
}

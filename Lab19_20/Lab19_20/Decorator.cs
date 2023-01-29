using System;
using System.Collections.Generic;
using System.Text;

namespace Lab19_20
{
    public class Decorator1 : Edition
    {
       protected Edition edition { get; set; }
       public Decorator1(string name, DateTime date, float cost, Edition ed) : base(name, date, cost)
       {
            edition = ed;
       }
    }

    public class Decorator2 : Decorator1
    {
        public Decorator2(string authorName, string name, DateTime date, float cost, Edition ed) : base(ed.Name + authorName, date, cost, ed)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Lab09
{
    public class InternetResource
    {
        public string Name { get; set; }
        public InternetResource() { }
        public InternetResource(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"Наименование: {Name}";
        }
    }
}

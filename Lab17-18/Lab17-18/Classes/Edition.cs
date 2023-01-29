using System;
using System.Collections.Generic;
using System.Text;

namespace Lab17_18
{
    public class Edition
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public float Cost { get; set; }
        public int Count { get; set; }
        public Edition()
        {
            Name = "";
            Date = new DateTime();
            Cost = 0.0f;
            Count = 0;
        }
        public Edition(string name, DateTime date, float cost)
        {
            Name = name;
            Date = date;
            Cost = cost;
            Count++;
        }
        public override bool Equals(object obj)
        {
            var edit = obj as Edition;
            if (edit.Name == this.Name && edit.Date == this.Date && edit.Cost == this.Cost)
                return true;
            else
                return false;
        }
        public override string ToString()
        {
            return $"Название: {Name}\nГод издания: {Date.Year}\nСтоимость: {Cost}руб\n";
        }
        public override int GetHashCode()
        {
            return base.GetHashCode()%1000;
        }
    }

    public class Author
    {
        public string Name { get; set; }
        public Author (string name)
        {
            Name = name;
        }
    }
}

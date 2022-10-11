using System;
using System.Collections.Generic;
using System.Text;


namespace Lab05
{
    public class Present
    {
        public List<Confectionery> list { get; set; }
        private int Weight;
        public int CountInPresent { get; set; }
        public Present()
        {
            Weight = 1000;
            CountInPresent = 0;
            list = new List<Confectionery>();
        }
        public Present(int weight)
        {
            Weight = weight;
            CountInPresent = 0;
            list = new List<Confectionery>();
        }
        public Present(int weight, List<Confectionery> list)
        {
            Weight = weight;
            CountInPresent = list.Count;
            this.list = list;
        }
        public void AddElem(Confectionery candy)
        {
            list.Add(candy);
            CountInPresent++;
        }
        public void DeleteElem(Confectionery candy)
        {
            if (!list.Contains(candy))
                throw new ArgumentException();
            list.Remove(candy);
            CountInPresent--;

        }
        public void ShowList()
        {
            Console.WriteLine($"--------------\nДетский подарок\n" +
                $"Количество конфет в подарке: {CountInPresent}");

            foreach (var l in list)
            {
                Console.WriteLine(l.ToString());
            }
        }
    }
}

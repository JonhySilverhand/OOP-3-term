using System;
using System.Collections.Generic;
using System.Linq;


namespace Lab06
{
    public class Present
    {
        private readonly int _weight;
        public List<Confectionery> Presentlist { get; set; }
        public int CurrentWeight { get; private set; }
        public int CountInPresent { get; set; }
        public Present()
        {
            _weight = CurrentWeight = 1000;
            CountInPresent = 0;
            Presentlist = new List<Confectionery>();
        }
        public Present(int weight)
        {
            _weight = CurrentWeight = weight;
            CountInPresent = 0;
            Presentlist = new List<Confectionery>();
        }
        public Present(int weight, List<Confectionery> list)
        {
            _weight = weight;
            CurrentWeight = _weight - list.Sum(item => item.Weight);
            CountInPresent = list.Count;
            Presentlist = list;
        }
        public void AddElem(Confectionery candy)
        {
            if (candy.Weight > CurrentWeight)
                throw new ArgumentException();

            Presentlist.Add(candy);
            CurrentWeight -= candy.Weight;
            CountInPresent++;
        }
        public void DeleteElem(Confectionery candy)
        {
            if (!Presentlist.Contains(candy))
                throw new ArgumentException();
            Presentlist.Remove(candy);
            CurrentWeight += candy.Weight;
            CountInPresent--;
           
        }
        public void ShowList()
        {
            Console.WriteLine($"--------------\nДетский подарок\n" +
                $"Количество конфет в подарке: {CountInPresent}\n" + 
                $"Масса подарка: {_weight}\n" + 
                $"Текущая масса: {CurrentWeight}\n");

            foreach (var l in Presentlist)
            {
                Console.WriteLine(l.ToString());
            }
        }
    }
}

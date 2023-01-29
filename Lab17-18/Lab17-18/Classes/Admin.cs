using System;
using System.Collections.Generic;
using System.Text;

namespace Lab17_18
{
    public class Admin
    {
        private List<Edition> editions;
        public Admin()
        {
            editions = new List<Edition>();
        }
        public void AddEdition(Edition ed)
        {
            editions.Add(ed);
        }
        public void DelEdition(Edition ed)
        {
            foreach (var e in editions)
            {
                if (e.Equals(ed))
                {
                    editions.Remove(e);
                }
                if (editions.Count == 0)
                    break;
            }
        }
        public void ShowListEdition()
        {
            int i = 0;
            foreach (var ed in editions)
            {
                Console.WriteLine($"{i}\n{ed.ToString()}");
                i++;
            }
        }
    }
}
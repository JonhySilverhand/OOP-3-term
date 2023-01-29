using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab17_18
{
    public class Reader
    {
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public int ID { get; set; }
        private List<Subscription> ListOfSub;
        public Reader(string name, string db, int id)
        {
            Name = name;
            DateOfBirth = db;
            ID = id;
            ListOfSub = new List<Subscription>();
        }
        public void MakeSub(Edition ed, DateTime subtime)
        {
            Payment payment = new Payment(subtime, ed.Cost);
            Subscription sub = new Subscription(ed, subtime, payment);
            ListOfSub.Add(sub);
        }
        public void DelSub(Edition ed)
        {
            bool flag = false;
            Subscription subscription = null;
            foreach (var i in ListOfSub)
            {
                if (i.edition.Equals(ed))
                {
                    subscription = i;
                    flag = true;
                }
            }

            if (!flag)
                Console.WriteLine("Данной подписки не существует в вашем каталоге");
            else
                ListOfSub.Remove(subscription);

        }

        public void ShowListOfSub()
        {
            if(ListOfSub.Count == 0)
                Console.WriteLine("Список подписок пуст\n");
            else
                foreach (var s in ListOfSub)
                {
                    Console.WriteLine(s.ToString());
                }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Lab19_20
{
    public class Reader : ISubState
    {
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public int ID { get; set; }
        private List<SubscriptionOnline> ListOfSubOnline;
        private List<SubscriptionOffline> ListOfSubOffline;
        public Reader(string name, string db, int id)
        {
            Name = name;
            DateOfBirth = db;
            ID = id;
            ListOfSubOnline = new List<SubscriptionOnline>();
            ListOfSubOffline = new List<SubscriptionOffline>();
        }
        public void Ordered(SubscriptionOnline subonl) => Console.WriteLine($"Подписка на издание {subonl.edition.Name} зарезервирована");
        public void Paid(SubscriptionOnline subonl) => Console.WriteLine($"Подписка на издание {subonl.edition.Name} оплачена");
        public void MakeSub(Edition ed, DateTime subtime, bool key, ICreateSub sub1)
        {
            Payment payment = new Payment(subtime, ed.Cost);
            if(key)
            {
                SubscriptionOnline sub = new SubscriptionOnline(ed, subtime, payment);
                ListOfSubOnline.Add(sub);
            }
            else
            {
                SubscriptionOffline suboffline = new SubscriptionOffline(ed, subtime, payment);
                ListOfSubOffline.Add(suboffline);
            }
            sub1.CreateSubOnline();
        }
        public void MakeSub2(Edition ed, DateTime subtime, bool key, ICreateSub sub1)
        {
            Payment payment = new Payment(subtime, ed.Cost);
            if (key)
            {
                SubscriptionOnline sub = new SubscriptionOnline(ed, subtime, payment);
                Ordered(sub);
                Paid(sub);
                ListOfSubOnline.Add(sub);
            }
            else
            {
                SubscriptionOffline suboffline = new SubscriptionOffline(ed, subtime, payment);
                ListOfSubOffline.Add(suboffline);
            }
            sub1.CreateSubOnline();
        }
        public void DelSub(Edition ed)
        {
            bool flag1 = false;
            bool flag2 = false;
            SubscriptionOnline subscriptiononl = null;
            SubscriptionOffline subscriptionoff = null;
            foreach (var i in ListOfSubOnline)
            {
                if (i.edition.Equals(ed))
                {
                    subscriptiononl = i;
                    flag1 = true;
                }
            }
            foreach (var i in ListOfSubOffline)
            {
                if (i.edition.Equals(ed))
                {
                    subscriptionoff = i;
                    flag2 = true;
                }
            }

            if (!flag1 || !flag2)
                Console.WriteLine("Данной подписки не существует в вашем каталоге");
            else if(flag1)
                ListOfSubOnline.Remove(subscriptiononl);
            else if(flag2)
                ListOfSubOffline.Remove(subscriptionoff);

        }

        public void ShowListOfSub()
        {
            if (ListOfSubOnline.Count == 0)
                Console.WriteLine("Список подписок пуст\n");
            else
                foreach (var s in ListOfSubOnline)
                {
                    Console.WriteLine(s.ToString());
                }
        }
    }
}

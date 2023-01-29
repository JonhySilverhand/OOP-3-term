using System;
using System.Collections.Generic;
using System.Text;

namespace Lab19_20
{
    public interface ICreateSub
    {
        public void CreateSubOnline();
    }
    //Паттерн State (состояние объектов - сохраненный, редактируемый и т.п.)
    public interface ISubState
    {
        void Ordered(SubscriptionOnline subscription);
        void Paid(SubscriptionOnline subscription);
    }
    public class SubscriptionOnline : ICreateSub
    {
        public Edition edition { get; set; }
        public Payment Payment { get; set; }
        public DateTime subtime { get; set; }
        public SubscriptionOnline()
        {
            edition = null;
            Payment = null;
            subtime = DateTime.Now;
        }
        public SubscriptionOnline(Edition ed, DateTime time, Payment payment)
        {
            edition = ed;
            subtime = time;
            Payment = payment;
        }
        public void CreateSubOnline()
        {
            Console.WriteLine("---Online подписка оформлена!---");
        }
        public override string ToString()
        {
            return $"--------Online Subscription----------\n" +
                   $"--------Издание--------\n{edition}\nВремя окончания подписки: {subtime.Date.Day}.{subtime.Date.Month}.{subtime.Date.Year}\nЧек: {Payment.ToString()}" +
                   $"--------------------------------\n";
        }
        public ISubState State { get; set; }

        public SubscriptionOnline(ISubState ss)
        {
            State = ss;
        }

        public void Ordered()
        {
            State.Ordered(this);
        }
        public void Paid()
        {
            State.Paid(this);
        }
    }

    public interface ICreateSubOff
    {
        public void CreateSubOffline();
    }
    public class SubscriptionOffline : ICreateSubOff
    {
        public Edition edition { get; set; }
        public Payment Payment { get; set; }
        public DateTime subtime { get; set; }
        public SubscriptionOffline()
        {
            edition = null;
            Payment = null;
            subtime = DateTime.Now;
        }
        public SubscriptionOffline(Edition ed, DateTime time, Payment payment)
        {
            edition = ed;
            subtime = time;
            Payment = payment;
        }
        public void CreateSubOffline()
        {
            Console.WriteLine("---Offline подписка оформлена!---");
        }
        public override string ToString()
        {
            return $"---------Offline Subscription---------\n" +
                   $"--------Издание--------\n{edition}\nВремя окончания подписки: {subtime.Date.Day}.{subtime.Date.Month}.{subtime.Date.Year}\nЧек: {Payment.ToString()}" +
                   $"--------------------------------\n";
        }
    }
}

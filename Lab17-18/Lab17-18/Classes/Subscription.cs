using System;
using System.Collections.Generic;
using System.Text;

namespace Lab17_18
{
    public class Subscription
    {
        public Edition edition { get; set; }
        public Payment Payment { get; set; }
        public DateTime subtime { get; set; }
        public Subscription(Edition ed, DateTime time, Payment payment)
        {
            edition = ed;
            subtime = time;
            Payment = payment.Clone() as Payment;
        }
        public override string ToString()
        {
            return $"--------------------------------\n" +
                   $"--------Издание--------\n{edition}\nВремя окончания подписки: {subtime.Date.Day}.{subtime.Date.Month}.{subtime.Date.Year}\nЧек: {Payment.ToString()}" +
                   $"--------------------------------\n";
        }
    }
}

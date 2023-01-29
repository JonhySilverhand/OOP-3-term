using System;
using System.Collections.Generic;
using System.Text;

namespace Lab17_18
{
    public class Payment : Prototype
    {
        public DateTime Date { get; set; }
        public float Cost { get; set; }
        public int NumOfOrder { get; set; }
        public Payment() : base()
        {
            Date = DateTime.Now;
            Cost = 0;
            NumOfOrder = 0;
        }
        public Payment(DateTime subtime, float total) : base()
        {
            Date = subtime;
            Cost = total;
            NumOfOrder = GetHashCode();
        }
        public override string ToString()
        {
            return $"\n--------------------------------\n" +
                   $" Номер заказа: {NumOfOrder};\n Дата оформления подписки: {Date};\n Стоимость подписки: {Cost};\n" +
                   $"--------------------------------\n";
        }
        public override Prototype Clone()
        {
            Payment pay = new Payment(DateTime.Now, Cost);
            return pay;
        }
    }
}

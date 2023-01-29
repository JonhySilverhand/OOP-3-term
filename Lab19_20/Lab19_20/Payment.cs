using System;
using System.Collections.Generic;
using System.Text;

namespace Lab19_20
{
    public class Payment
    {
        public DateTime Date { get; set; }
        public float Cost { get; set; }
        public int NumOfOrder { get; set; }
        public Payment()
        {
            Date = DateTime.Now;
            Cost = 0;
            NumOfOrder = 0;
        }
        public Payment(DateTime subtime, float total)
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
    }
}
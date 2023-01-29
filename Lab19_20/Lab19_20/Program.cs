using System;

namespace Lab19_20
{
    class Program
    {
        static void Main(string[] args)
        {
            //Adapter
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n-----Adapter-----\n");
            Edition ed1 = new Edition();
            Reader reader1 = new Reader("Черный", "01.06.1993", 1);
            SubscriptionOnline sub1 = new SubscriptionOnline();
            reader1.MakeSub(ed1, new DateTime(1998, 3, 27), true, sub1);
            SubscriptionOffline sub2 = new SubscriptionOffline();
            Adapter adapter = new Adapter(sub2);
            reader1.MakeSub(ed1, new DateTime(2023, 3, 2), false, adapter);
            //Decorator
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n-----Decorator-----\n");
            Edition ed2 = new Edition("Мастер и Маргарита", new DateTime(1966, 1, 1), 23);
            ed2 = new Decorator2(" Михаил Булгаков", "Мастер и Маргарита", new DateTime(1966, 1, 1), 23, ed2);
            Console.WriteLine(ed2.ToString());

            //State
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----State-----\n");
            reader1.MakeSub2(ed2, new DateTime(2022, 3, 17), true, sub1);

            //Command
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n-----Command-----\n");
            Admin admin = new Admin();
            admin.SetCommand(new EditionOnCommand(ed2));
            admin.AddNewEdition();
            admin.CancelEdition();
            //Mediator
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n-----Mediator-----\n");
            System sus = new System();
            User user = new NotifiedReader(sus);
            sus.Reader = user;
            user.Send("Ваш заказ сформирован и готов к оплате");
           
        }
    }
}

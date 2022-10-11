using System;

namespace Lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Написать демонстрационную программу, в которой создаются объекты различных классов.
             *Поработать с объектами через ссылки на абстрактные классы и интерфейсы. 
             *В этом случае для идентификации типов объектов использовать операторы is или as */
            Caramel caramel1 = new Caramel("Карамель", "Кремка");
            Cookie cookie1 = new Cookie("ChocoPie");
            Confectionery caramel2 = new Caramel("Карамель", "Барбарис");
            IBuyConfectionery caramel3 = new Caramel("Карамель", "ButterMilk");
            if(caramel1 is Caramel)
            {
                Console.WriteLine("caramel1 это карамель");
            }
            if (caramel2 is Caramel)
            {
                Console.WriteLine("caramel2 это карамель");
            }
            if (caramel3 is Caramel)
            {
                Console.WriteLine("caramel3 это карамель");
            }
            if((caramel1 as Confectionery) != null)
            {
                Console.WriteLine("caramel1 преобразована в кондитерское изделие");
            }

            caramel1.GetConfectionary();
            caramel3.GetConfectionary();
            caramel2.GetType();
            caramel1.BuyConfectionary();
            cookie1.GetConfectionary();

            Console.WriteLine("-------------------------------------");

            var caramel = new Caramel("Барбарис", "Карамель");
            var choco = new ChocolateCandy("Алёнка", "Конфета");
            var cookie = new Cookie("ChocoPie");
            var boxofchoco = new BoxOfChocolates("Merci");

            var confets = new Confectionery[4];
            var print = new Printer();

            confets[0] = caramel;
            confets[1] = choco;
            confets[2] = cookie;
            confets[3] = boxofchoco;

            foreach(var candies in confets)
            {
                print.IAmPrinting(candies);
            }
        }
    }
}

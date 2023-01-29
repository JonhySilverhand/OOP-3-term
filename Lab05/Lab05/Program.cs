using System;
using System.Collections.Generic;

namespace Lab05
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Confectionery> list = new List<Confectionery>() {new Caramel(), new Cookie(), new ChocolateCandy(), new Cookie(), new Caramel() };
            List<Confectionery> list1 = new List<Confectionery>();
            Confectionery candy = new Candy("Столичная", 23);
            Confectionery candy1 = new Candy("Алёнка", 25);
            Confectionery choco = new ChocolateCandy("Аэрофлот", "Шоколадная", 52);
            Confectionery caramel = new Caramel("Roshen", "Карамелька", 40);
            Confectionery cookie = new Cookie("Печенюшка", 11);
            Confectionery boxchoco = new BoxOfChocolates("Merci", 310);
            Cookie cookie1 = new Cookie("ChocoPie", 20);
            Present present = new Present(500, list);
            present.AddElem(candy);
            present.AddElem(candy1);
            present.AddElem(choco);
            present.AddElem(caramel);
            present.AddElem(cookie);
            present.AddElem(cookie1);
            present.AddElem(boxchoco);
            present.ShowList();
            present.DeleteElem(candy1);
            present.ShowList();

            foreach (var item in PresentController.FindItemsBySugar(present, 10, 400))
                Console.WriteLine(item.ToString());

            Present present1 = new Present(1060);
            PresentController.CreatePresentText(present1);
            present1.ShowList();

            Present present2 = new Present(900);
            PresentController.CreatePresentJson(present2);
            present2.ShowList();
        }
    }
}

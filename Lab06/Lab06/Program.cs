using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lab06
{
    class Program
    {
        static void Main(string[] args)
        {

            //Confectionery candy = new Candy("Столичная", 23);
            //Confectionery candy1 = new Candy("Алёнка", 25);
            //Confectionery choco = new ChocolateCandy("Аэрофлот", "Шоколадная", 52);
            //Confectionery caramel = new Caramel("Roshen", "Карамелька", 40);
            //Confectionery cookie = new Cookie("Печенюшка", 11);
            //Confectionery boxchoco = new BoxOfChocolates("Merci", 310);
            //Cookie cookie1 = new Cookie("ChocoPie", 20);
            //Present present = new Present(500);
            //present.AddElem(candy);
            //present.AddElem(candy1);
            //present.AddElem(choco);
            //present.AddElem(caramel);
            //present.AddElem(cookie);
            //present.AddElem(cookie1);
            //present.AddElem(boxchoco);
            //present.ShowList();
            //present.DeleteElem(candy1);
            //present.ShowList();

            //foreach (var item in PresentController.FindItemsBySugar(present, 10, 400))
            //    Console.WriteLine(item.ToString());

            //Present present1 = new Present(1060);
            //PresentController.CreatePresentText(present1);
            //present1.ShowList();

            //Present present2 = new Present(900);
            //PresentController.CreatePresentJson(present2);
            //present2.ShowList();


            //2) Смоделируйте и обработайте как минимум пять различных
            //   исключительных ситуаций на основе своих и стандартных исключений.
            //   Например, не позволять при инициализации объектов передавать неверные данные, 
            //   обрабатывать ошибки при работе с памятью и ошибки
            //   работы с файлами, деление на ноль, неверный индекс, нулевой указательи т. д
            try
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Confectionery candy = new Candy("Столичная", 600, -300);
            }
            catch (SugarCostExeption e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine($"Wrong value: {e.SugarCost}");
                Console.WriteLine($"Error creating class: {e.ErrorInClass}");
            }
            Console.WriteLine("\n---------------------------------------------------\n");
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Confectionery choco = new ChocolateCandy("Аэрофлот", 52, 100);
            }
            catch (ConfectionaryWeightExeption e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine($"Wrong weight: {e.Weight}");
                Console.WriteLine($"Error creating class: {e.ErrorInClass}");
            }
            Console.WriteLine("\n---------------------------------------------------\n");
            //3) В конце поставьте универсальный обработчик catch.
            try
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Cookie cookie = new Cookie("Печенюшка", 2220, 197);
            }
            catch
            {
                Console.WriteLine(" Wrong data!");
            }
            //4) Используйте классический вид try-catch-finally
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Present present = new Present(200);
                Confectionery boxchoco = new BoxOfChocolates("Merci", 310, 700);
                present.AddElem(boxchoco);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                Logger.WriteLogFileConsole(e, true);
            }
            finally
            {
                Console.WriteLine("finaly");
            }
            
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine();
            Present present2 = new Present(1000);
            try
            {
                PresentController.CreatePresentJson(present2);
            }
            catch (Exception ex)
            {
                Logger.WriteLogFileConsole(ex, true);
                Logger.WriteLogFileConsole(ex);
            }
            //7) Добавьте код в одной из функций макрос Assert. Объясните что он
            //   проверяет, как будет выполняться программа в случае не выполнения
            //   условия.Объясните назначение Assert
            //Confectionery caramel = new Caramel("Roshen", 40, 1);
            //Debug.Assert(caramel.Weight > 8, "Масса не может быть менее 8 грамм");
        }
    }
}

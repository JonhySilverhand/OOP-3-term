using System;

namespace Lab07
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Добавьте обработку исключений c finally
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--------------------Stack int string--------------------");
            try
            {
                Stack<string> stack = new Stack<string>();
                Console.WriteLine("Add Audi RS-4, Mercedes-Benz E63s, Volkswagen Passat B3,...");
                stack.Push("Audi RS-4");
                stack.Push("Mercedes-Benz E63s");
                stack.Push("Volkswagen Passat B3");
                Console.WriteLine($"Всего автомобилей в салоне: {stack.list.Count}");
                Console.WriteLine();
                Console.WriteLine($"Продаем авто: {stack.Peek()}");
                stack.Pop();
                Console.WriteLine($"Всего автомобилей в салоне: {stack.list.Count}");
                Console.WriteLine();
                Console.WriteLine("Add Nissan GTR-35, Toyota Supra MK4,...");
                stack.Push("Nissan GTR-35");
                stack.Push("Toyota Supra MK4");
                Console.WriteLine($"Всего автомобилей в салоне: {stack.list.Count}");
                Console.WriteLine();
                stack.Push("Subaru WRX");
                stack.Push("Audi RS-7");
                stack.Pop();
                stack.Pop();
                Console.WriteLine("--------Car List--------");
                stack.CheckList();
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                Console.WriteLine("Finally");
            }

            //3. Проверьте использование обобщения для стандартных типов данных
            //(в качестве стандартных типов использовать целые, вещественные и т.д.). 
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--------------------Stack int type--------------------");
            Stack<int> stack3 = new Stack<int>();
            stack3.Push(1);
            stack3.Push(12);
            stack3.Push(37);
            stack3.Push(54);
            stack3.CheckList();
            Console.WriteLine("--------------------Stack Cookie type--------------------");
            Stack<Cookie> stack4 = new Stack<Cookie>();
            stack4.Push(new Cookie("ChocoPie"));
            stack4.Push(new Cookie("К чаю"));
            stack4.Push(new Cookie("Шахматное"));
            stack4.Push(new Cookie("Мариэрта"));
            stack4.CheckList();
            Json.WriteList(stack4);
            Stack<Cookie> test = new Stack<Cookie>();
            Json.CreatePresentJson(test);
            Console.WriteLine("----------Deserialization----------");
            test.CheckList();
        }
    }
}

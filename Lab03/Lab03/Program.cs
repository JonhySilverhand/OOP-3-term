using System;

namespace Lab03
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("-----------Stack-------------");
                Stack stack = new Stack();
                Stack stack1 = new Stack();
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
                Console.WriteLine("--------Car List--------");
                stack.CheckList();
                Console.WriteLine("-------------------------------");
                stack.Pop();
                stack.Pop();
                stack.Pop();
                

               
                stack.CheckList();
                Console.WriteLine("-------------------------------");
                /////////////////////////////////////////////////////
                /////////////////////////////////////////////////////
                Console.WriteLine("Перегрузка +");
                (stack + "AleksandraNord").CheckList();
                Console.WriteLine("Перегрузка --");
                (stack--).CheckList();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Перегрузка true");
                if(stack)
                    Console.WriteLine("True");
                else
                    Console.WriteLine("False");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("First stack");
                stack.CheckList();
                Console.WriteLine("Third stack");
                (stack > stack1).CheckList();
                Console.WriteLine("--------------------------------");
                Console.WriteLine($"Конкатенация {StatisticOperation.ConcatString(stack)}");
                Console.WriteLine($"Количество элементов стека: {StatisticOperation.CountOfElements(stack)}");
                Console.WriteLine($"Самая длинная строка в стеке: {StatisticOperation.MaxString(stack)}");
                Console.WriteLine($"Самая короткая строка в стеке: {StatisticOperation.MinString(stack)}");
                Console.WriteLine($"Средний элемент стека: {StatisticOperation.MidlleElem(stack)}");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("-----------------------------");
            Stack.Production prod1 = new Stack.Production
            {
                OrganisationName = "ITechArt"
            };
            Stack.Production prod2 = new Stack.Production("EPAM");

            Stack.Developper dev1 = new Stack.Developper
            {
                Name = "Vladislav",
                Department = "IT"
            };
            Stack.Developper dev2 = new Stack.Developper("Natalya", "IT");

        }
    }
}

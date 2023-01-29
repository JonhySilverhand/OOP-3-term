using System;
using System.Collections.Generic;

namespace Lab17_18
{
    public class Program
    {
        static void Main(string[] args)
        {
            EditionFactory factory = new EditionFactory();
            AuthorsEdition authorsEdition = new AuthorsEdition(factory, "Гоголь Н.В", "Мертвые души", new DateTime(1842, 8, 13), 8.96f);
            Admin admin = new Admin();
            Console.WriteLine($"{authorsEdition.ToString()}");
            List<Edition> listed = new List<Edition>()
            {
                new Edition("Властелин колец", new DateTime(1955, 7, 29), 65.87f),
                new Edition("Гордость и предубеждение", new DateTime(1813, 1, 28), 45.27f),
                new Edition("Убить пересмешника", new DateTime(1960, 7, 11), 71.24f),
                new Edition("Алиса в стране чудес", new DateTime(1865, 2, 5), 30.00f),
                new Edition("Зеленая миля", new DateTime(1999, 11, 18), 22.52f),
                new Edition("Темная башня", new DateTime(2004, 4, 26), 28.00f),
            };
            foreach (var lib in listed)
            {
                admin.AddEdition(lib);
            }
            admin.ShowListEdition();

            List<Reader> readers = new List<Reader>();
            Reader reader1 = new Reader("Русак Н.А", "21.12.2003", 1);
            Reader reader2 = new Reader("Авдеева В.Д", "23.09.2003", 2);
            Reader reader3 = new Reader("Климович А.С", "26.10.2003", 3);
            Reader reader4 = new Reader("Север А.С", "09.01.2001", 4);
            readers.Add(reader1);
            readers.Add(reader2);
            readers.Add(reader3);
            readers.Add(reader4);
            bool exit = true;
            Random r = new Random();
            int ri = r.Next(0, 4);
            Console.WriteLine($"-----------------Личный кабинет {readers[ri].Name}-----------------");
            while (exit)
            {
                Console.WriteLine("1 - Просмотреть список литературы\n" +
                                  "2 - Добавить подписку\n" +
                                  "3 - Удалить подписку\n" +
                                  "4 - Просмотр моих подписок\n" +
                                  "5 - Выход из личного кабинета");
                int option = Int32.Parse(Console.ReadLine());
                switch(option)
                {
                    case 1:
                        Console.WriteLine("-----Список литературы-----");
                        admin.ShowListEdition();
                        break;
                    case 2:
                        Console.WriteLine("Введите номер издания: ");
                        int index = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Введите длительность подписки: ");
                        DateTime duration = new DateTime();
                        duration = DateTime.Parse(Console.ReadLine());
                        readers[ri].MakeSub(listed[index], duration);
                        break;
                    case 3:
                        Console.WriteLine("Введите номер издания:");
                        index = Int32.Parse(Console.ReadLine());
                        readers[ri].DelSub(listed[index]);
                        break;
                    case 4:
                        Console.WriteLine("----Список подписок----");
                        readers[ri].ShowListOfSub();
                        break;
                    case 5:
                        exit = false;
                        return;
                    default:
                        Console.WriteLine("Wrong input!");
                        break;
                }
            }

        }
    }
}

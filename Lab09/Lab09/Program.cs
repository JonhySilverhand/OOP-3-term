using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Lab09
{
    class Program
    {
        static void Main(string[] args)
        {
            First();
            Second();
            Third();
        }

        private static void First()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("First");
            var internetCollection = new InternetResourceCollections<InternetResource>();
            var enotherCollection = internetCollection;
            var inet = new InternetResource();
            var arr = new InternetResource[5];
    
            internetCollection.Add(new InternetResource("pravo.by"));
            internetCollection.Add(new InternetResource("portal.by"));
            internetCollection.Add(new InternetResource("diskstation.by"));
            internetCollection.PrintList();
            internetCollection.Insert(1, inet);
            Console.WriteLine(internetCollection.Contains(inet));
            Console.WriteLine(internetCollection.IndexOf(inet));
            internetCollection.PrintList();
            internetCollection.Remove(inet);
            internetCollection.RemoveAt(0);
            Console.WriteLine(internetCollection[0]);

            internetCollection.CopyTo(arr, 2);
            foreach(var i in arr)
                Console.Write($"{i} ");
            Console.WriteLine();

            internetCollection.PrintList();
            internetCollection.Clear();
            internetCollection.PrintList();

            Console.WriteLine(internetCollection.Equals(enotherCollection));
        }
        /*2. Создайте универсальную коллекцию в соответствии с вариантом задания и 
             заполнить ее данными встроенного типа .Net (int, char,…).
             a. Выведите коллекцию на консоль
             b. Удалите из коллекции n последовательных элементов
             c. Добавьте другие элементы (используйте все возможные методы 
             добавления для вашего типа коллекции). 
             d. Создайте вторую коллекцию (из таблицы выберите другой тип 
             коллекции) и заполните ее данными из первой коллекции.
             e. Выведите вторую коллекцию на консоль. В случае не совпадения 
             количества параметров (например, LinkedList<T> и Dictionary<Tkey, 
             TValue>), при нехватке - генерируйте ключи, в случае избыточности –
             оставляйте TValue.
             f. Найдите во второй коллекции заданное значение.*/
        private static void Second()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Second");
            var universalCollection = new ConcurrentDictionary<string, int>();
            var enotherCollection = new Dictionary<string, int>();

            universalCollection.TryAdd("A", 12);
            universalCollection.GetOrAdd("B", 12);
            universalCollection.TryAdd("C", 12);
            foreach(var keyValuePair in universalCollection)
                Console.WriteLine($"key - {keyValuePair} , value - {keyValuePair.Value}");

            int tmp;
            universalCollection.TryRemove("A", out tmp);
            Console.WriteLine(tmp);
            foreach (var keyValuePair in universalCollection)
                enotherCollection.Add(keyValuePair.Key, keyValuePair.Value);
            foreach (var keyValuePair in universalCollection)
                Console.WriteLine($"key - {keyValuePair} , value - {keyValuePair.Value}");

            Console.WriteLine(enotherCollection.ContainsValue(12));
        }
        /*3. Создайте объект наблюдаемой коллекции ObservableCollection<T>. Создайте 
             произвольный метод и зарегистрируйте его на событие CollectionChange. 
             Напишите демонстрацию с добавлением и удалением элементов. В качестве 
             типа T используйте свой класс из таблицы.*/
        public static void Third()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Third");
            var internetCollections = new ObservableCollection<InternetResource>();
            internetCollections.CollectionChanged += SayChange;

            internetCollections.Add(new InternetResource("portal.by"));
            internetCollections.Add(new InternetResource("diskstation.by"));
            internetCollections.Add(new InternetResource("gor.by"));

            internetCollections.RemoveAt(2);
        }
        private static void SayChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                Console.WriteLine("|Add comlete|");
            else if (e.Action == NotifyCollectionChangedAction.Remove) Console.WriteLine("|Remove complete|");
        }
    }
}

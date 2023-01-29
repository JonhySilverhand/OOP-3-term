using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using System.Numerics;
using System.Diagnostics;
using System.Collections.Concurrent;

namespace Lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Используя TPL создайте длительную по времени задачу (на основе Task) 
            //- «решето Эратосфена»
            //1) Выведите идентификатор текущей задачи, проверьте во время выполнения – завершена ли задача и выведите ее статус.
            //2) Оцените производительность выполнения используя объект Stopwatch на нескольких прогонах.
          
            var task = new Task<uint>(() => CountOfSieveEratosthenes(1000));
            Console.WriteLine($"Идентификатор: {task.Id}, статус {task.Status}");
            var stopwatch = new Stopwatch();
            task.Start();
            stopwatch.Start();
            Console.WriteLine($"Идентификатор: {task.Id}, статус {task.Status}");
            task.Wait();
            stopwatch.Stop();

            Console.WriteLine($"Идентификатор: {task.Id}, статус {task.Status}");
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Кол-во простых чисел от 1 до 1000: {task.Result}");

            stopwatch.Restart();
            uint result = CountOfSieveEratosthenes(1000);
            stopwatch.Stop();
            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine($"Кол-во простых чисел от 1 до 1000: {result}");

            //2.Реализуйте второй вариант этой же задачи с токеном отмены CancellationToken и отмените задачу.

            Console.ForegroundColor = ConsoleColor.Green;
            var cancellationToken = new CancellationTokenSource();
            Task task2 = Task.Factory.StartNew(CountOfSieveEratosthenesWithCancellingToken, cancellationToken.Token, cancellationToken.Token);
            try
            {
                cancellationToken.Cancel();
                task2.Wait();
            }
            catch (AggregateException e)
            {
                if(task2.IsCanceled)
                    Console.WriteLine($"{task2.Id} task is canceled\n");
            }

            //3.Создайте три задачи с возвратом результата и используйте их для
            //выполнения четвертой задачи. Например, расчет по формуле.

            double value1 = new Random().Next(1, 9);
            double value2 = new Random().Next(0, 9);
            var first = new Task<double>(() => Math.Pow(value1, 2));
            var second = new Task<double>(() => 2 * value1 * value2);
            var third = new Task<double>(() => Math.Pow(value2, 2));
            first.Start();
            second.Start();
            third.Start();
            third.Wait();
            first.Wait();
            second.Wait();

            var foorth = new Task<double>(() => first.Result - second.Result + third.Result);
            foorth.Start();
            Console.WriteLine($"(a - b)^2, a = {value1}, b = {value2} => {foorth.Result}\n");

            //4.Создайте задачу продолжения(continuation task) в двух вариантах:
            //1) C ContinueWith - планировка на основе завершения множества предшествующих задач
            //2) На основе объекта ожидания и методов GetAwaiter(),GetResult();

            Console.ForegroundColor = ConsoleColor.White;
            var expr1 = new Task<double>(() => 12 % (2 + 5) + 3 * 5);
            var expr12 = expr1.ContinueWith(s => Console.WriteLine($"Result1: {s.Result}"));
            expr1.Start();

            var expr2 = new Task<int>(() => 1554 - 21 % 7 * 3 - (6 * 70));
            var awaitcount = expr2.GetAwaiter();
            awaitcount.OnCompleted(() =>
            {
                awaitcount.GetResult();
                Console.WriteLine($"Result2: {expr2.Result}\n");
            });
            expr2.Start();
            expr2.Wait();
            

            //5.Используя Класс Parallel распараллельте вычисления циклов For(),
            //ForEach().Например, на выбор: обработку(преобразования)
            //последовательности, генерация нескольких массивов по 1000000
            //элементов, быстрая сортировка последовательности, обработка текстов
            //(удаление, замена). Оцените производительность по сравнению с
            //обычными циклами
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            var arr1 = new int[10000000];
            var arr2 = new int[10000000];
            var arr3 = new int[10000000];

            var stopwatch2 = new Stopwatch();

            stopwatch2.Start();
            Parallel.For(0, 10000000, CreatingArrayElements);
            stopwatch2.Stop();
            Console.WriteLine($"Распараллеленный For: {stopwatch2.ElapsedMilliseconds} ms");

            stopwatch2.Restart();
            for (var i = 0; i < 10000000; i++)
            {
                arr1[i] = 1;
                arr2[i] = 1;
                arr3[i] = 1;
            }

            stopwatch2.Stop();
            Console.WriteLine($"Обычный For: {stopwatch2.ElapsedMilliseconds} ms");


            int sum5 = 0;
            stopwatch2.Restart();
            Parallel.ForEach(arr1, SumOfElements);
            stopwatch2.Stop();
            Console.WriteLine($"Распараллеленный ForEach {stopwatch2.ElapsedMilliseconds} ms");

            sum5 = 0;
            stopwatch2.Restart();
            foreach (int item in arr1)
                sum5 += item;
            stopwatch2.Stop();
            Console.WriteLine($"Обычный ForEach {stopwatch2.ElapsedMilliseconds} ms");

            void CreatingArrayElements(int t)
            {
                arr2[t] = 2;
                arr3[t] = 2;
                arr1[t] = 2;
            }

            void SumOfElements(int item)
            {
                sum5 += item;
            }

            //6.Используя Parallel.Invoke() распараллельте выполнение блока операторов

            var arr11 = new int[10000000];
            var arr12 = new int[10000000];
            var arr13 = new int[10000000];

            Parallel.Invoke
            (
                () =>
                {
                    for (int i = 0; i < arr1.Length; i++)
                    {
                        arr11[i] = i;
                    }
                },
                () =>
                {
                    for (int i = 0; i < arr12.Length; i++)
                    {
                        arr12[i] = i;
                    }
                },
                () =>
                {
                    for (int i = 0; i < arr13.Length; i++)
                    {
                        arr13[i] = i;
                    }
                }
            );

            //7. Используя Класс BlockingCollection реализуйте следующую задачу:
            //Есть 5 поставщиков бытовой техники, они завозят уникальные товары
            //на склад(каждый по одному) и 10 покупателей – покупают все подряд, 
            //если товара нет - уходят.В вашей задаче: cпрос превышает
            //предложение.Изначально склад пустой.У каждого поставщика своя
            //скорость завоза товара.Каждый раз при изменении состоянии склада
            //выводите наименования товаров на складе.

            Console.WriteLine();
            BlockingCollection<string> blockCollect = new BlockingCollection<string>(5);

            //5 поставщиков
            Task[] sellers = new Task[5]
            {
                new Task(() => { while (true) { Thread.Sleep(700); blockCollect.Add("Миксер"); } }),
                new Task(() => { while (true) { Thread.Sleep(400); blockCollect.Add("Кофемашина"); } }),
                new Task(() => { while (true) { Thread.Sleep(500); blockCollect.Add("Блендер"); } }),
                new Task(() => { while (true) { Thread.Sleep(300); blockCollect.Add("Увлажнитель воздуха"); } }),
                new Task(() => { while (true) { Thread.Sleep(700); blockCollect.Add("СВЧ-печь"); } })
            };

            foreach (var i in sellers)
                if (i.Status != TaskStatus.Running)
                    i.Start();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Количество товара на складе: {blockCollect.Count}");
                Thread.Sleep(600);
                Thread thr = new Thread(Client);
                thr.Start();
            }

            void Client()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (blockCollect.Count == 0)
                {
                    Console.WriteLine("Покупатель ушёл, ничего не купив");
                    return;
                }
                Console.WriteLine($"Покупатель купил {blockCollect.Take()}");
                Console.ForegroundColor = ConsoleColor.Red;
            }

            //8.Используя async и await организуйте асинхронное выполнение любого
            //метода.

            Thread.Sleep(1000);
            Console.WriteLine();

            void Factorial(long x)
            {
                long result = 1;

                for (int i = 1; i <= x; i++)
                {
                    result *= i;
                }
                Console.WriteLine($"Completing Task #{Task.CurrentId}...");
                Console.WriteLine($"Factorial of {x} is {result}.");
            }
            async void FactorialAsync()
            {
                Console.WriteLine("Start of FactorialAsync");
                await Task.Run(() => Factorial(6));
                Console.WriteLine("End of FactorialAsync");
            }
            FactorialAsync();                               /// асинхронная функция факториала
            Console.WriteLine("Main is still running.");
            Console.ReadKey();
        }
        
        private static uint CountOfSieveEratosthenes(uint n)
        {
            var numbers = new List<uint>();
            for (var i = 2u; i < n; i++)
            {
                numbers.Add(i);
            }

            for (var i = 0; i < numbers.Count; i++)
            {
                for (var j = 2u; j < n; j++)
                {
                    numbers.Remove(numbers[i] * j);
                }
            }
            return (uint)numbers.Count;
        }

        private static uint CountOfSieveEratosthenesWithCancellingToken(object obj)
        {
            var numbers = new List<uint>();
            var token = (CancellationToken)obj;
            for (var i = 2u; i < 1000; i++) numbers.Add(i);

            for (var i = 0; i < numbers.Count; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Cancellation Request");
                    token.ThrowIfCancellationRequested();
                    return 0;
                }

                for (var j = 2u; j < 1000; j++) numbers.Remove(numbers[i] * j);
            }

            return (uint)numbers.Count;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace Lab14
{
    public static class Task
    {
        public static void EvenOdd(int n)
        {
            object locker = new object();
            Thread.Sleep(n * 1000 / 3);
            Thread evenNum = new Thread(ShowEvenNum);
            Thread oddNum = new Thread(ShowOddNum);
            evenNum.Start(n);
            oddNum.Start(n);

            void ShowEvenNum(object n)
            {
                bool acquiredLock = false;
                try
                {
                    Console.WriteLine("\n3rd thread");
                    Monitor.Enter(locker, ref acquiredLock);
                    using(StreamWriter sw = new StreamWriter(@"D:\Лабораторные\3_семестр\ООП\Lab14\Lab14\task3.txt", true))
                    {
                        for(var i = 0; i < (int)n; i++)
                        {
                            Thread.Sleep(10);
                            if(i % 2 == 0)
                            {
                                Console.Write($"{i} ");
                                sw.Write($"{i} ");
                            }
                        }
                    }
                }
                finally
                {
                    if (acquiredLock)
                        Monitor.Exit(locker);
                }
            }
            void ShowOddNum(object n)
            {
                bool acquiredLock = false;
                try
                {
                    Console.WriteLine("\n4th thread");
                    Monitor.Enter(locker, ref acquiredLock);
                    using (StreamWriter sw = new StreamWriter(@"D:\Лабораторные\3_семестр\ООП\Lab14\Lab14\task3.txt", true))
                    {
                        for (var i = 0; i < (int)n; i++)
                        {
                            Thread.Sleep(10);
                            if (i % 2 != 0)
                            {
                                Console.Write($"{i} ");
                                sw.Write($"{i} ");
                            }
                        }
                    }
                }
                finally
                {
                    if (acquiredLock)
                        Monitor.Exit(locker);
                }
            }
        }
        public static void OneEvenOneOdd(int n)
        {
            Mutex mutex = new Mutex();
            Thread.Sleep(n * 1000 / 3);
            Thread evenNum2 = new Thread(ShowEvenNums);
            Thread oddNum2 = new Thread(ShowOddNums);
            evenNum2.Start(n);
            oddNum2.Start(n);

            void ShowEvenNums(object n)
            {
                Console.WriteLine("\n5th thread");
                for (var i = 0; i < (int)n; i++)
                {
                    mutex.WaitOne();
                    Thread.Sleep(10);
                    if (i % 2 == 0)
                    {
                        Console.Write($"{i} ");
                    }
                    mutex.ReleaseMutex();
                }
            }
            void ShowOddNums(object n)
            {
                Console.WriteLine("\n6th thread");
                for (var i = 0; i < (int)n; i++)
                {
                    mutex.WaitOne();
                    Thread.Sleep(10);
                    if (i % 2 != 0)
                    {
                        Console.Write($"{i} ");
                    }
                    mutex.ReleaseMutex();
                }
            }
        }
    }
}

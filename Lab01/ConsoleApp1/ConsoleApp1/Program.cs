using System;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        { 
            int _int = 100;
            float f1 = 12.366F;
            double d1 = 8.3;
            char c1 = '$';
            bool b1 = true;
            Console.WriteLine($"Число типа int = {_int}");
            Console.WriteLine($"Число типа float = {f1}");
            Console.WriteLine($"Число типа double = {d1}");
            Console.WriteLine($"Число типа char = {c1}");
            Console.WriteLine($"Число типа bool = {b1}");

            Console.WriteLine("-----------------Явное преобразование-----------------");
            double d2 = 306.45;
            int i2 = (int)d2;
            Console.WriteLine(d2);
            Console.WriteLine(i2);
            byte b2 = (byte)i2;
            Console.WriteLine(b2);
            bool bl1 = Convert.ToBoolean(d2);
            Console.WriteLine(bl1);
            float f2 = (float)d2;
            Console.WriteLine(f2);
            short s2 = (short)d2;
            Console.WriteLine(s2);
            Console.WriteLine("-----------------Неявное преобразование-----------------");
            byte b3 = 206;
            Console.WriteLine(b3);
            short s3 = b3;
            Console.WriteLine(s3);
            int i3 = b3;
            Console.WriteLine(i3);
            double d3 = i3;
            Console.WriteLine(d3);
            float f3 = i3;
            Console.WriteLine(f3);
            decimal dec3 = s3;
            Console.WriteLine(dec3);
            Console.WriteLine("--------------Упаковка и распаковка--------------");
            double d4 = 129.6755;
            object o1 = d4;
            Console.WriteLine(o1);
            int i4 = Convert.ToInt32(o1);
            Console.WriteLine(i4);
            Console.WriteLine("--------------Неявно типизированная переменная--------------");
            var x = true;
            Console.WriteLine(x);

            Console.WriteLine("----------Nullable----------");
            int? u = null;
            u = 99;
            Console.WriteLine(u.GetValueOrDefault());
            u = null;
            Console.WriteLine(u.GetValueOrDefault(33));
            int? u1 = u + 7;
            Console.WriteLine(u1);
            Console.WriteLine("################################");
            Console.WriteLine("-------------" + "Строки" + "-------------");
            string str1 = "This";
            string str2 = "door";
            string str3 = "is locked";
            Console.WriteLine(string.Equals(str1, str2));
            Console.WriteLine(str1 + " " + str2);
            string str4 = string.Concat(str1, " ", str2, " ", str3, "!");
            Console.WriteLine(str4);
            Console.WriteLine("------" + "Копирование" + "------");
            string str41 = str2;
            Console.WriteLine(str41);
            Console.WriteLine("-----" + "Разделение строки" +"-----");
            string str5 = "Введение в курс ООП";
            string[] words = str5.Split(new char[] { ' ' });
            foreach (string s in words)
                Console.WriteLine(s);
            Console.WriteLine("--------Выделение подстроки----------");
            string str51 = str5.Substring(11);
            Console.WriteLine(str51);
            Console.WriteLine("---------" + "Удаление заданной подстроки" + "---------");
            str5 = str5.Remove(16, 3);
            Console.WriteLine(str5);
            Console.WriteLine("---------" + "Вставка заданной подстроки" + "---------");
            string str6 = "Изучение ";
            string str7 = "C#";
            str6 = str6.Insert(9, str7);
            Console.WriteLine(str6);
            string str8 = "+375(29)333-77-11";
            string str81 = "Number phone: ";
            Console.WriteLine("------Интерполяция------");
            Console.WriteLine($"{str81 + str8}");
            Console.WriteLine("-----Пустая строка-----");
            string str9 = "";
            string str91 = null;
            if (String.IsNullOrEmpty(str9))
                Console.WriteLine("Пустая строка");
            if (String.IsNullOrEmpty(str91))
                Console.WriteLine("Пустая строка");
            if(String.IsNullOrWhiteSpace(str9))
                Console.WriteLine("Строка пуста");
            else
                Console.WriteLine("Строка имеет выражения(слова)");

            StringBuilder str10 = new StringBuilder("is over");
            str10.Insert(0, "Lesson ");
            str10.Remove(7, 3);
            str10.Insert(7, "has ");
            str10.Remove(10, 5);
            str10.Append(" started");
            Console.WriteLine(str10);
            Console.WriteLine("-----------Массивы-----------");
            int[,] arr = new int[4, 4];
            Random rand = new Random();
            for(int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arr[i, j] = rand.Next(1, 15);
                    Console.Write($"[" + i + "," + j +"]" + " = ");
                    Console.Write("{0}\t", arr[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            ///////////////////////////////////////////////////////
            string[] arrs = {"One", "Two", "Three", "Foor", "Five", "Six", "Seven"};
            for (int i = 0; i < 7; i++)
            {
                Console.Write(arrs[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Исходая длина массива: {arrs.Length}");
            Console.WriteLine("Введите позицию в строке, которую нужно заменить (0-6)");
            string inp;
            inp = Console.ReadLine();
            
            Console.WriteLine("Введите строку для замены:");
            string rep;
            rep = Console.ReadLine();
            int p = Convert.ToInt32(inp);
            arrs[p] = rep;
            for (int i = 0; i < 7; i++)
            {
                Console.Write("{0}\t", arrs[i]);
            }
            Console.WriteLine();
            Console.WriteLine("----------------------------------");
            //////////////////////////////////////////////////
            
            double[][] mas = new double[3][];
            mas[0] = new double[2];
            mas[1] = new double[3];
            mas[2] = new double[4];

            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas[i].Length; j++)
                {
                    double a;
                    bool input;
                    do
                    {
                        Console.WriteLine($"[{i},{j}]");
                        input = double.TryParse(Console.ReadLine(), out a);
                        if (!input)
                            Console.WriteLine("Incorrect number!");
                    }
                    while (!input);
                    mas[i][j] = a;
                }
            }
            Console.WriteLine("Ступенчатый массив:");
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < mas[i].Length; j++)
                {
                    Console.Write(mas[i][j] + "\t");
                }
                Console.WriteLine();
            }
            ////////////////////////////////////////
            var A = new int[] { 1, 2, 3, 4, 5 }; ;
            var B = new[] {"Abcd", "BACK", "CD", "Door", "Fake", "Gg", "Easy"};
            /*--------------------Кортеж--------------------*/
            (int, string, char, string, ulong) k1 = ( 1, "Hi", '$', "World", 6 );
            Console.WriteLine(k1);
            Console.WriteLine($"Первый элемент кортежа: {k1.Item1}");
            Console.WriteLine($"Третий элемент кортежа: {k1.Item3}");
            Console.WriteLine($"Четвертый элемент кортежа: {k1.Item4}");
            int ka = k1.Item1;
            string kb = k1.Item2;
            ulong kc = k1.Item5;
            Console.WriteLine(ka + " " + kb + " " + kc);
            var ka1 = k1.Item2;
            var kb1 = k1.Item4;
            Console.WriteLine(ka1 + " " + kb1);
            var (_, _, w3, _, w5) = k1;
            Console.WriteLine($"{w5 + " " + w3}");

            Console.WriteLine("-----------Сравнение кортежей-----------");
            (int, double) tuple1 = (234, 12.23);
            (byte, short) tuple2 = (11, 12);

            if(tuple1 == tuple2)
                Console.WriteLine("Данные кортежи равны");
            else
                Console.WriteLine("Данные кортежи не равны");
            Console.WriteLine();
            //////////////////////////
            Console.WriteLine("----Locale function----");
            void Func(int[] mas2, string stri)
            {
                int max;
                int min;
                int sum;
                char symbFirst;
                max = mas2.Max();
                min = mas2.Min();
                sum = mas2.Sum();
                symbFirst = stri[0];
                var D = Tuple.Create(max, min, sum, symbFirst);
                Console.WriteLine();
                Console.WriteLine(D);
            }
            int[] array = new int[4] { 123, 1232, 566, 7777 };
            string st = "Knife";
            Func(array, st);
            ///////////////////////////////////////////////////////////////////////////
            void func1()
            {
                checked
                {
                    int maxi1 = int.MaxValue;
                    maxi1++;
                    Console.WriteLine(maxi1);
                }
            }
            void func2()
            {
                unchecked
                {
                    int maxi2 = int.MaxValue;
                    maxi2++;
                    Console.WriteLine(maxi2);
                }
            }
            Console.WriteLine("-----------------------");
            try
            {
                func1();
            }
            catch(OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            func2();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Linq;

namespace Lab11
{
    //1. Для изучения .NET Reflection API напишите статический класс Reflector, 
    //который собирает информацию и будет содержать методы выполняющие
    //исследования класса(принимают в качестве параметра имя класса) и
    //записывающие информацию в файл(формат тестовый, json или xml) :
    public static class Reflector
    {
        private static StreamWriter writer = null;
        //a. Определение имени сборки, в которой определен класс
        public static void WriteAssemblyName(string ClassName)
        {
            writer = new StreamWriter(@"D:\Лабораторные\3_семестр\ООП\Lab11\Lab11\ClassInfo.txt", true);
            Type currentClass = Type.GetType(ClassName, true, true);
            string assemblyName = currentClass.Assembly.ToString();
            writer.WriteLine("###########################################################################################");
            writer.WriteLine("###########################################################################################");
            writer.WriteLine($"Имя сборки {assemblyName}, имя класса {ClassName}");
            writer.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            writer?.Close();
        }
        //b. есть ли публичные конструкторы
        public static void PublicConstructors(string ClassName)
        {
            writer = new StreamWriter(@"D:\Лабораторные\3_семестр\ООП\Lab11\Lab11\ClassInfo.txt", true);
            Type currentClass = Type.GetType(ClassName, true, true);
            foreach (var item in currentClass.GetConstructors(BindingFlags.Public | BindingFlags.Instance))
            {
                if(item.IsPublic)
                    writer.WriteLine($"Публичный конструктор {item.ToString()}");
                else
                    writer.WriteLine("Не содержит public конструкторов");
            }
            writer.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            writer?.Close();
        }
        //c. извлекает все общедоступные публичные методы класса (возвращает IEnumerable<string>)
        public static void PublicMethods(string ClassName)
        {
            writer = new StreamWriter(@"D:\Лабораторные\3_семестр\ООП\Lab11\Lab11\ClassInfo.txt", true);
            IEnumerable<string> publicMethod = new List<string>(GetPublicMethods(ClassName));
            foreach (var item in publicMethod)
            {
                writer.WriteLine(item);
            }
            writer.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            writer?.Close();
        }

        private static IEnumerable<string> GetPublicMethods(string ClassName)
        {
            Type currentClass = Type.GetType(ClassName, true, true);
            var pubMethods = new List<string>();
           
           
                foreach (var item in currentClass.GetMethods(BindingFlags.Public | BindingFlags.Instance))
                 if (item.IsPublic)
                    pubMethods.Add(item.ToString());
           
            return pubMethods;
        }

        //d. получает информацию о полях и свойствах класса (возвращает IEnumerable<string>)

        public static void FieldsAndProperties(string ClassName)
        {
            writer = new StreamWriter(@"D:\Лабораторные\3_семестр\ООП\Lab11\Lab11\ClassInfo.txt", true);
            IEnumerable<MemberInfo[]> fieldsandproperties = new List<MemberInfo[]>(GetFieldsAndProperties(ClassName));

            writer.WriteLine("List Fields and Properties");
            foreach (var item in fieldsandproperties)
                foreach (var i in item)
                    writer.WriteLine(i.ToString());

            writer.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            writer?.Close();
        }
        private static IEnumerable<MemberInfo[]> GetFieldsAndProperties(string ClassName)
        {
            Type currentClass = Type.GetType(ClassName, true, true);
            return new List<MemberInfo[]>
            { 
              currentClass.GetFields(BindingFlags.Instance | BindingFlags.NonPublic), 
              currentClass.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic)
            };
        }

        //e. получает все реализованные классом интерфейсы (возвращает IEnumerable<string>);

        public static void Interfaces(string ClassName)
        {
            writer  = new StreamWriter(@"D:\Лабораторные\3_семестр\ООП\Lab11\Lab11\ClassInfo.txt", true);
            IEnumerable<string> interfaces = new List<string>(GetInterfaces(ClassName));
            writer.WriteLine("Interface methods list: ");
            if (interfaces.Count() == 0)
                writer.WriteLine("No interfaces");
            else
            {
                foreach (var item in interfaces)
                writer.WriteLine(item);
            }
            writer.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            writer?.Close();
        }
        private static IEnumerable<string> GetInterfaces(string ClassName)
        {
            Type currentClass = Type.GetType(ClassName, true, true);
            var interfaces = new List<string>();
            foreach (var item in currentClass.GetInterfaces())
                if (item.IsPublic)
                    interfaces.Add(item.ToString());
            return interfaces;
        }

        //f. выводит по имени класса имена методов, которые содержат заданный(пользователем)
        //тип параметра(имя класса передается в качестве аргумента);

        public static void MethodsWithUserParametr(string ClassName, string parametr)
        {
            writer = new StreamWriter(@"D:\Лабораторные\3_семестр\ООП\Lab11\Lab11\ClassInfo.txt", true);
            IEnumerable<string> methodsWithUserParametr = new List<string>(GetMethodsWithUserParametr(ClassName, parametr));
            writer.WriteLine($"Methods with parameters ({parametr})");
            if (methodsWithUserParametr.Count() != 0)
            {
                foreach (string item in methodsWithUserParametr)
                    writer.WriteLine(item);
            }
            else
                writer.WriteLine("Missing");
            writer.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            writer?.Close();
        }
        private static IEnumerable<string> GetMethodsWithUserParametr(string ClassName, string UserParametr)
        {
            Type currentClass = Type.GetType(ClassName, true, true);
            var methodswithparameters = new List<string>();
            var currentClassMethods = currentClass.GetMethods();
            foreach (var item in currentClassMethods)
            {
                var parameter = item.GetParameters();
                if (parameter.Any(param => param.Name == UserParametr))
                    methodswithparameters.Add(item.ToString());
            }
            return methodswithparameters;
        }

        //g. метод Invoke, который вызывает метод класса, при этом значения для его параметров необходимо 
        //1) прочитать из текстового файла (имя класса и имя метода передаются в качестве аргументов) 
        //2) сгенерировать, используя генератор значений для каждого типа.
        //Параметрами метода Invoke должны быть : объект, имя метода, массив параметров

        public static void Invoke(string ClassName, string MethodName)
        {
            try
            {
                object obj = Activator.CreateInstance(Type.GetType(ClassName));
                var method = Type.GetType(ClassName).GetMethod(MethodName);
                List<string> list = File.ReadAllLines(@"D:\Лабораторные\3_семестр\ООП\Lab11\Lab11\Invoke.txt").ToList();
                List<string>[] list2 = new List<string>[] { list };
                method.Invoke(obj, list2);  
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ClearFile()
        {
            using (writer = new StreamWriter(@"D:\Лабораторные\3_семестр\ООП\Lab11\Lab11\ClassInfo.txt", false))
            {
                writer.WriteLine("");
            }
            writer?.Close();
        }

        //2. Добавьте в Reflector обобщенный метод Create, который создает объект 
        //переданного типа(на основе имеющихся публичных конструкторов) и возвращает его пользователю

        public static object Create(string ClassName)
        {
            return Activator.CreateInstance(Type.GetType(ClassName));
        }
    }
}

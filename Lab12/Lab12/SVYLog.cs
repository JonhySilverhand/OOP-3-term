using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab12
{
    /*1. Создать класс XXXLog. Он должен отвечать за работу с текстовым файлом xxxlogfile.txt. 
     в который записываются все действия пользователя и 
     соответственно методами записи в текстовый файл, чтения, поиска нужной информации.
     a. Используя данный класс выполните запись всех 
     последующих действиях пользователя с указанием действия, детальной информации (имя файла, путь) и времени (дата/время)*/
    public class SVYLog
    {
        private static StreamWriter logfile;
        private static string pathLog = @"D:\Лабораторные\3_семестр\ООП\Lab12\Lab12\svylogfile.txt";
        public static void WriteLog(string action, string filename = "", string path = "")
        {
            if(filename.Length != 0 && path.Length != 0)
            {
                using (logfile = new StreamWriter(pathLog, true))
                {
                    logfile.WriteLine($"{DateTime.Now.ToString()}");
                    logfile.WriteLine($"Действие: {action}");
                    logfile.WriteLine($"Имя файла: {filename}");
                    logfile.WriteLine($"Путь: {path}");
                    logfile.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
                }
            }
            else
            {
                using(logfile = new StreamWriter(pathLog, true))
                {
                    logfile.WriteLine($"{DateTime.Now.ToString()}");
                    logfile.WriteLine($"Действие: {action}");
                    logfile.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
                }
            }
        }
        /*6. Найдите и выведите сохраненную информацию в файле xxxlogfile.txt
             о действиях пользователя за определенный день/ диапазон времени/по ключевому слову. 
             Посчитайте количество записей в нем. Удалите часть информации, оставьте только записи за текущий час.*/
        public static void FindInfo()
        {
            var output = new StringBuilder();

            using (var stream = new StreamReader(pathLog))
            {
                var textline = "";
                var isActual = false;
                while (!stream.EndOfStream)
                {
                    isActual = false;
                    textline = stream.ReadLine();
                    if (textline != "" && DateTime.Parse(textline).Day == DateTime.Now.Day)
                    {
                        isActual = true;
                        textline += Environment.NewLine;
                        output.AppendFormat(textline);
                    }

                    textline = stream.ReadLine();
                    while (textline != "▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬")
                    {
                        if (isActual)
                        {
                            textline += Environment.NewLine;
                            output.AppendFormat(textline);
                        }

                        textline = stream.ReadLine();
                    }

                    if (isActual)
                    {
                        output.AppendFormat("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
                        output.AppendFormat(Environment.NewLine);
                    }
                }
            }

            using (var stream = new StreamWriter(@"D:\Лабораторные\3_семестр\ООП\Lab12\Lab12\NewLog.txt"))
            {
                stream.WriteLine(output.ToString());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab12
{
    /*4. Создать класс XXXDirInfo c методами для вывода информации о конкретном директории
      a. Количестве файлов
      b. Время создания
      c. Количестве поддиректориев
      d. Список родительских директориев
      e. Продемонстрируйте работу класса*/
    public class SVYDirInfo
    {
        public static void ShowDirInfo(string dirName)
        {
            if (Directory.Exists(dirName))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dirName);

                Console.WriteLine("Files:");
                Console.WriteLine($"Кол-во файлов: {dirInfo.GetFiles().Length}");
                Console.WriteLine($"Дата и время создания директория: {dirInfo.CreationTime}");
                Console.WriteLine($"Кол-во поддиректориев: {dirInfo.GetDirectories().Length}");
                Console.WriteLine($"Список родительских директориев: {dirInfo.Parent}");
            }
            else
                throw new ArgumentException();
        }
    }
}

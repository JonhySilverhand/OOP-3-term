using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Lab12
{
    /*5. Создать класс XXXFileManager. Набор методов определите самостоятельно. С его помощью выполнить следующие действия:
      a. Прочитать список файлов и папок заданного диска.
      Создать директорий XXXInspect, 
      создать текстовый файл xxxdirinfo.txt и сохранить туда информацию.
      Создать копию файла и переименовать его. Удалить первоначальный файл.
      b. Создать еще один директорий XXXFiles. Скопировать в 
      него все файлы с заданным расширением из заданного 
      пользователем директория. Переместить XXXFiles в 
      XXXInspect.
      c. Сделайте архив из файлов директория XXXFiles. 
      Разархивируйте его в другой директорий.*/
    public class SVYFileManager
    {
        public static void InspectDriver(string driverName)
        {
            Directory.CreateDirectory(@"D:\Лабораторные\3_семестр\ООП\Lab12\Lab12\SVYInspect");
            File.Create(@"D:\Лабораторные\3_семестр\ООП\Lab12\Lab12\SVYInspect\svydirinfo.txt").Close();
            var currentDrive = DriveInfo.GetDrives().Single(x => x.Name == driverName);
            
            using(StreamWriter file = new StreamWriter(@"D:\Лабораторные\3_семестр\ООП\Lab12\Lab12\SVYInspect\svydirinfo.txt"))
            {
                file.WriteLine("Список папок:");
                foreach (var a in currentDrive.RootDirectory.GetDirectories())
                {
                    file.WriteLine(a);
                }
                file.WriteLine("Список файлов:");
                foreach (var b in currentDrive.RootDirectory.GetFiles())
                {
                    file.WriteLine(b);
                }
            }
            File.Copy(@"D:\Лабораторные\3_семестр\ООП\Lab12\Lab12\SVYInspect\svydirinfo.txt", @"D:\Лабораторные\3_семестр\ООП\Lab12\Lab12\SVYInspect\svydirinfoCopy.txt", true);
            File.Delete(@"D:\Лабораторные\3_семестр\ООП\Lab12\Lab12\SVYInspect\svydirinfo.txt");
        } 
        public static void CopyFiles(string path, string extention)
        {
            Directory.CreateDirectory(@"D:\Лабораторные\3_семестр\ООП\Lab12\Lab12\SVYFiles");
            DirectoryInfo directory = new DirectoryInfo(path);
            DirectoryInfo directory2 = new DirectoryInfo(@"D:\Лабораторные\3_семестр\ООП\Lab12\Lab12\SVYInspect\SVYFiles\");
            foreach (var i in directory.GetFiles())
            {
                if (i.Extension == extention)
                    i.CopyTo(@"D:\Лабораторные\3_семестр\ООП\Lab12\Lab12\SVYFiles\" + i.Name, true);
            }
            if (!directory2.Exists)
                Directory.Move(@"D:\Лабораторные\3_семестр\ООП\Lab12\Lab12\SVYFiles\", @"D:\Лабораторные\3_семестр\ООП\Lab12\Lab12\SVYInspect\SVYFiles\");
            else
                Directory.Delete(@"D:\Лабораторные\3_семестр\ООП\Lab12\Lab12\SVYFiles\", true);
        }
        public static void CreateArchive(string dir)
        {
            string name = @"D:\Лабораторные\3_семестр\ООП\Lab12\Lab12\SVYInspect\SVYFiles";
            Directory.CreateDirectory(dir);
            if (new DirectoryInfo(@"D:\Лабораторные\3_семестр\ООП\Lab12\Lab12\SVYInspect").GetFiles("*.zip").Length == 0)
            {
                ZipFile.CreateFromDirectory(name, name + ".zip");
                DirectoryInfo directory = new DirectoryInfo(dir);
                foreach (var innerFile in directory.GetFiles())
                    innerFile.Delete();
                directory.Delete();
                ZipFile.ExtractToDirectory(name + ".zip", dir);
            }
        }
    }
}

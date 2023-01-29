using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab12
{
    public class SVYFileInfo
    {
        public static void ShowFileInfo(string path)
        {
            FileInfo finfo = new FileInfo(path);
            Console.WriteLine($"Имя директории: {finfo.DirectoryName}");
            Console.WriteLine($"Размер файла: {finfo.Length}");
            Console.WriteLine($"Расширение файла: {finfo.Extension}");
            Console.WriteLine($"Имя файла: {finfo.Name}");
            Console.WriteLine($"Время создания файла: {finfo.CreationTime}");
            Console.WriteLine($"Последнее изменение файла: {finfo.LastWriteTime}");
        }
    }
}

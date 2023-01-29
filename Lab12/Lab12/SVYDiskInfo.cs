using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab12
{
    /*2. Создать класс XXXDiskInfo c методами для вывода информации о
            a. свободном месте на диске
            b. Файловой системе
            c. Для каждого существующего диска - имя, объем, доступный 
            объем, метка тома.
            d. Продемонстрируйте работу класса*/
    public class SVYDiskInfo
    {
        public static void ShowDisk()
        {

            var allDrives = DriveInfo.GetDrives();
            foreach (var d in allDrives)
            {
                Console.WriteLine($"Имя диска: {d.Name}");
                Console.WriteLine($"Тип диска: {d.DriveType}");

                if (!d.IsReady) continue;

                Console.WriteLine($"Метка тома: {d.VolumeLabel}");
                Console.WriteLine($"Файловая система: {d.DriveFormat}");
                Console.WriteLine($"Объём: {d.TotalSize}");
                Console.WriteLine($"Свободное место на диске: {d.TotalFreeSpace}");
                Console.WriteLine($"Доступный объём: {d.AvailableFreeSpace}");
            }
        }
    }
}



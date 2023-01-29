using System;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
                SVYDiskInfo.ShowDisk();
                SVYLog.WriteLog("SVYDiskInfo.ShowDisk()");
                Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
                SVYDirInfo.ShowDirInfo(@"D:\Лабораторные\3_семестр\ООП");
                SVYLog.WriteLog("SVYDirInfo.ShowDirInfo()", @"D:\Лабораторные\3_семестр\ООП");
                Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
                SVYFileInfo.ShowFileInfo(@"D:\Лабораторные\3_семестр\ООП\TrainingManual\12_Потоки_файловая система.pdf");
                SVYLog.WriteLog("SVYFileInfo.ShowFileInfo()", "svylogfile.txt", @"D:\Лабораторные\3_семестр\ООП\Lab12\Lab12\svylogfile.txt");
                Console.WriteLine("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
                SVYFileManager.InspectDriver("D:\\");
                SVYLog.WriteLog("SVYFileManager.InspectDriver()", "D:\\");
                SVYFileManager.CopyFiles(@"D:\Лабораторные\3_семестр\АиСД\TrainingManual", ".docx");
                SVYLog.WriteLog("SVYFileManager.CopyFiles()", @"D:\Лабораторные\3_семестр\АиСД\TrainingManual");
                SVYFileManager.CreateArchive(@"D:\Лабораторные\3_семестр\ООП\Lab12\Lab12\ForArchive");
                SVYLog.WriteLog("SVYFileManager.CreateArchive()");
                SVYLog.FindInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

using System;
using System.IO.Compression;

namespace Lab12
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Информация о дисках:");
            KSSDiskInfo.WriteDriveInfo();

            Console.WriteLine("-------------------------");
            Console.WriteLine("Информация о файле:");
            KSSFileInfo.WriteFileInfo(@"D:\Лабораторные\ООП\12 лаба\KSSLogfile.txt");

            Console.WriteLine("-------------------------");
            Console.WriteLine("Информация о директории");
            KSSDirInfo.WriteDirInfo(@"D:\Лабораторные\ООП\12 лаба\Lab12");

            Console.WriteLine("-------------------------");
            string drivePath = @"D:\";

            try
            {
                Console.WriteLine("Запуск сканирования диска");

               
                KSSFileManager.ScanDisk(drivePath);

                Console.WriteLine("\nСканирование диска завершено");

         
                string sourceDir = Path.Combine(drivePath, "SourceFiles");
                string targetDir = Path.Combine(drivePath, "KSSInspect", "KSSFiles");
                string fileExtension = ".txt";

                KSSFileManager.CopyFilesByExtension(sourceDir, targetDir, fileExtension);
                Console.WriteLine($"Файлы с расширением {fileExtension} скопированы в {targetDir}.");

                // Перемещение директории
                string newTargetDir = Path.Combine(drivePath, "KSSFilesMoved");
                KSSFileManager.MoveDirectory(targetDir, newTargetDir);
                Console.WriteLine($"Директория перемещена в {newTargetDir}.");

                // Создание и разархивирование архива
                string zipPath = Path.Combine(drivePath, "KSSFiles.zip");
                KSSFileManager.CreateZip(newTargetDir, zipPath);

                string extractDir = Path.Combine(drivePath, "ExtractedFiles");
                KSSFileManager.ExtractZip(zipPath, extractDir);

                Console.WriteLine("\nВсе операции выполнены успешно.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }


            //6
            Console.WriteLine("\nПоиск записей за период с 1 декабря 2024 года, 10:00 по 1 декабря 2024 года, 12:00:");
            DateTime startDate = new DateTime(2024, 12, 1, 10, 0, 0);
            DateTime endDate = new DateTime(2024, 12, 6, 19, 0, 0);
            KSSLog.FindTextLogByRangeDate(startDate, endDate);


            //Console.WriteLine("\nПоиск записей за 1 декабря 2024 года:");
            //DateTime searchDate = new DateTime(2024, 12, 1);
            //KSSLog.FindTextLogByDate(searchDate);

            Console.WriteLine("\nПоиск записей по ключевому слову 'ошибка':");
            KSSLog.FindTextLogByKeyword("ошибка");

            // Демонстрация подсчета общего числа записей в логе
            Console.WriteLine("\nПодсчет общего числа записей в логе:");
            KSSLog.CountLogEntries();

            //Console.WriteLine("\nУдаляем записи, не относящиеся к текущему часу...");
            //KSSLog.RemoveOldEntriesAndKeepCurrentHour();

    
            //Console.WriteLine("\nВывод всех записей лога:");
            //foreach (var entry in KSSLog.GetDataFromTextFile())
            //{
            //    entry.Print();
            //}
        }
    }
}
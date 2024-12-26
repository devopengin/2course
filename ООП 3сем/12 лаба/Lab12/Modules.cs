using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Text;

namespace Lab12
{

    public static class KSSDiskInfo
    {
        public static void WriteDriveInfo()
        {
            var drives = DriveInfo.GetDrives();
            foreach (var item in drives)
            {
                Console.WriteLine($"Имя диска: {item.Name}");
                Console.WriteLine($"Свободное место на диске: {item.TotalFreeSpace / (1024 * 1024 * 1024)} ГБ");
                Console.WriteLine($"Файловая система: {item.DriveFormat}");
                Console.WriteLine($"Доступный объём: {item.AvailableFreeSpace / (1024 * 1024 * 1024)} ГБ");
                Console.WriteLine($"Метка тома: {item.VolumeLabel}");
                Console.WriteLine($"Объём: {item.TotalSize / (1024 * 1024 * 1024)} ГБ");
            }
            KSSLog.WriteToFile(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
        }
    }

    public static class KSSFileInfo
    {
        public static void WriteFileInfo(string pathToFile)
        {
            FileInfo fileInfo = new(pathToFile);
            if (fileInfo.Exists)
            {
                Console.WriteLine($"Полный путь к файлу {fileInfo.Name} - {fileInfo.FullName}");
                Console.WriteLine($"Размер файла: {fileInfo.Length} байт, Расширение: {fileInfo.Extension}, Имя: {fileInfo.Name}");
                Console.WriteLine($"Дата создания файла: {fileInfo.CreationTime}, Дата изменения файла: {fileInfo.LastWriteTime}");
                KSSLog.WriteToFile(MethodBase.GetCurrentMethod().Name, fileInfo.Name, fileInfo.FullName);
            }
            else
            {
                Console.WriteLine($"Файл {pathToFile} не существует.");
                KSSLog.WriteToFile(MethodBase.GetCurrentMethod().Name, pathToFile, "Файл не найден.");
            }
        }
    }

    public static class KSSDirInfo
    {
        public static void WriteDirInfo(string pathToDir)
        {
            DirectoryInfo dirInf = new(pathToDir);
            if (dirInf.Exists)
            {
                Console.WriteLine($"Количество файлов: {dirInf.GetFiles().Length}");
                Console.WriteLine($"Время создания: {dirInf.CreationTime}");
                Console.WriteLine($"Количество поддиректориев: {dirInf.GetDirectories().Length}");
                Console.WriteLine("Список родительских директорий:");
                DirectoryInfo? parent = dirInf.Parent;
                while (parent != null)
                {
                    Console.WriteLine(parent.FullName);
                    parent = parent.Parent;
                }
                KSSLog.WriteToFile(MethodBase.GetCurrentMethod().Name, dirInf.Name, dirInf.FullName);
            }
            else
            {
                Console.WriteLine($"Директория {pathToDir} не существует");
                KSSLog.WriteToFile(MethodBase.GetCurrentMethod().Name, pathToDir, "Директория не найдена");
            }
        }
    }

    public static class KSSFileManager
    {
        public static void ScanDisk(string drivePath)
        {
            DirectoryInfo drive = new(drivePath);

            if (!drive.Exists)
            {
                Console.WriteLine($"Ошибка: Диск {drivePath} не найден");
                KSSLog.WriteToFile("Ошибка", drivePath, "Диск не найден");
                throw new DirectoryNotFoundException($"Диск {drivePath} не найден");
            }

            string scanDirPath = Path.Combine(drivePath, "KSSInspect");
            Directory.CreateDirectory(scanDirPath);
            KSSLog.WriteToFile("Создание директории", "KSSInspect", scanDirPath);

            string filePath = Path.Combine(scanDirPath, "kssdirinfo.txt");
            using (StreamWriter writer = new(filePath))
            {
                writer.WriteLine("Файлы на диске:");
                foreach (var file in SafeGetFiles(drive))
                {
                    writer.WriteLine($"Файл: {file.FullName}");
                }

                writer.WriteLine("\nПапки на диске:");
                foreach (var directory in SafeGetDirectories(drive))
                {
                    writer.WriteLine($"Папка: {directory.FullName}");
                }
            }

            Console.WriteLine($"Файл {filePath} создан.");
            KSSLog.WriteToFile("Запись в файл", "kssdirinfo.txt", filePath);

            string newFileName = $"renamed_kssdirinfo.txt";
            string newFilePath = Path.Combine(scanDirPath, newFileName);

            File.Copy(filePath, newFilePath, overwrite: true);
            Console.WriteLine($"Копия файла создана и переименована: {newFilePath}");
            KSSLog.WriteToFile("Копирование файла", newFileName, newFilePath);

            File.Delete(filePath);
            Console.WriteLine($"Оригинальный файл удалён: {filePath}");
            KSSLog.WriteToFile("Удаление файла", filePath, "Удалён");
        }

        private static IEnumerable<FileInfo> SafeGetFiles(DirectoryInfo directory)
        {
            try
            {
                return directory.GetFiles("*", SearchOption.TopDirectoryOnly);
            }
            catch (UnauthorizedAccessException)
            {
                return Enumerable.Empty<FileInfo>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при доступе к файлам: {ex.Message}");
                KSSLog.WriteToFile("Ошибка доступа", "", ex.Message);
                return Enumerable.Empty<FileInfo>();
            }
        }

        private static IEnumerable<DirectoryInfo> SafeGetDirectories(DirectoryInfo directory)
        {
            try
            {
                return directory.GetDirectories("*", SearchOption.TopDirectoryOnly);
            }
            catch (UnauthorizedAccessException)
            {
                return Enumerable.Empty<DirectoryInfo>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при доступе к папкам: {ex.Message}");
                KSSLog.WriteToFile("Ошибка доступа", "", ex.Message);
                return Enumerable.Empty<DirectoryInfo>();
            }
        }

        public static void CopyFilesByExtension(string sourceDir, string targetDir, string extension)
        {
            DirectoryInfo source = new(sourceDir);
            DirectoryInfo target = new(targetDir);

            if (!source.Exists)
            {
                throw new DirectoryNotFoundException($"Исходный каталог {sourceDir} не найден");
            }

            if (!target.Exists)
            {
                target.Create();
            }

            foreach (var file in source.GetFiles($"*{extension}", SearchOption.TopDirectoryOnly))
            {
                string targetFilePath = Path.Combine(target.FullName, file.Name);
                file.CopyTo(targetFilePath, true);
            }

            Console.WriteLine($"Файлы с расширением {extension} скопированы в {target.FullName}");
            KSSLog.WriteToFile("Копирование файлов", extension, target.FullName);
        }

        public static void MoveDirectory(string sourceDir, string targetDir)
        {
            if (!Directory.Exists(sourceDir))
            {
                Console.WriteLine($"Ошибка: Каталог {sourceDir} не найден");
                KSSLog.WriteToFile("Ошибка перемещения", sourceDir, "Каталог не найден");
                throw new DirectoryNotFoundException($"Каталог {sourceDir} не найден");
            }

            try
            {
                Directory.Move(sourceDir, targetDir);
                Console.WriteLine($"Каталог {sourceDir} успешно перемещен в {targetDir}");
                KSSLog.WriteToFile("Перемещение каталога", sourceDir, targetDir);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при перемещении каталога: {ex.Message}");
                KSSLog.WriteToFile("Ошибка перемещения", sourceDir, ex.Message);
                throw;
            }
        }

        public static void CreateZip(string sourceDir, string zipPath)
        {
            if (!Directory.Exists(sourceDir))
            {
                throw new DirectoryNotFoundException($"Каталог {sourceDir} не найден");
            }

            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }

            ZipFile.CreateFromDirectory(sourceDir, zipPath);
            Console.WriteLine($"Каталог {sourceDir} заархивирован в {zipPath}");
            KSSLog.WriteToFile("Создание архива", sourceDir, zipPath);
        }

        public static void ExtractZip(string zipPath, string extractDir)
        {
            if (!File.Exists(zipPath))
            {
                throw new FileNotFoundException($"Архив {zipPath} не найден");
            }

            if (!Directory.Exists(extractDir))
            {
                Directory.CreateDirectory(extractDir);
            }

            ZipFile.ExtractToDirectory(zipPath, extractDir);
            Console.WriteLine($"Архив {zipPath} распакован в {extractDir}");
            KSSLog.WriteToFile("Распаковка архива", zipPath, extractDir);
        }
    }
}
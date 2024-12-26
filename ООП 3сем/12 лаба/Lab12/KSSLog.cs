using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab12
{
    public static class KSSLog
    {
        private const string TEXT_LOG_PATH = @"D:\Лабораторные\ООП\12 лаба\KSSLogfile.txt";

        // Запись в текстовый лог
        public static void WriteToFile(string action, string fileName = "", string path = "")
        {
            using (StreamWriter logfile = new(TEXT_LOG_PATH, true))
            {
                logfile.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                logfile.WriteLine($"Действие: {action}");
                if (!string.IsNullOrEmpty(fileName) && !string.IsNullOrEmpty(path))
                {
                    logfile.WriteLine($"Имя файла: {fileName}");
                    logfile.WriteLine($"Путь к файлу: {path}");
                }
                logfile.WriteLine("----------------------------");
            }
        }

        public static void FindTextLogByRangeDate(DateTime start, DateTime end)
        {
            var datas = GetDataFromTextFile();
            var filteredData = datas.Where(d => d.Date >= start && d.Date <= end).ToList();
            filteredData.ForEach(d => d.Print());
        }

        public static void FindTextLogByDate(DateTime date)
        {
            var datas = GetDataFromTextFile();
            var filteredData = datas.Where(d => d.Date.Date == date.Date).ToList();
            filteredData.ForEach(d => d.Print());
        }
        public static void FindTextLogByKeyword(string keyword)
        {
            var datas = GetDataFromTextFile();
            var filteredData = datas.Where(d => d.Action.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
            if (filteredData.Count > 0)
            {
                filteredData.ForEach(d => d.Print());
            }
            else
            {
                Console.WriteLine($"Записи с ключевым словом '{keyword}' не найдены.");
            }
        }

        public static void CountLogEntries()
        {
            var datas = GetDataFromTextFile();
            Console.WriteLine($"Общее количество записей в логе: {datas.Count}");
        }


        public static void RemoveOldEntriesAndKeepCurrentHour()
        {
            var datas = GetDataFromTextFile();
            var currentHour = DateTime.Now.Hour;

            var filteredData = datas.Where(d => d.Date.Hour == currentHour).ToList();

            using (StreamWriter logfile = new(TEXT_LOG_PATH, false))
            {
                foreach (var data in filteredData)
                {
                    logfile.WriteLine($"{data.Date:yyyy-MM-dd HH:mm:ss}");
                    logfile.WriteLine($"Действие: {data.Action}");
                    logfile.WriteLine("----------------------------");
                }
            }

            Console.WriteLine($"Все записи не относящиеся к текущему часу были удалены");
        }

        public static List<Data> GetDataFromTextFile()
        {
            if (!File.Exists(TEXT_LOG_PATH)) return new List<Data>();

            var data = File.ReadAllLines(TEXT_LOG_PATH);
            var datas = new List<Data>();

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].StartsWith("Действие"))
                {
                    var action = data[i].Substring("Действие: ".Length);
                    var date = DateTime.Parse(data[i - 1]);
                    datas.Add(new Data(action, date));
                }
            }

            return datas;
        }
    }

    public class Data
    {
        public string Action { get; set; }
        public DateTime Date { get; set; }

        public Data(string action, DateTime date)
        {
            Action = action ?? "undefined";
            Date = date;
        }

        public void Print()
        {
            Console.WriteLine($"Действие: {Action} Дата: {Date:yyyy-MM-dd HH:mm:ss}");
        }
    }
}

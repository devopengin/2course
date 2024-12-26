using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Text;

namespace Lab07
{
    interface Meth<T>
    {
        void Add(T element);
        void Remove(T element);
        void See();
    }

    public class CollectionType<T> : Meth<T> where T : class
    {
        private List<T> _elements = new List<T>();
        public string path = @"D:\Лабораторные\ООП\7 лаба\Lab07\input.json";
        public void Add(T element)
        {
            try
            {
                _elements.Add(element);
                Console.WriteLine("Элемент добавлен");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникла ошибка при добавлении элемента : {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Функция добавления элементов завершилась");
            }

        }
        public void Remove(T element)
        {
            try
            {
                _elements.Remove(element);
                Console.WriteLine("Удаление элемента произошло успешно");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникла ошибка при удалении: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Функция удаления элементов завершилась");
            }
        }
        public void See()
        {
            try
            {
                foreach (T element in _elements)
                {

                    Console.WriteLine(element);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникла ошибка при просмотре элементов : {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Функция отображения элементов завершилась");
            }
        }

        public List<T> FindByPredicate(Func<T, bool> predicate)
        {
            try
            {
                return _elements.Where(predicate).ToList();
            }
            catch
            {
                Console.WriteLine("Ошибка во время поиска по предикату");
                return new List<T>();
            }
            finally
            {
                Console.WriteLine("Функция поиска по предикату завершилась");
            }
        }



        public void WriteToFile()
        {
            try
            {
                string json = JsonSerializer.Serialize(_elements);
                File.WriteAllText(path, json);
                Console.WriteLine("Данные успешно записаны в файл.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Возникла ошибка при записи в файл: {ex.Message}");
            }

        }

        public void ReadFromFile()
        {
            _elements.Clear();

            string json = File.ReadAllText(path);

            var elements = JsonSerializer.Deserialize<List<T>>(json);

            if (elements != null)
            {
                _elements.AddRange(elements);
            }

            foreach (var element in _elements)
            {
                Console.WriteLine(element);
            }
        }


    }


}


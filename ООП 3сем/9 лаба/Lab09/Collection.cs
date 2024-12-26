using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Lab09
{
    public class myCollection<TKey, TValue> : IOrderedDictionary

    {
        private Queue<KeyValuePair<TKey, TValue>> queue = new Queue<KeyValuePair<TKey, TValue>>();
        public bool IsSynchronized => false;
        public bool IsFixedSize => false;
        public bool IsReadOnly => false;
        private object syncRoot = new object();
        public object SyncRoot => syncRoot;
        public ICollection Keys => queue.Select(pair => pair.Key).ToList();

        public ICollection Values => queue.Select(pair => pair.Value).ToList();


        public void Add(object key, object value)
        {
            queue.Enqueue(new KeyValuePair<TKey, TValue>((TKey)key, (TValue)value));
        }
        public void Clear()
        {
            queue.Clear();
        }
        public bool Contains(object key)
        {
            foreach (var pair in queue)
            {
                if (pair.Key!.Equals((TKey)key))
                    return true;
            }
            return false;
        }

        public void Remove(object key)
        {
            var temp = new Queue<KeyValuePair<TKey, TValue>>();

            while (queue.Count > 0)
            {
                var item = queue.Dequeue();
                if (!item.Key!.Equals((TKey)key))
                {
                    temp.Enqueue(item);
                }
            }


            queue = temp;
        }

        public void Insert(int index, object key, object value)
        {
            var temp = new Queue<KeyValuePair<TKey, TValue>>();
            int currentIndex = 0;

            while (queue.Count > 0)
            {
                if (currentIndex == index)
                {
                    temp.Enqueue(new KeyValuePair<TKey, TValue>((TKey)key, (TValue)value));
                }
                temp.Enqueue(queue.Dequeue());
                currentIndex++;
            }

            queue = temp;
        }

        public void RemoveAt(int index)
        {
            var temp = new Queue<KeyValuePair<TKey, TValue>>();
            int currentIndex = 0;

            while (queue.Count > 0)
            {
                var pair = queue.Dequeue();
                if (currentIndex != index)
                {
                    temp.Enqueue(pair);
                }
                currentIndex++;
            }

            queue = temp;
        }

        public int Count => queue.Count;

        public void WatchAll()
        {
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
        public IDictionaryEnumerator GetEnumerator()
        {
            return new DictionaryEnumerator(queue.GetEnumerator());
        }

        private class DictionaryEnumerator : IDictionaryEnumerator
        {
            private IEnumerator<KeyValuePair<TKey, TValue>> enumerator;

            public DictionaryEnumerator(IEnumerator<KeyValuePair<TKey, TValue>> enumerator)
            {
                this.enumerator = enumerator;
            }

            public bool MoveNext() => enumerator.MoveNext();

            public void Reset() => enumerator.Reset();

            public object Current => Entry;

            public DictionaryEntry Entry => new DictionaryEntry(enumerator.Current.Key, enumerator.Current.Value);

            public object Key => enumerator.Current.Key;

            public object Value => enumerator.Current.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return queue.GetEnumerator();
        }
        public void CopyTo(Array array, int index)
        {
            queue.CopyTo((KeyValuePair<TKey, TValue>[])array, index);
        }

        public object this[object key]
        {
            get
            {
                var pair = queue.FirstOrDefault(p => p.Key.Equals(key));
                if (pair.Equals(default(KeyValuePair<TKey, TValue>)))
                {
                    throw new KeyNotFoundException("Ключ не найден");
                }
                return pair.Value;
            }
            set
            {
                var temp = new Queue<KeyValuePair<TKey, TValue>>(queue.Where(pair => !pair.Key.Equals(key)));
                temp.Enqueue(new KeyValuePair<TKey, TValue>((TKey)key, (TValue)value));

                queue = temp;
            }
        }

        public object this[int index]
        {
            get
            {
                return queue.ElementAt(index).Value;
            }
            set
            {
                var temp = new Queue<KeyValuePair<TKey, TValue>>();

                // Добавляем элементы до индекса
                for (int i = 0; i < index; i++)
                {
                    temp.Enqueue(queue.Dequeue());
                }

                // Добавляем новый элемент по индексу
                temp.Enqueue(new KeyValuePair<TKey, TValue>((TKey)queue.Peek().Key, (TValue)value));

                // Добавляем оставшиеся элементы
                while (queue.Count > 0)
                {
                    temp.Enqueue(queue.Dequeue());
                }

                queue = temp;
            }
        }


    }
}

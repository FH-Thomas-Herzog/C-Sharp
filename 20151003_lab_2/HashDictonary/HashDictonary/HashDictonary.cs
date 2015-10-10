using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashDictonary
{
    public class HashDictonary<K, V> : IDictionary<K, V>
    {
        private const int InitialSize = 8;
        private Node[] hashTable = new Node[InitialSize];
        private int size = 0;

        private class Node
        {
            public K Key { get; private set; }
            public V Value { get; set; }
            public Node Next { get; private set; }

            public Node(K key, V value, Node next)
            {
                Key = key;
                Value = value;
                Next = next;
            }

        }


        public V this[K key]
        {
            get
            {
                Node n = FindNode(key);
                if(n != null)
                {
                    return n.Value;
                }
                throw new KeyNotFoundException("No element foudn for given key");
            }

            set
            {
                Node n = FindNode(key);
                if(n == null)
                {
                    int idx = IndexFor(key);
                    hashTable[idx] = new Node(key, value, hashTable[idx]);
                    size++;
                }
                else
                {
                    n.Value = value;
                }
            }
        }

        public int Count
        {
            get
            {
                return size;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public ICollection<K> Keys
        {
            get
            {
                IList<K> list = new List<K>(hashTable.Length);
                foreach (KeyValuePair<K, V> pair in this)
                {
                    list.Add(pair.Key);
                }
                return list;
            }
        }

        public ICollection<V> Values
        {
            get
            {
                IList<V> list = new List<V>(hashTable.Length);
                foreach (KeyValuePair<K, V> pair in this)
                {
                    list.Add(pair.Value);
                }
                return list;
            }
        }

        public void Add(KeyValuePair<K, V> item)
        {
            this.Add(item.Key, item.Value);
        }

        public void Add(K key, V value)
        {
            if (!ContainsKey(key))
            {
                this[key] = value;
            }
            else
            {
                throw new ArgumentException("Key already inserted");
            }
        }

        public void Clear()
        {
            for (int i = 0; i < hashTable.Length; i++)
            {
                hashTable[i] = null;
            }
            size = 0;
        }

        public bool Contains(KeyValuePair<K, V> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(K key)
        {
            return (FindNode(key) != null);
        }


        public void CopyTo(KeyValuePair<K, V>[] array, int arrayIndex)
        {
            foreach (var pair in this)
            {
                array[arrayIndex++] = pair;
            }
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            for (int i = 0; i < hashTable.Length; i++)
            {
                for (Node n = hashTable[i]; n != null; n = n.Next)
                {
                    yield return new KeyValuePair<K, V>(n.Key, n.Value);
                }
            }
        }

        public bool Remove(KeyValuePair<K, V> item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(K key)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(K key, out V value)
        {
            Node n = FindNode(key);
            value = (n != null) ? n.Value : default(V);
            return n != null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #region Private Methods
        private Node FindNode(K key)
        {
            int idx = IndexFor(key);
            Node n = hashTable[idx];
            while (n != null)
            {
                if (n.Key.Equals(key))
                {
                    return n;
                }
                n = n.Next;
            }

            return null;
        }

        private int IndexFor(K key)
        {
            return Math.Abs(key.GetHashCode()) % hashTable.Length;
        }
        #endregion
    }
}

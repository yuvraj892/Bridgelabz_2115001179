using System;
using System.Collections.Generic;

class HashMap<K, V>
{
    private class HashNode
    {
        public K Key;
        public V Value;
        public HashNode Next;

        public HashNode(K key, V value)
        {
            Key = key;
            Value = value;
            Next = null;
        }
    }

    private readonly int bucketCount;
    private readonly LinkedList<HashNode>[] buckets;

    public HashMap(int size = 10)
    {
        bucketCount = size;
        buckets = new LinkedList<HashNode>[bucketCount];
        for (int i = 0; i < bucketCount; i++)
        {
            buckets[i] = new LinkedList<HashNode>();
        }
    }

    private int GetBucketIndex(K key)
    {
        int hashCode = key.GetHashCode();
        return Math.Abs(hashCode % bucketCount);
    }

    // Insert a key-value pair into the hash map
    public void Insert(K key, V value)
    {
        int index = GetBucketIndex(key);
        LinkedList<HashNode> bucket = buckets[index];

        foreach (var node in bucket)
        {
            if (EqualityComparer<K>.Default.Equals(node.Key, key))
            {
                node.Value = value; // Update if key already exists
                return;
            }
        }

        bucket.AddLast(new HashNode(key, value)); // Insert new node
    }

    // Retrieve a value without exception if the key doesn't exist
    public bool TryGetValue(K key, out V value)
    {
        int index = GetBucketIndex(key);
        LinkedList<HashNode> bucket = buckets[index];

        foreach (var node in bucket)
        {
            if (EqualityComparer<K>.Default.Equals(node.Key, key))
            {
                value = node.Value;
                return true;
            }
        }

        value = default(V);
        return false; // Key not found
    }

    // Remove a key-value pair from the hash map
    public bool Remove(K key)
    {
        int index = GetBucketIndex(key);
        LinkedList<HashNode> bucket = buckets[index];

        HashNode previous = null;
        foreach (var node in bucket)
        {
            if (EqualityComparer<K>.Default.Equals(node.Key, key))
            {
                bucket.Remove(node);
                return true; // Successfully removed
            }
            previous = node;
        }

        return false; // Key not found
    }

    public void Display()
    {
        for (int i = 0; i < bucketCount; i++)
        {
            Console.Write("Bucket " + i + ": ");
            foreach (var node in buckets[i])
            {
                Console.Write($"[{node.Key}, {node.Value}] -> ");
            }
            Console.WriteLine("null");
        }
    }
}

class Program
{
    public static void Main()
    {
        HashMap<string, int> map = new HashMap<string, int>();

        // Insert key-value pairs
        map.Insert("Apple", 10);
        map.Insert("Banana", 20);
        map.Insert("Cherry", 30);
        map.Insert("Date", 40);

        // Display the hash map
        map.Display();

        // Try retrieving a value
        if (map.TryGetValue("Banana", out int value))
        {
            Console.WriteLine("Value for 'Banana': " + value);
        }
        else
        {
            Console.WriteLine("'Banana' not found");
        }

        // Try removing a key
        if (map.Remove("Apple"))
        {
            Console.WriteLine("'Apple' removed successfully");
        }
        else
        {
            Console.WriteLine("'Apple' not found");
        }

        // Display after removal
        map.Display();
    }
}

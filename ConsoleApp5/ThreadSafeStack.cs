using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class ThreadSafeStack<T>
    {
        private object locker = new object();
        Stack<T> _stack = new Stack<T>();
        public void Push(T obj)
        {
            lock(locker)
            {
                _stack.Push(obj);
                Console.WriteLine($"Object {obj.ToString()} was Pushed to stack by Thread {Thread.CurrentThread.ManagedThreadId}");
            }
        }
        public T Pop()
        {
            lock (locker)
            {
                if (_stack.Count == 0)
                {
                    Console.WriteLine($"Stack is Empty");
                    return default(T);
                }

                var obj = _stack.Pop();
                Console.WriteLine($"Object {obj.ToString()} was Pop from stack by Thread {Thread.CurrentThread.ManagedThreadId}");
                return obj;
            }
        }
    }
    public static class extensions
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}

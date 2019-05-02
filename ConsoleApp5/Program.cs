using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadTask();
        }
        static void PubSubTask()
        {
            //Creating the publisher instance
            var pub = new Publisher();

            //Create 4 different subscribers from type1 and inject them the publisher
            var sub1 = new Subscriber1(pub);
            var sub2 = new Subscriber1(pub);
            var sub3 = new Subscriber1(pub);
            var sub4 = new Subscriber1(pub);
            //Create 4 different subscribers from type2 and inject them the publisher
            var sub21 = new Subscriber2(pub);
            var sub22 = new Subscriber2(pub);
            var sub23 = new Subscriber2(pub);
            var sub24 = new Subscriber2(pub);

            //fire the event
            pub.FireEvent();

        }

        static void ThreadTask()
        {
            //init the stack
            ThreadSafeStack<int> threadSafeStack = new ThreadSafeStack<int>();

            Random rnd = new Random();

            //Create 3 threads that push to the stack
            var threads = Enumerable.Range(0, 3).Select(x =>
             new Thread(() =>
                   {
                       //push 20 numbers
                       for (int i = 0; i < 20; i++)
                       {
                           threadSafeStack.Push(rnd.Next(0,20));
                       }
                   })).ToList();

            //Create 3 threads that pop from the stack
            threads.AddRange(Enumerable.Range(0, 3).Select(x =>
             new Thread(() =>
             {
                 //push 20 numbers
                 for (int i = 0; i < 20; i++)
                 {
                     threadSafeStack.Pop();
                 }
             })).ToList());

            //I wasn't sure if you wanted that the stack will be fill and afterwards will be empty,
            //so i added the shuffle method to make it harder

            //threads.Shuffle();

            foreach (var thread in threads)
            {
                thread.Start();
                thread.Join();
            }

            Console.ReadLine();
        }
    }

    
}

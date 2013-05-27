using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsDemo2
{
    class Program
    {
        static readonly Random Random = new Random();
        static readonly Semaphore Pool = new Semaphore(0, 2);
        static int count = 0;

        static void Main(string[] args)
        {
            Pool.Release(2);
            UpdateMessage();
            
            Console.WriteLine("Press Q to quit. Press enter to start a new task");

            while (!DidTheUserPressTheQKey())
            {
                IncrementCount();
                Task.Factory.StartNew(SomeBoringTask);
            }
        }

        private static bool DidTheUserPressTheQKey()
        {
            return Console.ReadKey(true).Key == ConsoleKey.Q;
        }

        private static void SomeBoringTask()
        {
            Pool.WaitOne();

            var foo = new CustomClass();
            foo.AddItems();
          
            // have a nap
            Thread.Sleep(Random.Next(5000, 10000));

            // release the semaphore
            Pool.Release();
            DecrementCount();
        }

        private static void IncrementCount()
        {
            count++;
            UpdateMessage();
        }

        private static void DecrementCount()
        {
            count--;
            UpdateMessage();
        }

        private static void UpdateMessage()
        {
            Console.WriteLine("{0} tasks running", count);
        }
    }

    public class CustomClass
    {
        public CustomClass()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public void AddItems()
        {
            // create some objects
            var list = new List<int>();
            for (var i = 0; i < 20; i++)
            {
                list.Add(i);
            }
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsDemo
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
            foo.CreateTempFile();

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
}

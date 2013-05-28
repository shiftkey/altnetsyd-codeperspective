using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadsDemo
{
    class Program
    {
        static readonly Random Random = new Random();
        static readonly Semaphore Pool = new Semaphore(0, 2);
        static int count;

        static void Main()
        {
            Pool.Release(2);
            UpdateMessage();
            
            Console.WriteLine("Press Q to quit. Press enter to start a new task");
            while (Console.ReadKey(true).Key != ConsoleKey.Q)
            {
                count++;
                UpdateMessage();
                Task.Factory.StartNew(SomeBoringTask);
            }
        }

        static void SomeBoringTask()
        {
            Pool.WaitOne();

            // do something in the task
            var item = new CustomClass();
            item.AddItems();
            item.CreateTempFile();

            // have a nap
            Thread.Sleep(Random.Next(5000, 10000));

            Console.WriteLine("Task {0} finished", item.Id);
            // release the semaphore
            Pool.Release();
            count--;
            UpdateMessage();
        }

        static void UpdateMessage()
        {
            Console.WriteLine("{0} tasks running", count);
        }
    }
}

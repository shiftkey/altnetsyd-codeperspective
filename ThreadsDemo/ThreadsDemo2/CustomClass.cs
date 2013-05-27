using System;
using System.Collections.Generic;
using System.IO;

namespace ThreadsDemo
{
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

        public void CreateTempFile()
        {
            var fileName = Path.GetTempFileName();
            File.WriteAllText(fileName, "I am writing a file at " + DateTime.Now.Ticks);
        }
    }
}
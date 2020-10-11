using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace DotTraceNUnitTest
{
    public class ClassStructUnitTest
    {
        private const int m_count = 1_000_000;
        [Test]
        public void UsingClass()
        {
            Console.WriteLine($"memory before execution:{GC.GetGCMemoryInfo().TotalAvailableMemoryBytes}");

            var students = new List<StudentClass>();
            for (var i = 0; i < m_count; i++)
            {
                students.Add(new StudentClass
                {
                    Level = int.MinValue
                });
            }

            Console.WriteLine($"student's count:{students.Count}");
            students.Clear();

            Console.WriteLine($"heap size: {GC.GetGCMemoryInfo().HeapSizeBytes}");
            Console.WriteLine($"memory in bytes end of execution: {GC.GetGCMemoryInfo().TotalAvailableMemoryBytes}");
        }

        [Test]
        public void UsingStruct()
        {
            Console.WriteLine($"memory before execution:{GC.GetGCMemoryInfo().TotalAvailableMemoryBytes}");

            var students = new List<StudentStruct>();
            for (var i = 0; i < m_count; i++)
            {
                students.Add(new StudentStruct
                {
                    Level = int.MinValue
                });
            }

            Console.WriteLine($"student's count:{students.Count}");
            students.Clear();

            Console.WriteLine($"heap size: {GC.GetGCMemoryInfo().HeapSizeBytes}");
            Console.WriteLine($"memory in bytes end of execution: {GC.GetGCMemoryInfo().TotalAvailableMemoryBytes}");
        }
    }

    public class StudentClass
    {
        public int Level { get; set; }
    }

    public struct StudentStruct
    {
        public int Level { get; set; }
    }
}
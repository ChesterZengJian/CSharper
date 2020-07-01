using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main Thread is {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            var cts = new CancellationTokenSource();
            try
            {
                Console.WriteLine($"Start loop");
                List<Task> taskList = new List<Task>();
                for (int i = 0; i < 100; i++)
                {
                    var str = $"task{i}";
                    if (!cts.IsCancellationRequested)
                    {
                        taskList.Add(Task.Run(() =>
                                            {
                                                Console.WriteLine($"Start task {str}, Thread id is {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                                                if (str == "task9")
                                                {
                                                    cts.Cancel();
                                                    throw new Exception($"Throw exception task {str}");
                                                }
                                                else if (str == "task30")
                                                {
                                                    throw new Exception($"Throw exception task {str}");
                                                }
                                                else if (str == "task40")
                                                {
                                                    throw new Exception($"Throw exception task {str}");
                                                }

                                                Console.WriteLine($"End task {str}");
                                            }, cts.Token));
                    }

                }

                Task.WhenAll(taskList.ToArray());
                Console.WriteLine($"End loop");
            }
            catch (AggregateException ae)
            {
                foreach (var e in ae.InnerExceptions)
                {
                    Console.WriteLine("===========");
                    Console.WriteLine(e.Message);
                    Console.WriteLine("===========");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("===========");
                Console.WriteLine(e.Message);
                Console.WriteLine("===========");
            }

            Console.WriteLine($"Task {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            Console.Read();
        }
    }
}

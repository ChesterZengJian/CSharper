﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            {
                var manualResetEvent = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem(t =>
                {
                    Console.WriteLine("Begin Task");
                    Thread.Sleep(
                        
                        3000);
                    manualResetEvent.Set();
                });
                Console.WriteLine("Wait One");
                if (manualResetEvent.WaitOne())
                {
                    Console.WriteLine("Completed");
                }

            }

            {
                //ThreadPool.QueueUserWorkItem(Console.WriteLine);
                //ThreadPool.SetMaxThreads(12, 12);
                //ThreadPool.GetMaxThreads(out var maxWorkThreads, out var maxCpThreads);
                //ThreadPool.GetMinThreads(out var minWorkThreads, out var minCpThreads);
                //Console.WriteLine($"workThreads={maxWorkThreads},cpThreads={maxCpThreads}");
                //Console.WriteLine($"workThreads={minWorkThreads},cpThreads={minWorkThreads}");
                //var manualResetEvent = new ManualResetEvent(false);
                //for (var i = 0; i < 13; i++)
                //{
                //    var k = i;
                //    ThreadPool.QueueUserWorkItem(t =>
                //    {
                //        Console.WriteLine($"Thread Id={Thread.CurrentThread.ManagedThreadId:00}");
                //        if (k == 12)
                //        {
                //            manualResetEvent.Set();
                //        }
                //        else
                //        {
                //            //Console.WriteLine("Start wait");
                //            manualResetEvent.WaitOne();
                //            //Console.WriteLine("End wait");
                //        }
                //    });
                //}

                //if (manualResetEvent.WaitOne())
                //{
                //    Console.WriteLine("Completed");
                //}
            }

            #region SemaphoreSlim

            //for (int i = 1; i < 7; i++)
            //{
            //    var threadName = $"Thread {i}";
            //    Task.Run(() => SemaphoreSlimDemo.AccessDb(threadName, 2));
            //}

            #endregion

            #region Exception Processing

            {
                //Console.WriteLine("Start compute .....");
                //try
                //{
                //    int textLength = await ExceptionProcessing.ComputeLengthAsync(null);
                //    Console.WriteLine($"The length of text is {textLength}");
                //}
                //catch (AggregateException aex)
                //{
                //    foreach (var ex in aex.InnerExceptions)
                //    {
                //        Console.WriteLine($"AggregateException:{ex.Message}");
                //    }
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine($"Exception:{ex.Message}");
                //}
            }

            {
                //var task = ExceptionProcessing.ThrowCancellationException();
                //Console.WriteLine($"Task status is {task.Status}");
            }

            {
                //var cts = new CancellationTokenSource();
                //var task = ExceptionProcessing.Delay30Seconds(cts.Token);
                //Console.WriteLine($"Initial task status:{task.Status}");
                //cts.CancelAfter(TimeSpan.FromSeconds(3));
                //Console.WriteLine($"After cancel task status:{task.Status}");
                //try
                //{
                //    task.Wait();
                //}
                //catch (AggregateException e)
                //{
                //    Console.WriteLine(e.InnerException);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}

                //Console.WriteLine($"Final status:{task.Status}");
            }

            {
                //Func<Task> lambda = async () => await Task.Delay(1000);
                //Func<int, Task<int>> anonMethod = async (sec) =>
                // {
                //     Console.WriteLine($"Start Task {sec}");
                //     await Task.Delay(TimeSpan.FromSeconds(sec));
                //     Console.WriteLine($"Finish Task {sec  }");
                //     return sec;
                // };
                //var first = anonMethod(5);
                //var second = anonMethod(3);
                //Console.WriteLine($"First result is {first.Result}");
                //Console.WriteLine($"Second result is {second.Result}");
            }

            {
                //await AsyncAwaitDemo.SumCharacterAsync(new List<char> { '1', 'a', '2', 'c', 't', 'q' });
            }

            {
                //Console.WriteLine(Environment.ProcessorCount);
            }

            #endregion

            //Console.WriteLine("Enter exit");
            Console.Read();
        }


    }
}

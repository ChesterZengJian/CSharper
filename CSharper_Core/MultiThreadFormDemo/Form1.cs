using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiThreadFormDemo
{
    public partial class Form1 : Form
    {
        private const string m_httpWwwBaiduCom = "https://www.google.com.  hk/webhp?hl=zh-CN&sa=X&ved=0ahUKEwjM-4Dp8bLqAhVWc3AKHV9gCmMQPAgH";
        private static readonly object m_lock = new object();

        private static bool m_isStop = false;
        private int m_num = 0;
        private List<Task> tasks = new List<Task>();

        public Form1()
        {
            InitializeComponent();
        }

        private class Test
        {
            private int m_num = 0;
            public void DoTest()
            {
                lock (this)
                {
                    m_num++;
                    if (m_num < 5)
                    {
                        DoTest();
                    }
                    else
                    {
                        Console.WriteLine($"Finished {m_num}");
                    }
                }
            }
        }

        private async void DoSomething(object sender, EventArgs e)
        {
            Console.WriteLine($"DoSomething, Main Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            #region 线程池使用
            //ThreadPool.QueueUserWorkItem(o =>
            //{
            //    Console.WriteLine($"*********{Thread.CurrentThread.ManagedThreadId}**************");
            //    Thread.Sleep(1000);
            //});
            //ThreadPool.QueueUserWorkItem(o =>
            //{
            //    Console.WriteLine($"*********{Thread.CurrentThread.ManagedThreadId}**************");
            //    Console.WriteLine($"o={o}");
            //    Thread.Sleep(1000);
            //}, "HH");
            #endregion

            #region 线程池最大最小线程
            //ThreadPool.GetMinThreads(out var workerThreads, out var completionPortThreads);
            //Console.WriteLine($"Min : workerThreads={workerThreads}; completionPortThreads={completionPortThreads}");
            //ThreadPool.GetMaxThreads(out var maxWorkerThreads, out var maxCompletionPortThreads);
            //Console.WriteLine($"Min : maxWorkerThreads={maxWorkerThreads}; maxCompletionPortThreads={maxCompletionPortThreads}");
            #endregion

            #region 线程池等待
            //var manualResetEvent = new ManualResetEvent(false);
            //ThreadPool.QueueUserWorkItem(o =>
            //{
            //    Console.WriteLine($"*********Callback Thread : {Thread.CurrentThread.ManagedThreadId}**************");
            //    Thread.Sleep(5000);
            //    manualResetEvent.Set();
            //});
            //manualResetEvent.WaitOne();

            //var manualResetEvent = new ManualResetEvent(false);
            //ThreadPool.SetMaxThreads(8, 8);
            //for (int i = 0; i < 10; i++)
            //{
            //    var k = i;
            //    ThreadPool.QueueUserWorkItem(o =>
            //    {
            //        Console.WriteLine(
            //            $"*********Callback Thread : {Thread.CurrentThread.ManagedThreadId}**************");
            //        Console.WriteLine($"k={k}");
            //        if (i == 9)
            //        {
            //            manualResetEvent.Set();
            //        }
            //        else
            //        {
            //            manualResetEvent.WaitOne();
            //        }
            //    });
            //}

            //if (manualResetEvent.WaitOne())
            //{
            //    Console.WriteLine("Loop ThreadPool Finished");
            //}

            #endregion

            #region Task

            //var task = new Task(() => { Console.WriteLine($"New Task Thread Id: {Thread.CurrentThread.ManagedThreadId}"); });
            //task.Start();

            //Task.Run(() => { Console.WriteLine($"Task Run Thread Id: {Thread.CurrentThread.ManagedThreadId}"); });

            //Task.Factory.StartNew(() => { Console.WriteLine($"Task Factory Thread Id: {Thread.CurrentThread.ManagedThreadId}"); });

            //var watch = new Stopwatch();
            //watch.Start();
            //Console.WriteLine($"Start in {watch.ElapsedMilliseconds}");
            //Task.Delay(2000).ContinueWith(t =>
            //{
            //    watch.Stop();
            //    Console.WriteLine($"Stop in {watch.ElapsedMilliseconds}");
            //});

            //List<Task> tasks = new List<Task>();
            //tasks.Add(Task.Factory.StartNew(() => { Console.WriteLine($"Task1; Thread Id:{Thread.CurrentThread.ManagedThreadId}"); }));
            //tasks.Add(Task.Factory.StartNew(() => { Console.WriteLine($"Task2; Thread Id:{Thread.CurrentThread.ManagedThreadId}"); }));
            //tasks.Add(Task.Factory.StartNew(() => { Console.WriteLine($"Task3; Thread Id:{Thread.CurrentThread.ManagedThreadId}"); }));
            //tasks.Add(Task.Factory.StartNew(() => { Console.WriteLine($"Task4; Thread Id:{Thread.CurrentThread.ManagedThreadId}"); }));
            //tasks.Add(Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine($"Task5; Thread Id:{Thread.CurrentThread.ManagedThreadId}");
            //    Thread.Sleep(5000);
            //}));
            //Task.Factory.ContinueWhenAll(tasks.ToArray(), t =>
            //{
            //    Console.WriteLine("All task completion");
            //});
            //Task.WaitAll(tasks.ToArray());
            //Task.WaitAny(tasks.ToArray());

            #endregion

            #region Parallel

            //Parallel.Invoke(() => { this.DelayAction("a1"); },
            //    () => { this.DelayAction("a2"); },
            //    () => { this.DelayAction("a3"); },
            //    () => { this.DelayAction("a4"); },
            //    () => { this.DelayAction("a5"); });

            //Parallel.For(0, 10, (i) =>
            //{
            //    Console.WriteLine($"Action {i} 's Thread Id {Thread.CurrentThread.ManagedThreadId} Start");
            //    Thread.Sleep(2000);
            //    Console.WriteLine($"Action {i} 's Thread Id {Thread.CurrentThread.ManagedThreadId} End");
            //});

            //var parallelOptions = new ParallelOptions();
            //parallelOptions.MaxDegreeOfParallelism = 2;
            //Parallel.ForEach(new string[] { "a", "b", "c", "d", "e", "f" }, t => { this.DelayAction(t); });



            #endregion

            #region 线程安全

            //for (int i = 0; i < 1000; i++)
            //{
            //    num++;
            //}

            //for (int i = 0; i < 100000; i++)
            //{
            //    Task.Run(() =>
            //    {
            //        lock (m_lock)
            //        {
            //            m_num++;
            //        }
            //    }).Wait();
            //}
            //Console.WriteLine(m_num);

            //var test = new Test();
            //test.DoTest();

            #endregion

            #region 双色球

            InitBalls();
            foreach (var control in this.Controls)
            {
                m_isStop = false;
                if (control is Label)
                {
                    var labelCtrl = (Label)control;
                    if (labelCtrl.Name.Contains("red", StringComparison.OrdinalIgnoreCase))
                    {
                        tasks.Add(Task.Run(() =>
                        {
                            try
                            {
                                while (!m_isStop)
                                {
                                    var num = GetRandomNumsDelay(0, m_redBalls.Count());
                                    lock (m_lock)
                                    {
                                        if (ValidateNum().Contains(num.ToString("00")))
                                        {
                                            continue;
                                        }
                                        this.Invoke(new Action(() => { labelCtrl.Text = num.ToString("00"); }));
                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }));
                    }
                    else if (labelCtrl.Name.Contains("blue", StringComparison.OrdinalIgnoreCase))
                    {

                    }
                }
            }

            #endregion

            Console.WriteLine("Finally");
        }

        private void Cancel(object sender, EventArgs e)
        {
            m_isStop = true;
            //Task.Factory.ContinueWhenAll(tasks.ToArray(), t => { this.ShowResult(); });
            Task.WhenAll(tasks.ToArray()).ContinueWith(t =>
            {
                this.ShowResult();
            });
        }

        private void DelayAction(string name)
        {
            Console.WriteLine($"Delay Action {name}'s Thread is {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000);
            Console.WriteLine($"Delay Action {name}'s Finished");
        }

        private async void DisplaySiteLengthAsync(object sender, EventArgs e)
        {
            this.label2.Text = "Loading.....";
            using var httpClient = new HttpClient();
            string text = await httpClient.GetStringAsync(m_httpWwwBaiduCom);
            this.label2.Text = text;
        }

        private async void DisplaySiteLength(object sender, EventArgs e)
        {
            this.label2.Text = "Loading....";
            using var webClient = new WebClient();
            this.label2.Text = webClient.DownloadString(m_httpWwwBaiduCom);
        }

        #region 双色球

        // 6红一蓝
        // 红全部随机（1-33）变化，不重复
        // 蓝全部随机（1-16）变化
        // 一共7组号码
        private List<string> m_redBalls = new List<string>();
        private List<string> m_blueBalls = new List<string>();

        private void InitBalls()
        {
            for (int i = 1; i <= 33; i++)
            {
                m_redBalls.Add(i.ToString("00"));
            }

            for (int i = 1; i < 33; i++)
            {
                m_blueBalls.Add(i.ToString("00"));
            }
        }

        private int GetRandomNumsDelay(int min, int max)
        {
            Thread.Sleep(this.GetRandomNums(1, 5));
            return GetRandomNums(min, max);
        }
        private int GetRandomNums(int min, int max)
        {
            var guid = Guid.NewGuid().ToString();
            var seedNum = DateTime.Now.Ticks;
            foreach (var ch in guid)
            {
                switch (ch)
                {
                    case 'z':
                    case 'a':
                    case 'b':
                        seedNum += 1;
                        break;
                    case 'g':
                    case 'd':
                    case '4':
                        seedNum += 2;
                        break;
                    case 'f':
                    case 'c':
                    case 'v':
                        seedNum += 4;
                        break;
                    case 'e':
                    case '1':
                    case '9':
                        seedNum += 8;
                        break;
                    case '3':
                    case '8':
                    case '7':
                        seedNum += 16;
                        break;
                    default:
                        seedNum += 32;
                        break;
                }
            }

            var random = new Random((int)seedNum);
            return random.Next(min, max);
        }

        private void ShowResult()
        {
            MessageBox.Show($"Red ball: {this.labelRed1.Text} {this.labelRed2.Text} {this.labelRed3.Text} {this.labelRed4.Text} {this.labelRed5.Text} {this.labelRed6.Text}");
        }

        private List<string> ValidateNum()
        {
            List<string> userNums = new List<string>();
            foreach (var control in this.Controls)
            {
                if (control is Label)
                {
                    var label = (Label)control;
                    if (label.Name.Contains("red", StringComparison.OrdinalIgnoreCase) && label.Text != "00")
                    {
                        userNums.Add(label.Text);
                    }
                }
            }

            return userNums;
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Threading.Tasks.Dataflow;

namespace TPLDataflowDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello TPL Dataflow!");

            var broadcastBlock = new BroadcastBlock<string>(s => s);
            var displayBlock = new ActionBlock<string>(s => { Console.WriteLine($"Display: {s}"); });
            var upperBlock = new TransformBlock<string, string>(s =>
              {
                  Console.WriteLine($"Upper: {s.ToUpper()}");
                  return s.ToUpper();
              });
            var saveBlock = new ActionBlock<string>(s => { Console.WriteLine($"Save: {s}"); });
            broadcastBlock.LinkTo(displayBlock);
            broadcastBlock.LinkTo(upperBlock);
            upperBlock.LinkTo(saveBlock);

            for (int i = 0; i < 10; i++)
            {
                broadcastBlock.Post($"b{i}");
            }

            broadcastBlock.Complete();
            var data = broadcastBlock.Receive();
            //Console.WriteLine($"Data is {data}");

            //JoinBlockDemo();

            //BatchBlockDemo();

            Console.Read();
        }

        private static void JoinBlockDemo()
        {
            var joinBlock = new JoinBlock<int, int, int>();
            joinBlock.Target1.Post(1);
            joinBlock.Target2.Post(3);
            joinBlock.Target3.Post(5);
            var data = joinBlock.Receive();
            Console.WriteLine($"Join block {data}");
        }

        private static void BatchBlockDemo()
        {
            var batchBlock = new BatchBlock<int>(10);

            for (var i = 0; i < 13; i++)
            {
                batchBlock.Post(i);
            }

            batchBlock.Complete();

            Console.WriteLine("Batch 1");
            var batch1 = batchBlock.Receive();
            foreach (var item in batch1)
            {
                Console.WriteLine($"{item}");
            }

            Console.WriteLine("Batch 2");
            var batch2 = batchBlock.Receive();
            foreach (var item in batch2)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}

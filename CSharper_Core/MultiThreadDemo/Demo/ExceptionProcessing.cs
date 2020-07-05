using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadDemo
{
    public class ExceptionProcessing
    {

        public static async Task<int> ComputeLengthAsync(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            await Task.Delay(TimeSpan.FromSeconds(5));
            return text.Length;
        }

        public static async Task ThrowCancellationException()
        {
            throw new OperationCanceledException();
        }

        public static async Task Delay30Seconds(CancellationToken cancellationToken)
        {
            Console.WriteLine("Waiting for 30s");
            await Task.Delay(TimeSpan.FromSeconds(30),cancellationToken);
        }

    }
}
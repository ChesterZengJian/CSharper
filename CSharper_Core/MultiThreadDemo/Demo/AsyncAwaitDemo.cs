using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadDemo
{
    public class AsyncAwaitDemo
    {
public static async Task<int> SumCharacterAsync(IEnumerable<char> para)
{
    int total = 0;
    foreach (var ch in para)
    {
        await Task.Delay((int)ch);
        total += (int)ch;
    }

    await Task.Yield();
    return total;
}
    }
}
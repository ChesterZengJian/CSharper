using System.Linq;
using System.Text;
using NUnit.Framework;

namespace DotTraceNUnitTest
{
    public class StringBuilderUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void UsingString()
        {
            var source = Enumerable.Range(0, 10)
                .Select(n => n.ToString())
                .ToArray();
            var str = string.Empty;
            for (int i = 0; i < 10_000; i++)
            {
                str += source[i % 10];
            }
        }

        [Test]
        public void UsingStringBuilder()
        {
            var source = Enumerable.Range(0, 10)
                .Select(n => n.ToString())
                .ToArray();
            var str = new StringBuilder();
            for (int i = 0; i < 10_000; i++)
            {
                str.Append(i % 10);
            }

            var _ = str.ToString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA.WCF.Service
{
    public class MathService : IMathService
    {
        public void SayHello()
        {
            Console.WriteLine("Hello Work");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA.WCF.Project
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                ServiceInit.Process();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}

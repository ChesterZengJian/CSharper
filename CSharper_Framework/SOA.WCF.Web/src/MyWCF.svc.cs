using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SOA.WCF.Web.src
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyWCF" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MyWCF.svc or MyWCF.svc.cs at the Solution Explorer and start debugging.
    public class MyWCF : IMyWcf
    {
        public void DoWork()
        {
        }

        public string GetUserName(string name)
        {
            return name;
        }

        public void HelloWork()
        {
            Console.WriteLine("Hello World");
        }
    }
}

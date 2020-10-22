using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SOA.WCF.Web.UnitTestProject.MyWebWCF;

namespace SOA.WCF.Web.UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            MyWCFClient client = null;
            try
            {
                client = new MyWCFClient();
                var request = new GetUserNameRequest("Chester");
                var response = client.GetUserName(request);
                // If it close error, it will throw exception. Such as network problem
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                client?.Abort();
                throw;
            }
        }
    }
}

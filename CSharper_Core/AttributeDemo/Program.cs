using AttributeDemo.Attributes;
using AttributeDemo.Models;
using System;
using System.Text;
using System.Web;
using AttributeDemo.Extensions;

namespace AttributeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);//注册Nuget包System.Text.Encoding.CodePages中的编码到.NET Core
            var str =
                "timestamp=1654172738&cpid=9829&password=d63038ea22041c2a6135c7d4a9efa9da&channelid=12863&tele=15229326166&msg=hello端午快乐";
            //var res = HttpUtility.UrlEncode("hello端午节快乐", Encoding.GetEncoding("GBK"));
            var res = HttpUtility.UrlEncode(str, Encoding.GetEncoding("GBK"));

            Console.WriteLine(res);

            //var student = new Student
            //{
            //    Id = "1",
            //    Name = "C"
            //};
            //student.Required();

            ////CustomAttributeExtension.Show<Student>();

            ////ValidateAttributeExtension.ValidateMaxLength<Student>(student);
            ////ValidateAttributeExtension.Validate<Student>(student);

            //Console.WriteLine("Hello World!");
        }
    }
}

using System;
using System.Reflection;
using System.Reflection.Emit;

namespace DelegateDemo.Extensions
{
    public class CustomDelegateExtension
    {
        public void Show()
        {
            Action action = new Action(Method);

            var methodInfo = this.GetType().GetMethod("Method");
            if (methodInfo.IsDefined(typeof(BeforeMethodAttribute), true))
            {
                methodInfo.GetCustomAttribute<BeforeMethodAttribute>().Do(action);
            }

            //action();

            if (methodInfo.IsDefined(typeof(AfterMethodAttribute), true))
            {
                methodInfo.GetCustomAttribute<AfterMethodAttribute>().Do();
            }

        }

        [BeforeMethod]
        [AfterMethod]
        public void Method()
        {
            Console.WriteLine("Service Logic");
        }

        public class BeforeMethodAttribute : Attribute
        {
            public Action Do(Action action)
            {
                Console.WriteLine("Before method");

                Action actionResult = new Action(action);

                action();

                return actionResult;
            }
        }

        public class AfterMethodAttribute : Attribute
        {
            public void Do()
            {
                Console.WriteLine("After method");
            }
        }
    }
}
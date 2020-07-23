using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace DelegateDemo.Delegates
{
    public class CustomDelegateExtension
    {
        public void Show()
        {
            var invokeAction = new InvokeAction();
            Action action = () => { invokeAction.Method(); };

            var type = invokeAction.GetType();
            var methodInfo = type.GetMethod("Method");
            if ((methodInfo ?? throw new InvalidOperationException()).IsDefined(typeof(BaseMethodAttribute)))
            {
                action = methodInfo.GetCustomAttributes<BaseMethodAttribute>()
                    .Reverse()
                    .Aggregate(action, (current, baseMethodAttribute) => baseMethodAttribute.Do(current));
            }

            action.Invoke();
        }
    }

    public class InvokeAction
    {
        [BeforeMethod]
        [BeforeWrite]
        public void Method()
        {
            Console.WriteLine("Method");
        }
    }

    public abstract class BaseMethodAttribute : Attribute
    {
        public abstract Action Do(Action action);
    }

    public class BeforeMethodAttribute : BaseMethodAttribute
    {
        public override Action Do(Action action)
        {
            Console.WriteLine("BeforeMethod");

            return new Action(() => { action(); });
        }
    }

    public class BeforeWriteAttribute : BaseMethodAttribute
    {
        public override Action Do(Action action)
        {
            Console.WriteLine("BeforeWrite");

            return new Action(() => { action(); });
        }
    }

    //public class AfterMethodAttribute : BaseMethodAttribute
    //{
    //    public override Action Do(Action action)
    //    {
    //        action = new Action(() => { action(); });
    //        Console.WriteLine("AfterMethod");
    //        return action;
    //    }
    //}
}
using System;
using System.Linq;
using System.Reflection;
using Castle.Core.Logging;
using Castle.DynamicProxy;

namespace Polly.Client.Common
{
    /// <inheritdoc />
    public class CustomInterceptor : StandardInterceptor
    {
        protected override void PreProceed(IInvocation invocation)
        {
            base.PreProceed(invocation);
        }

        protected override void PerformProceed(IInvocation invocation)
        {
            ISyncPolicy policy = null;

            Action<ISyncPolicy> action = p =>
            {
                p.Execute(() =>
                {
                    base.PerformProceed(invocation);
                });
            };

            #region Simple Version

            //if (invocation.Method.IsDefined(typeof(CustomPollyRetryAttribute), true))
            //{
            //    var attribute = invocation.Method.GetCustomAttribute<CustomPollyRetryAttribute>(true);
            //    action = attribute.Do(action);
            //}

            #endregion

            #region Common Version

            if (invocation.Method.IsDefined(typeof(CustomPollyAttribute), true))
            {
                var attributes = invocation.Method.GetCustomAttributes<CustomPollyAttribute>(true);
                action = attributes.Aggregate(action, (current, attribute) => attribute.Do(current));
            }

            #endregion

            action.Invoke(policy);
        }

        protected override void PostProceed(IInvocation invocation)
        {
            base.PostProceed(invocation);
        }
    }

    public abstract class CustomPollyAttribute : Attribute
    {
        public abstract Action<ISyncPolicy> Do(Action<ISyncPolicy> action);
    }

    public class CustomPollyRetryAttribute : CustomPollyAttribute
    {
        public override Action<ISyncPolicy> Do(Action<ISyncPolicy> action)
        {
            ISyncPolicy retryPolicy = Policy.Handle<Exception>()
                .Retry(retryCount: 2, (ex, count) =>
                {
                    Console.WriteLine("=================================");
                    Console.WriteLine($"Retry: {count}");
                    Console.WriteLine($"Exception Message: {ex.Message}");
                    Console.WriteLine("=================================");
                });

            return s =>
            {
                ISyncPolicy policy = null;
                policy = s != null ? Policy.Wrap(s, retryPolicy) : retryPolicy;

                action(policy);
            };
        }
    }

    public class CustomPollyFallbackAttribute : CustomPollyAttribute
    {
        public override Action<ISyncPolicy> Do(Action<ISyncPolicy> action)
        {
            ISyncPolicy fallbackPolicy = Policy.Handle<Exception>()
                .Fallback(() =>
                {
                    Console.WriteLine("=================================");
                    Console.WriteLine("The Second");
                    Console.WriteLine("=================================");
                }, e =>
                {
                    Console.WriteLine("=================================");
                    Console.WriteLine($"exception:{e.Message}");
                    Console.WriteLine("=================================");
                });

            return s =>
            {
                ISyncPolicy policy = null;
                policy = s != null ? Policy.Wrap(s, fallbackPolicy) : fallbackPolicy;

                action(policy);
            };
        }
    }
}
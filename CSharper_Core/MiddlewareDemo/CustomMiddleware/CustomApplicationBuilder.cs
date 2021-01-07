using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiddlewareDemo.CustomMiddleware
{
    public interface ICustomApplicationBuilder
    {
        CustomRequestDelegate Build();

        CustomApplicationBuilder New();

        CustomApplicationBuilder Use(Func<CustomRequestDelegate, CustomRequestDelegate> middleware);
    }

    public delegate void CustomRequestDelegate(CustomHttpContext context);

    public class CustomHttpContext
    {
        public void Show()
        {
            Console.WriteLine("This is a custom http context....");
        }
    }

    public class CustomApplicationBuilder : ICustomApplicationBuilder
    {
        private static List<Func<CustomRequestDelegate, CustomRequestDelegate>> _middlewares = new List<Func<CustomRequestDelegate, CustomRequestDelegate>>();

        public CustomRequestDelegate Build()
        {
            CustomRequestDelegate customRequestDelegate = context => Console.WriteLine("This is a custom request context instance in the builder");

            _middlewares.Reverse();

            foreach (var middleware in _middlewares)
            {
                customRequestDelegate = middleware.Invoke(customRequestDelegate);
            }

            return customRequestDelegate;
        }

        public CustomApplicationBuilder New()
        {
            return new CustomApplicationBuilder();
        }

        public CustomApplicationBuilder Use(Func<CustomRequestDelegate, CustomRequestDelegate> middleware)
        {
            _middlewares.Add(middleware);
            return this;
        }
    }
}
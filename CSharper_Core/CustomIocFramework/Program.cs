using System;
using CustomIocFramework.CommonEnums;
using CustomIocFramework.Services;

namespace CustomIocFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                //var customIoc = new CustomIoc();
                //customIoc.Register<IUserService, UserService>();
                //customIoc.Register<IOrderService, OrderService>();
                //customIoc.Register<IGoodsService, GoodsService>();

                //var userService = customIoc.Resolve<IUserService>();
                //userService.SayHello("Chester");
                //var goods = customIoc.Resolve<IGoodsService>();
            }

            #region Transient

            //{
            //    var customIoc = new CustomIoc();
            //    customIoc.Register<IUserService, UserService>();
            //    customIoc.Register<IOrderService, OrderService>();
            //    customIoc.Register<IGoodsService, GoodsService>();

            //    var userService1 = customIoc.Resolve<IUserService>();
            //    var userService2 = customIoc.Resolve<IUserService>();
            //    Console.WriteLine($"Transient: userService1 equal userService2: {ReferenceEquals(userService1, userService2)}");
            //}

            #endregion

            #region Singleton

            {
                var customIoc = new CustomIoc();
                customIoc.Register<IUserService, UserService>(CustomLifetime.Singleton);
                customIoc.Register<IOrderService, OrderService>(CustomLifetime.Transient);
                customIoc.Register<IGoodsService, GoodsService>();

                var userService1 = customIoc.Resolve<IUserService>();
                var userService2 = customIoc.Resolve<IUserService>();
                var orderService = customIoc.Resolve<IOrderService>();
                Console.WriteLine($"Singleton: userService1 equal userService2: {ReferenceEquals(userService1, userService2)}");
                Console.WriteLine($"Singleton: userService1.orderService equal userService2.orderService: {ReferenceEquals(userService1.GetOrderService(), userService2.GetOrderService())}");
                Console.WriteLine($"Singleton: userService1.orderService equal orderService: {ReferenceEquals(userService1.GetOrderService(), orderService)}");
            }

            #endregion

            Console.Read();
        }
    }
}

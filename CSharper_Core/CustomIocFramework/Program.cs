using System;
using CustomIocFramework.Services;

namespace CustomIocFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var customIoc = new CustomIoc();
            customIoc.Register<IUserService, UserService>();
            customIoc.Register<IOrderService, OrderService>();
            customIoc.Register<IGoodsService, GoodsService>();
            var userService = customIoc.Resolve<IUserService>();
            userService.SayHello("Chester");

            Console.Read();
        }
    }
}

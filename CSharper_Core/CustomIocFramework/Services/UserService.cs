using System;

namespace CustomIocFramework.Services
{
    public interface IUserService
    {
        void SayHello(string name);

        IOrderService GetOrderService();
    }

    public class UserService : IUserService
    {
        private readonly IOrderService m_orderService;
        private readonly IGoodsService m_goodsService;

        public UserService(IOrderService orderService, IGoodsService goodsService)
        {
            m_orderService = orderService;
            m_goodsService = goodsService;
        }


        public void SayHello(string name)
        {
            Console.WriteLine($"Hello {name}");
        }

        public IOrderService GetOrderService()
        {
            return m_orderService;
        }

    }
}
namespace CustomIocFramework.Services
{
    public interface IOrderService
    {

    }

    public class OrderService : IOrderService
    {
        private readonly IGoodsService m_goodsService;

        public OrderService(IGoodsService goodsService)
        {
            m_goodsService = goodsService;
        }
    }
}

namespace Mini_Shop.Modulers.Orders.Orders_Data_Store
{
    internal class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }

    internal class OrderDataStore
    {
        private readonly List<Order> _orders = new();
        private readonly object _lock = new();
        private int _nextId = 1;

        public Order Add(int userId, int productId, int quantity)
        {
            lock (_lock)
            {
                var newOrder = new Order
                {
                    OrderId = _nextId++,
                    ProductId = productId,
                    UserId = userId,
                    Quantity = quantity,
                    OrderDate = DateTime.UtcNow
                };

                _orders.Add(newOrder);

                return newOrder;
            }
        }

        public List<Order> GetOrderByUserId(int userId)
        {
            lock (_lock)
            {
                return _orders
                    .Where(order => order.UserId == userId)
                    .Select(order => new Order
                    {
                        OrderId = order.OrderId,
                        ProductId = order.ProductId,
                        UserId = order.UserId,
                        Quantity = order.Quantity,
                        OrderDate = order.OrderDate
                    })
                    .ToList();
            }
        }
    }
}

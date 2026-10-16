namespace Mini_Shop.Modulers.Orders.Orders_Data_Store
{
    internal class Order { 
        public int OrderId  { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }

        
    }
    
    internal class OrderDataStore
    {
        private Order[] _orders=new Order[0];
        private int _nextID = 1;

        public Order Add(int userID ,int productId,int quantity) {

            var newOrder = new Order {
                OrderId=_nextID++,
                ProductId=productId,
                UserId=userID,
                Quantity=quantity,
                OrderDate=DateTime.UtcNow
            };

            Array.Resize(ref _orders, _orders.Length+1);
            _orders[_orders.Length-1] = newOrder;

            return newOrder;
            }

        public Order[] GetOrderByUserId(int userID) { 
            return _orders.Where(i=>i.UserId==userID).ToArray();
        }
    }
}

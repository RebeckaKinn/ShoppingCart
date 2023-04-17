namespace ShoppingCart
{
    public class OrderLine
    {
        private Product _product;
        private int _count;

        public OrderLine(Product newProduct, int quantity)
        {
            _product = newProduct;
            _count = quantity;
        }

        //public void RemoveItems(int itemsToRemove)
        //{
        //    _count = _count - itemsToRemove;
        //}

        public void AddItems(int itemsToAdd)
        {
            _count = _count + itemsToAdd;
        }

        public Product ShowProduct()
        {
            return _product;
        }

        public int TotalCount(Product product)
        {
            return _count * product.ShowPrice();
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_count} stk " +
                    $"{ShowProduct().ShowName()} " +
                    $"{ShowProduct().ShowPrice()} kr " +
                    $"= {TotalCount(ShowProduct())}");
        }

        public bool IsInCart(Product product, List<OrderLine> cart, int amount)
        {
            foreach (var order in cart.Where(order => order.ShowProduct().ShowName() == product.ShowName()))
            {
                order.AddItems(amount);
                return true;
            }
            return false;
        }
    }
}

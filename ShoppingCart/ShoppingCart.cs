namespace ShoppingCart
{
    internal class ShoppingCart
    {
        public List<Product> Store = new List<Product>
        {
            new Product("A", 40),
            new Product("B", 70),
            new Product("C", 30),
        };
        public List<OrderLine> Cart = new List<OrderLine>();

        public Product GetProductFromStore(string productName)
        {
            return Store.First(i => productName == i.Name);
        }
        public void AddToCart(Product product, int amount)
        {
            var newItem = new OrderLine(product, amount);
            if (IsInCart(product, Cart, amount)) return;
            Cart.Add(newItem);
        }
        public void AddToCart(Product product)
        {
            AddToCart(product, 1);
        }
        public void AddToCart(string product, int amount)
        {
            AddToCart(GetProductFromStore(product), amount);
        }
        public void AddToCart(string product)
        {
            AddToCart(GetProductFromStore(product), 1);
        }

        public void RemoveFromCart(OrderLine product)
        {
            Cart.Remove(product);
        }
        public void ShowCart()
        {
            if (Cart.Count == 0)
            {
                Console.WriteLine("Handlekurven er tom.");
                return;
            }
            Console.WriteLine("Handlekurv:");
            int totalSum = 0;
            foreach (OrderLine item in Cart)
            {
                item.ShowInfo();
                totalSum += item.TotalCount(item.ShowProduct());
            }
            Console.WriteLine($"\nTotalt: {totalSum} kr.\n");
        }
        public bool IsInCart(Product product, List<OrderLine> cart, int amount)
        {
            foreach (var order in cart.Where(order => order.ShowProduct().Name == product.Name))
            {
                order.AddItems(amount);
                return true;
            }
            return false;
            //return cart.Any(ol => ol.ShowProduct() == product);
        }
    }
}

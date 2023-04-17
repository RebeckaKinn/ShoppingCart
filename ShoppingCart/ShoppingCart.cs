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
            /*var orderLine = Cart.FirstOrDefault(ol => ol.ShowProduct() == product);
            if (orderLine != null)
            {
                orderLine.AddItems(amount);
            }
            else
            {
                var newItem = new OrderLine(product, amount);
                Cart.Add(newItem);
            }
             */
            if (Cart.Any(p => p.Product == product))
            {
                var orderLine = Cart.FirstOrDefault(p => p.Product == product);
                orderLine.AddItems(amount);
            }
            else Cart.Add(new OrderLine(product, amount));
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
                totalSum += item.TotalCount(item.Product);
            }
            Console.WriteLine($"\nTotalt: {totalSum} kr.\n");
        }
    }
}

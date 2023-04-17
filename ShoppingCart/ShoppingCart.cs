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
            return Store.First(i => productName == i.ShowName());
        }
        public void AddToCart(Product product, int amount)
        {
            var newItem = new OrderLine(product, amount);
            if (newItem.IsInCart(product, Cart, amount)) return;
            Cart.Add(newItem);
        }
        public void AddToCart(Product product)
        {
            var newItem = new OrderLine(product, 1);
            if (newItem.IsInCart(product, Cart, 1)) return;
            Cart.Add(newItem);
        }
        public void AddToCart(string product, int amount)
        {
            var newProduct = GetProductFromStore(product);
            var newItem = new OrderLine(newProduct, amount);
            if (newItem.IsInCart(newProduct, Cart, amount)) return;
            Cart.Add(newItem);
        }
        public void AddToCart(string product)
        {
            var newProduct = GetProductFromStore(product);
            var newItem = new OrderLine(newProduct, 1);
            if (newItem.IsInCart(newProduct, Cart, 1)) return;
            Cart.Add(newItem);
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
    }
}

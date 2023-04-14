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
            if (Cart.Contains(newItem)) newItem.AddItems(amount);
            else Cart.Add(newItem);
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
            else
            {
                Console.WriteLine("Handlekurv:");
                int totalSum = 0;
                foreach (OrderLine item in Cart)
                {
                    Console.WriteLine($"{item.ShowCount()} stk " +
                        $"{item.ShowProduct().ShowName()} " +
                        $"{item.ShowProduct().ShowPrice()} kr " +
                        $"= {item.TotalCount(item.ShowProduct())}");
                    totalSum += item.TotalCount(item.ShowProduct());
                }
                Console.WriteLine($"\nTotalt: {totalSum} kr.\n");
            }
        }
    }
}

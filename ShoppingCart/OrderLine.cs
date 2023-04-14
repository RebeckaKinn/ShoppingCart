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

        public void RemoveItems(int itemsToRemove)
        {
            _count = _count - itemsToRemove;
        }

        public void AddItems(int itemsToAdd)
        {
            _count = _count + itemsToAdd;
        }

        public int ShowCount()
        {
            return _count;
        }

        public Product ShowProduct()
        {
            return _product;
        }

        public int TotalCount(Product product)
        {
            return _count * product.ShowPrice();
        }
    }
}

﻿namespace ShoppingCart
{
    public class OrderLine
    {
        public Product Product { get; }
        private int _count;

        public OrderLine(Product newProduct, int quantity)
        {
            Product = newProduct;
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

        public int TotalCount(Product product)
        {
            return _count * product.Price;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{_count} stk " +
                    $"{Product.Name} " +
                    $"{Product.Price} kr " +
                    $"= {TotalCount(Product)}");
        }
    }
}

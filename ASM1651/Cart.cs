using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM1651
{
    public class Cart
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }

        public Cart(int id)
        {
            Id = id;
            Products = new List<Product>();
        }

        public void AddToCart(Product product)
        {
            Products.Add(product);
        }

        public void RemoveFromCart(int productId)
        {
            Product productToRemove = Products.Find(p => p.Id == productId);
            if (productToRemove != null)
            {
                Products.Remove(productToRemove);
            }
            else
            {
                Console.WriteLine("Product not found in cart.");
            }
        }

        public void ViewCart()
        {
            if (Products.Count > 0)
            {
                Console.WriteLine($"Cart {Id} contents:");
                foreach (Product product in Products)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine("Cart is empty.");
            }
        }

        public void Checkout()
        {
            if (Products.Count > 0)
            {
                decimal totalPrice = 0;
                Console.WriteLine($"Checking out cart {Id}:");
                foreach (Product product in Products)
                {
                    Console.WriteLine(product);
                    totalPrice += product.Price;
                }
                Console.WriteLine($"Total price: {totalPrice}");
                Products.Clear();
            }
            else
            {
                Console.WriteLine("Cart is empty. Nothing to checkout.");
            }
        }
    }
}

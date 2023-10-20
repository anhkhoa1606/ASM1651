using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM1651
{
    public class Customer : User
    {
        public List<Cart> Carts { get; set; }

        public Customer(string username, string password)
            : base(username, password)
        {
            Carts = new List<Cart>();
        }

        public override void DisplayMenu()
        {
            base.DisplayMenu();
            Console.WriteLine("========== CUSTOMER MENU ==========");
            Console.WriteLine("1. Display available products");
            Console.WriteLine("2. Create Cart");
            Console.WriteLine("3. Add a product to cart");
            Console.WriteLine("4. Remove a product from cart");
            Console.WriteLine("5. View cart");
            Console.WriteLine("6. Checkout");
            Console.WriteLine("7. Exit");
        }

        public void DisplayAvailableProducts(List<Product> products)
        {
            Console.WriteLine("Available products:");
            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }
        }


        public void CreateCart()
        {
            int newCartId = Carts.Count + 1;
            Cart newCart = new Cart(newCartId);
            Carts.Add(newCart);
            Console.WriteLine("New cart created with ID: " + newCartId);
        }
        public void AddToCart(List<Product> products)
        {
            Console.Write("Enter product ID to add to cart: ");
            int idToAdd = Convert.ToInt32(Console.ReadLine());
            Product productToAdd = products.Find(p => p.Id == idToAdd);
            if (productToAdd != null)
            {
                Console.Write("Enter cart ID: ");
                int cartId = Convert.ToInt32(Console.ReadLine());

                Cart cart = Carts.Find(c => c.Id == cartId);
                if (cart == null)
                {
                    cart = new Cart(cartId);
                    Carts.Add(cart);
                }

                cart.AddToCart(productToAdd);
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public void RemoveFromCart()
        {
            Console.Write("Enter cart ID to remove from: ");
            int cartId = Convert.ToInt32(Console.ReadLine());
            Cart cart = Carts.Find(c => c.Id == cartId);
            if (cart != null)
            {
                if (cart.Products.Count > 0)
                {
                    Console.Write("Enter product ID to remove from cart: ");
                    int idToRemove = Convert.ToInt32(Console.ReadLine());
                    cart.RemoveFromCart(idToRemove);
                }
                else
                {
                    Console.WriteLine("Cart is empty.");
                }
            }
            else
            {
                Console.WriteLine("Cart not found.");
            }
        }

        public void ViewCart()
        {
            Console.Write("Enter cart ID to view: ");
            int cartId = Convert.ToInt32(Console.ReadLine());
            Cart cart = Carts.Find(c => c.Id == cartId);
            if (cart != null)
            {
                cart.ViewCart();
            }
            else
            {
                Console.WriteLine("Cart not found.");
            }
        }

        public void Checkout()
        {
            Console.Write("Enter cart ID to checkout: ");
            int cartId = Convert.ToInt32(Console.ReadLine());
            Cart cart = Carts.Find(c => c.Id == cartId);
            if (cart != null)
            {
                cart.Checkout();
                Carts.Remove(cart);
            }
            else
            {
                Console.WriteLine("Cart not found.");
            }
        }
    }

}

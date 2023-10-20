using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM1651
{
    public class Admin : User
    {
        public Admin(string username, string password)
            : base(username, password)
        {
        }

        public override void DisplayMenu()
        {
            base.DisplayMenu();
            Console.WriteLine("========== ADMIN MENU ==========");
            Console.WriteLine("1. Display available products");
            Console.WriteLine("2. Add a product");
            Console.WriteLine("3. Remove a product");
            Console.WriteLine("4. Update a product");
            Console.WriteLine("5. Exit");
        }

        public void DisplayAvailableProducts(List<Product> products)
        {
            Console.WriteLine("Available products:");
            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }
        }

        public void AddProduct(List<Product> products)
        {
            HashSet<int> previousProductIds = new HashSet<int>(); 
            int productId = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.Write("Enter product ID: ");
                string productIdInput = Console.ReadLine();

                try
                {
                    productId = int.Parse(productIdInput);

                    if (previousProductIds.Contains(productId))
                    {
                        Console.WriteLine("Product ID cannot be the same as a previously entered ID. Please choose a different ID.");
                    }
                    else
                    {
                        previousProductIds.Add(productId); 
                        validInput = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("The information entered is incorrect, please re-enter.");
                }
            }
            /*string productName = Console.ReadLine();*/
            string productName = null;
            validInput = false;

            while (!validInput)
            {
                Console.Write("Enter product name: ");
                string productNameInput = Console.ReadLine();

                if (!int.TryParse(productNameInput, out _))
                {
                    productName = productNameInput;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("The information entered is incorrect, please re-enter.");
                }
            }
           /* decimal productPrice = Convert.ToDecimal(Console.ReadLine());*/
            decimal productPrice = 0;
            validInput = false;

            while (!validInput)
            {
                Console.Write("Enter product price: ");
                string productPriceInput = Console.ReadLine();

                try
                {
                    productPrice = decimal.Parse(productPriceInput);
                    validInput = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("The information entered is incorrect, please re-enter.");
                }
            }

            Console.Write("Enter additional info (author/size): ");
            string additionalInfo = Console.ReadLine();

            Product product;
            if (additionalInfo.Contains('/'))
            {
                string[] infoParts = additionalInfo.Split('/');
                string author = infoParts[0];
                string size = infoParts[1];
                product = new Book(productId, productName, productPrice, author);
            }
            else
            {
                string size = additionalInfo;
                product = new Clothing(productId, productName, productPrice, size);
            }
            Program.Products.Add(product);
            Console.WriteLine("Product added.");
        }

        public void RemoveProduct(List<Product> products)
        {
            Console.Write("Enter product ID to remove: ");
            int idToRemove = Convert.ToInt32(Console.ReadLine());
            Product productToRemove = products.Find(p => p.Id == idToRemove);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);

                Console.WriteLine("Product removed.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        public void UpdateProduct(List<Product> products)
        {
            Console.Write("Enter product ID to update: ");
            int idToUpdate = Convert.ToInt32(Console.ReadLine());
            Product productToUpdate = products.Find(p => p.Id == idToUpdate);
            if (productToUpdate != null)
            {
                Console.Write("Enter new name: ");
                string newName = Console.ReadLine();
                Console.Write("Enter new price: ");
                decimal newPrice = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter new additional info: ");
                string newAdditionalInfo = Console.ReadLine();

                productToUpdate.Name = newName;
                productToUpdate.Price = newPrice;
                productToUpdate.UpdateAdditionalInfo(newAdditionalInfo);
                Console.WriteLine("Product updated.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }


    }
}

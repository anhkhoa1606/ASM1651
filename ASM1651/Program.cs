using ASM1651;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ASM1651
{
    public class Program
    {
        public static List<Product> Products { get; set; }

        static void Main(string[] args)
        {
            Products = ReadProductsFromFile("D:\\1618\\ASM1651\\ASM1651\\products.txt");

            bool loggedIn = false;
            User currentUser = null;

            while (!loggedIn)
            {
                Console.WriteLine("Please login:");
                Console.Write("Enter username: ");
                string username = Console.ReadLine();
                Console.Write("Enter password: ");
                string password = Console.ReadLine();

                currentUser = User.Login(username, password);

                if (currentUser != null)
                {
                    loggedIn = true;
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Please try again.");
                }

                //if (loggedIn)
                {
                    while (loggedIn)
                    {
                        Console.WriteLine();
                        currentUser.DisplayMenu();
                        Console.Write("Enter your choice: ");
                        string choice = Console.ReadLine();

                        if (currentUser is Admin)
                        {
                            Admin admin = (Admin)currentUser;
                            switch (choice)
                            {
                                case "1":
                                    admin.DisplayAvailableProducts(Products);
                                    break;
                                case "2":
                                    admin.AddProduct(Products);
                                    SaveProductsToFile("D:\\1618\\ASM1651\\ASM1651\\products.txt", Products);

                                    break;

                                case "3":
                                    admin.RemoveProduct(Products);
                                    SaveProductsToFile("D:\\1618\\ASM1651\\ASM1651\\products.txt", Products);

                                    break;
                                case "4":
                                    admin.UpdateProduct(Products);
                                    break;
                                    SaveProductsToFile("D:\\1618\\ASM1651\\ASM1651\\products.txt", Products);

                                case "5":
                                    loggedIn = false; // Logout and return to the login screen
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice. Please try again.");
                                    break;
                            }
                        }
                        else if (currentUser is Customer)
                        {
                            Customer customer = (Customer)currentUser;
                            switch (choice)
                            {
                                case "1":
                                    customer.DisplayAvailableProducts(Products);
                                    break;
                                case "2":
                                    customer.CreateCart();
                                    Console.WriteLine("New cart created.");
                                    break;

                                case "3":
                                    customer.AddToCart(Products);
                                    Console.WriteLine("Product added to cart.");
                                    break;
                                case "4":
                                    customer.RemoveFromCart();
                                    Console.WriteLine("Product removed from cart.");
                                    break;
                                case "5":
                                    customer.ViewCart();
                                    break;
                                case "6":
                                    customer.Checkout();
                                    break;
                                case "7":

                                    loggedIn = false; 
                                    break;
                                default:
                                    Console.WriteLine("Invalid choice. Please try again.");
                                    break;
                            }
                        }

                        if (!loggedIn)
                        {
                            break;
                        }
                    }
                }
            }
        }

        private static List<Product> ReadProductsFromFile(string filePath)
        {
            List<Product> products = new List<Product>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        int id = Convert.ToInt32(parts[0]);
                        string name = parts[1];
                        decimal price = Convert.ToDecimal(parts[2]);
                        string additionalInfo = parts[3];

                        Product product;
                        if (additionalInfo.Contains('/'))
                        {
                            string[] infoParts = additionalInfo.Split('/');
                            string author = infoParts[0];
                            string size = infoParts[1];
                            product = new Book(id, name, price, author);
                        }
                        else
                        {
                            string size = additionalInfo;
                            product = new Clothing(id, name, price, size);
                        }

                        products.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading products: " + ex.Message);
            }

            return products;
        }

        private static void SaveProductsToFile(string filePath, List<Product> products)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (Product product in Program.Products)
                    {
                        string line = $"{product.Id},{product.Name},{product.Price},{product.GetAdditionalInfo()}";
                        writer.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving products: " + ex.Message);
            }
        }
    }
}





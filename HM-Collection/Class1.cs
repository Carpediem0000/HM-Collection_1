using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HM_Collection
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            return $"Id => {Id}, Name => {Name}";
        }
    }

    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Manufacturer(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            return $"Id => {Id}, Name => {Name}";
        }
    }

    public class Product : IComparable<Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Product(int id, string name, decimal price, Category category, Manufacturer manufacturer)
        {
            Id = id;
            Name = name;
            Price = price;
            Category = category;
            Manufacturer = manufacturer;
        }

        public int CompareTo(Product? other)
        {
            return Price.CompareTo(other?.Price);
        }
        public override string ToString()
        {
            return $"Id => {Id}, Name => {Name}, Price => {Price} uah, Category => {Category.Name}, Manufacturer => {Manufacturer.Name}";
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Customer(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
        public override string ToString()
        {
            return $"Id => {Id}, Name => {Name}, Email => {Email}";
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; }
        public Order(int id, DateTime date, Customer customer, List<Product> products)
        {
            Id = id;
            Date = date;
            Customer = customer;
            Products = products;
        }
        public override string ToString()
        {
            string res = $"Id => {Id}, Date => {Date}, Customer => {Customer.Name}\n-------------Products-------------\n";
            foreach (Product prod in Products)
            {
                res += $"{prod.Name} - {prod.Price} uah";
            }
            return res;
        }
    }

    public class DBContext
    {
        public List<Category> Categories { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> Products { get; set; }
        public DBContext(List<Category> categories, List<Manufacturer> manufacturers, List<Customer> customers, List<Order> orders, List<Product> products)
        {
            Categories = categories;
            Manufacturers = manufacturers;
            Customers = customers;
            Orders = orders;
            Products = products;
        }
        public DBContext()
        {
            Categories = new List<Category>();
            Manufacturers = new List<Manufacturer>();
            Customers = new List<Customer>();
            Orders = new List<Order>();
            Products = new List<Product>();
        }

        public void showCategories()
        {
            Console.WriteLine("-------------Categories-------------");
            foreach (Category category in Categories)
            {
                Console.WriteLine(category);
                Console.WriteLine("+++++++++++++++++++++++++++++");
            }
            Console.WriteLine("================================================");
        }
        public void showManufacturers()
        {
            Console.WriteLine("-------------Manufacturers-------------");
            foreach (Manufacturer manufacturer in Manufacturers)
            {
                Console.WriteLine(manufacturer);
                Console.WriteLine("+++++++++++++++++++++++++++++");
            }
            Console.WriteLine("================================================");
        }
        public void showCustomers()
        {
            Console.WriteLine("-------------Customers-------------");
            foreach (Customer customer in Customers)
            {
                Console.WriteLine(customer);
                Console.WriteLine("+++++++++++++++++++++++++++++");
            }
            Console.WriteLine("================================================");
        }
        public void showOrders()
        {
            Console.WriteLine("-------------Orders-------------");
            foreach (Order order in Orders)
            {
                Console.WriteLine(order);
                Console.WriteLine("+++++++++++++++++++++++++++++");
            }
            Console.WriteLine("================================================");
        }
        public void showProducts()
        {
            Console.WriteLine("-------------Products-------------");
            foreach (Product product in Products)
            {
                Console.WriteLine(product);
                Console.WriteLine("+++++++++++++++++++++++++++++");
            }
            Console.WriteLine("================================================");
        }
        public Product searchProductById(int id)
        {
            foreach (Product prod in Products)
            {
                if (prod.Id == id)
                {
                    return prod;
                }
            }
            Console.WriteLine("Product not found");
            return null;
        }
        public void show()
        {
            showProducts();
            showCategories();
            showManufacturers();
            showOrders();
            showCustomers();
        }
        public void SortProduct()
        {
            Products.Sort();
        }
        public void addCategory(Category category)
        {
            if (category != null)
            {
                Categories.Add(category);
            }
        }
        public void addManufacturer(Manufacturer manufacturer)
        {
            if (manufacturer != null)
            {
                Manufacturers.Add(manufacturer);
            }
        }
        public void addCustomer(Customer customer)
        {
            if (customer != null)
            {
                Customers.Add(customer);
            }
        }
        public void addOrder(Order order)
        {
            if (order != null)
            {
                Orders.Add(order);
            }
        }
        public void addProduct(Product product) 
        {
            if (product != null)
            {
                Products.Add(product);
            }
        }
        public void buyProduct(Product product)
        {
            if (product != null)
            {
                Products.Add(product);
            }
        }

        public void removeCategory(int id) 
        {
            foreach (Category category in Categories)
            {
                if (category.Id == id)
                {
                    Categories.Remove(category);
                    return;
                }
            }
            Console.WriteLine("Category not found");
        }
        public void removeManufacturer(int id) 
        {
            foreach (Manufacturer manufacturer1 in Manufacturers)
            {
                if (manufacturer1.Id == id)
                {
                    Manufacturers.Remove(manufacturer1);
                    return;
                }
            }
            Console.WriteLine("Manufacturer not found");
        }
        public void removeCustomer(int id) 
        {
            foreach (Customer customer in Customers)
            {
                if (customer.Id == id)
                {
                    Customers.Remove(customer);
                    return;
                }
            }
            Console.WriteLine("Customers not found");
        }
        public void removeOrder(int id) 
        {
            foreach (Order order in Orders)
            {
                if (order.Id == id)
                {
                    Orders.Remove(order);
                    return;
                }
            }
            Console.WriteLine("Order not found");
        }
        public void removeProduct(int id) 
        {
            foreach (Product product in Products)
            {
                if (product.Id == id)
                {
                    Products.Remove(product);
                    return;
                }
            }
            Console.WriteLine("Product not found");
        }
        public void sellProduct(int id)
        {
            foreach (Product product in Products)
            {
                if (product.Id == id)
                {
                    Products.Remove(product);
                    return;
                }
            }
            Console.WriteLine("Product not found");
        }

        public Category getCategoryByName(string name)
        {
            Category Rcategory = null;
            foreach (Category category in Categories)
            {
                if (category.Name == name)
                {
                    Rcategory = category;
                    break;
                }
            }
            return Rcategory;
        }
        public Category getCategoryById(int id)
        {
            Category Rcategory = null;
            foreach (Category category in Categories)
            {
                if (category.Id == id)
                {
                    Rcategory = category;
                    break;
                }
            }
            return Rcategory;
        }
        public Manufacturer getManufacturerByName(string name)
        {
            Manufacturer Rmanufacturer = null;
            foreach (Manufacturer manufacturer in Manufacturers)
            {
                if (manufacturer.Name == name)
                {
                    Rmanufacturer = manufacturer;
                    break;
                }
            }
            return Rmanufacturer;
        }
        public Manufacturer getManufacturerById(int id)
        {
            Manufacturer Rmanufacturer = null;
            foreach (Manufacturer manufacturer in Manufacturers)
            {
                if (manufacturer.Id == id)
                {
                    Rmanufacturer = manufacturer;
                    break;
                }
            }
            return Rmanufacturer;
        }
        public Customer getCustomerByName(string name)
        {
            Customer Rcustomer = null;
            foreach (Customer customer in Customers)
            {
                if (customer.Name == name)
                {
                    Rcustomer = customer;
                    break;
                }
            }
            return Rcustomer;
        }
        public Customer getCustomerById(int id)
        {
            Customer Rcustomer = null;
            foreach (Customer customer in Customers)
            {
                if (customer.Id == id)
                {
                    Rcustomer = customer;
                    break;
                }
            }
            return Rcustomer;
        }
        public Order getOrderById(int id)
        {
            Order Rorder = null;
            foreach (Order order in Orders)
            {
                if (order.Id == id)
                {
                    Rorder = order;
                    break;
                }
            }
            return Rorder;
        }
        public Product getProductByName(string name)
        {
            Product Rproduct = null;
            foreach (Product product in Products)
            {
                if (product.Name == name)
                {
                    Rproduct = product;
                    break;
                }
            }
            return Rproduct;
        }
        public Product getProductById(int id)
        {
            Product Rproduct = null;
            foreach (Product product in Products)
            {
                if (product.Id == id)
                {
                    Rproduct = product;
                    break;
                }
            }
            return Rproduct;
        }
    }
}

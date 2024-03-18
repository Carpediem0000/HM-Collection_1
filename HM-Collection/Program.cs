namespace HM_Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DBContext dbContext = new DBContext();


            Category category1 = new Category(1, "Electronics");
            Category category2 = new Category(2, "Clothing");
            dbContext.addCategory(category1);
            dbContext.addCategory(category2);


            Manufacturer manufacturer1 = new Manufacturer(1, "Sony");
            Manufacturer manufacturer2 = new Manufacturer(2, "Nike");
            dbContext.addManufacturer(manufacturer1);
            dbContext.addManufacturer(manufacturer2);


            Product product1 = new Product(1, "Smartphone1", 3400, category1, manufacturer1);
            Product product2 = new Product(2, "Smartphone2", 8000, category1, manufacturer1);
            Product product3 = new Product(3, "Smartphone3", 21000, category1, manufacturer1);
            Product product4 = new Product(4, "Futbolka1", 450, category2, manufacturer2);
            Product product5 = new Product(5, "Kofta2", 899, category2, manufacturer2);
            Product product6 = new Product(6, "Shtanu3", 1200, category2, manufacturer2);
            dbContext.addProduct(product1);
            dbContext.addProduct(product2);
            dbContext.addProduct(product3);
            dbContext.addProduct(product4);
            dbContext.addProduct(product5);
            dbContext.addProduct(product6);
            dbContext.show();


            Product foundProduct = dbContext.searchProductById(1);
            if (foundProduct != null)
            {
                Console.WriteLine($"Product with ID 1 found: {foundProduct.Name}");
            }
            else
            {
                Console.WriteLine($"Product with ID 1 not found");
            }


            Console.WriteLine("Bwfore sort Product");
            dbContext.showProducts();
            dbContext.SortProduct();
            Console.WriteLine("After sort Product");
            dbContext.showProducts();


            Console.WriteLine("Before remove categ");
            dbContext.showCategories();
            dbContext.removeCategory(1);
            dbContext.showCategories();
            Console.WriteLine("After remove categ");


            Console.WriteLine("Before remove manuf");
            dbContext.showManufacturers();
            dbContext.removeManufacturer(1);
            dbContext.showManufacturers();
            Console.WriteLine("After remove manuf");


            Console.WriteLine("Before remove product");
            dbContext.showProducts();
            dbContext.removeProduct(2);
            dbContext.showProducts();
            Console.WriteLine("After remove product");


            Console.WriteLine("Before sell product");
            dbContext.showProducts();
            dbContext.removeProduct(1);
            dbContext.showProducts();
            Console.WriteLine("After sell product");
        }
    }
}

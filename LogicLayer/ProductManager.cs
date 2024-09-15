using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using MediaBazaarApp;
namespace LogicLayer
{
    public class ProductManager
    {

        private List<Product> allProducts;
        SQLDatabase database;
        public ProductManager()
        {
            database = new SQLDatabase();
            allProducts = new List<Product>();
        }
        public void addNewProduct(string name, int year, string description, ProductCategory category, string barcode, int maxCapacity)
        {
            Product p = new Product(name, year, description, category, barcode, maxCapacity);
            database.AddProduct(p);
        }

        public List<Product> getAllProducts()
        {
            allProducts.Clear();
            allProducts.AddRange(database.TakeAllProducts());
            return allProducts;
        }


        public void ModifyPrice(Product product, double newPrice)
        {
            Product existingProduct = allProducts.Find(p => p.getId() == product.getId());

            if (existingProduct != null)
            {
                existingProduct.SetPrice(newPrice);
                database.UpdatePriceDatabase(existingProduct);
            }
        }

        public void ModifyProductVariables(Product product, string newName, int newYear, string newDescription, ProductCategory category)
        {
            Product existingProduct = allProducts.Find(p => p.getId() == product.getId());

            if (existingProduct != null)
            {
                existingProduct.SetName(newName);
                existingProduct.SetYear(newYear);
                existingProduct.SetDescription(newDescription);
                existingProduct.SetCategory(category);
            }
        }
        public List<Product> getDepotProducts()
        {
            allProducts.Clear();
            allProducts.AddRange(database.TakeDepotProducts());
            return allProducts;
        }
    }
}

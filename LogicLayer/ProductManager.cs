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

    /// <summary>
    /// Manages operations related to products, including adding, modifying, and retrieving products from the database.
    /// </summary>
    public class ProductManager
    {

        private List<Product> allProducts;
        SQLDatabase database;
        public ProductManager()
        {
            database = new SQLDatabase();
            allProducts = new List<Product>();
        }

        /// <summary>
        /// Adds a new product to the database.
        /// </summary>
        /// <param name="name">The name of the product.</param>
        /// <param name="year">The year the product was released.</param>
        /// <param name="description">The description of the product.</param>
        /// <param name="category">The category to which the product belongs.</param>
        /// <param name="barcode">The barcode of the product.</param>
        /// <param name="maxCapacity">The maximum capacity for the product's inventory.</param>
        public void addNewProduct(string name, int year, string description, ProductCategory category, string barcode, int maxCapacity)
        {
            Product p = new Product(name, year, description, category, barcode, maxCapacity);
            database.AddProduct(p);
        }

        /// <summary>
        /// Retrieves all products from the database and returns them as a list.
        /// </summary>
        /// <returns>A list of <see cref="Product"/> objects.</returns>
        public List<Product> getAllProducts()
        {
            allProducts.Clear();
            allProducts.AddRange(database.TakeAllProducts());
            return allProducts;
        }

        /// <summary>
        /// Modifies the price of an existing product.
        /// </summary>
        /// <param name="product">The product whose price is to be modified.</param>
        /// <param name="newPrice">The new price to be set for the product.</param>
        public void ModifyPrice(Product product, double newPrice)
        {
            Product existingProduct = allProducts.Find(p => p.getId() == product.getId());

            if (existingProduct != null)
            {
                existingProduct.SetPrice(newPrice);
                database.UpdatePriceDatabase(existingProduct);
            }
        }


        /// <summary>
        /// Modifies the attributes of an existing product such as name, year, description, and category.
        /// </summary>
        /// <param name="product">The product whose variables are to be modified.</param>
        /// <param name="newName">The new name of the product.</param>
        /// <param name="newYear">The new release year of the product.</param>
        /// <param name="newDescription">The new description of the product.</param>
        /// <param name="category">The new category of the product.</param>
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

        /// <summary>
        /// Retrieves all products stored in the depot from the database and returns them as a list.
        /// </summary>
        /// <returns>A list of <see cref="Product"/> objects from the depot.</returns>
        public List<Product> getDepotProducts()
        {
            allProducts.Clear();
            allProducts.AddRange(database.TakeDepotProducts());
            return allProducts;
        }
    }
}

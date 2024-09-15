using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp
{
    /// <summary>
    /// Represents a product in the system with details such as name, category, price, and stock quantity.
    /// </summary>
    public class Product
    {
        private static int lastId = 0;
        private int id;
        public string Name { get; private set; }
        private ProductCategory category;
        public int Year { get; private set; }
        public string Description { get; private set; }
        public int QuantityinStock { get; private set; }
        private string barcode;
        private double price;
        public int maxCapacity { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with specified details.
        /// </summary>
        public Product(string name, int year, string description, ProductCategory category, string barcode, int maxCapacity, double price = 0, int id = 0, int quantityInStock = 0)
        {
            this.id = id;
            this.Name = name;
            this.Year = year;
            this.Description = description;
            this.category = category;
            this.barcode = barcode;
            this.QuantityinStock = quantityInStock;
            this.price = price;
            this.maxCapacity = maxCapacity;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class with specified details excluding barcode and maximum capacity.
        /// </summary>
        public Product(string name, int year, string description, ProductCategory category, int id = 0, int quantityInStock = 0, double price = 0)
        {
            this.id = id;
            this.Name = name;
            this.Year = year;
            this.Description = description;
            this.category = category;
            this.QuantityinStock = quantityInStock;
            this.price = price;
        }

        /// <summary>
        /// Gets the unique identifier of the product.
        /// </summary>
        /// <returns>The unique identifier of the product.</returns>
        public int getId() { return id; }

        /// <summary>
        /// Gets the price of the product.
        /// </summary>
        /// <returns>The price of the product.</returns>
        public double getPrice() { return price; }

        /// <summary>
        /// Gets the maximum capacity of the product.
        /// </summary>
        /// <returns>The maximum capacity of the product.</returns>
        public int getMaxCapacity() { return maxCapacity; }

        /// <summary>
        /// Gets the category of the product.
        /// </summary>
        /// <returns>The category of the product.</returns>
        public ProductCategory getCategory() { return category; }

        /// <summary>
        /// Gets a formatted string containing the product's ID, name, stock quantity, category, and year.
        /// </summary>
        /// <returns>A string representing the product's details.</returns>
        public string getInfo()
        {
            return $"Id: {this.getId()}, Name: {this.Name}, Stock: {this.QuantityinStock}, Category: {this.category}, Year: {this.Year}";
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the product's details.</returns>
        public override string ToString()
        {
            return $"Id: {this.getId()}, Name: {this.Name}, Stock: {this.QuantityinStock}, Category: {this.category}, Year: {this.Year}";
        }

        /// <summary>
        /// Sets a new name for the product.
        /// </summary>
        /// <param name="newName">The new name of the product.</param>
        public void SetName(string newName)
        {
            Name = newName;
        }

        /// <summary>
        /// Sets a new year for the product.
        /// </summary>
        /// <param name="newYear">The new year of manufacture for the product.</param>
        public void SetYear(int newYear)
        {
            Year = newYear;
        }

        /// <summary>
        /// Sets a new description for the product.
        /// </summary>
        /// <param name="newDescription">The new description of the product.</param>
        public void SetDescription(string newDescription)
        {
            Description = newDescription;
        }

        /// <summary>
        /// Sets a new category for the product.
        /// </summary>
        /// <param name="newCategory">The new category of the product.</param>
        public void SetCategory(ProductCategory newCategory)
        {
            category = newCategory;
        }

        /// <summary>
        /// Sets a new price for the product.
        /// </summary>
        /// <param name="newPrice">The new price of the product.</param>
        public void SetPrice(double newPrice)
        {
            price = newPrice;
        }
    }
}

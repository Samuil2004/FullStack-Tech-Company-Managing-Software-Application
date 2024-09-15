using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaBazaarApp
{
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

        public int getId() { return id; }

        public double getPrice() { return price; }
        public int getMaxCapacity() { return maxCapacity; }

        public ProductCategory getCategory() { return category; }

        public string getInfo()
        {
            return $"Id: {this.getId()}, Name: {this.Name},  Stock: {this.QuantityinStock}, Category: {this.category}, Year: {this.Year}";
        }

        public override string ToString()
        {
            return $"Id: {this.getId()}, Name: {this.Name},  Stock: {this.QuantityinStock}, Category: {this.category}, Year: {this.Year}";
        }

        public void SetName(string newName)
        {
            Name = newName;
        }

        public void SetYear(int newYear)
        {
            Year = newYear;
        }

        public void SetDescription(string newDescription)
        {
            Description = newDescription;
        }

        public void SetCategory(ProductCategory newcategory)
        {
            category = newcategory;
        }

        public void SetStock(int newStock)
        {
            QuantityinStock = newStock;
        }

        public void AddStock(int stocknumber)
        {
            QuantityinStock += stocknumber;
        }

        public void RemoveStock(int stocknumber)
        {
            QuantityinStock -= stocknumber;
        }

        public void SetPrice(double newPrice)
        {
            price = newPrice;
        }
    }
}

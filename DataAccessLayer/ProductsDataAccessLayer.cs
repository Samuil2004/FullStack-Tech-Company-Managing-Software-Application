using Microsoft.Data.SqlClient;
using ClassLibrary;
using MediaBazaarApp;

namespace DataAccessLayer
{
    /// <summary>
    /// Represents a class to interact with a SQL Database for all product related data.
    /// </summary>
    public class ProductsDataAccessLayer
    {
        /// <summary>
        /// Connection string used to establish a connection with the SQL server.
        /// </summary>
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi527531_mediashop;User Id=dbi527531_mediashop;Password=mediashop123; TrustServerCertificate=True";


        /// <summary>
        /// Retrieves restocking requests from sales representatives.
        /// </summary>
        /// <returns>A list of <see cref="RestockingRequest"/> objects.</returns>
        public List<RestockingRequest> GetRequestsFromSalesRepresentative()
        {
            List<RestockingRequest> requests = new List<RestockingRequest>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        string query = "SELECT * FROM RestockingRequests WHERE RequestFrom = 'Sales representative'";

                        SqlCommand command = new SqlCommand(query, connection);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            RestockingRequest request = new RestockingRequest(
                                (int)reader["ProductID"],
                                reader["productName"].ToString(),
                                (int)reader["Quantity"],
                                DateOnly.FromDateTime((DateTime)reader["Date"]),
                                (string)reader["RequestFrom"]);


                            requests.Add(request);
                        }

                        reader.Close();
                        return requests;

                }
                catch (Exception ex)
                    {
                        throw new Exception("Retrieving requests failed");
                    }
                }        
        }


        /// <summary>
        /// Retrieves all products from the database.
        /// </summary>
        /// <returns>A list of <see cref="Product"/> objects.</returns>
        public List<Product> TakeAllProducts()
        {
            string query = "SELECT * from Product";
            List<Product> fetchedProducts = new List<Product>();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    int id = Convert.ToInt32(reader["productId"]);
                    string name = reader["name"].ToString();
                    string productCategory = reader["category"].ToString();
                    ProductCategory category = (ProductCategory)Enum.Parse(typeof(ProductCategory), productCategory);
                    int year = Convert.ToInt32(reader["year"]);
                    string description = reader["description"].ToString();
                    int quantityInStock = Convert.ToInt32(reader["quantityInStock"]);
                    double price = Convert.ToDouble(reader["price"]);
                    string barcode = reader["barcode"].ToString();
                    int maxCapacity = Convert.ToInt32(reader["maxQuantity"]);

					Product newProduct = new Product(name, year, description, category, barcode, maxCapacity, price, id, quantityInStock);
                    fetchedProducts.Add(newProduct);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Reading products failed \nPlease try again");
            }
            finally
            {
                connection.Close();
            }
            return fetchedProducts;
        }

        /// <summary>
        /// Adds a new product to the database.
        /// </summary>
        /// <param name="p">The <see cref="Product"/> object to add.</param>
        public void AddProduct(Product p)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = $"INSERT INTO Product (productId, name, category, year, description, quantityInStock, price, barcode) VALUES(@productId, @name, @category, @year, @description, @quantityInStock, @price, @barcode";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@productId", p.getId());
                cmd.Parameters.AddWithValue("@name", p.Name);
                cmd.Parameters.AddWithValue("@category", Convert.ToString(p.getCategory()));
                cmd.Parameters.AddWithValue("@year", p.Year);
                cmd.Parameters.AddWithValue("@description", p.Description);
                cmd.Parameters.AddWithValue("@quantityInStock", 0);
                cmd.Parameters.AddWithValue("@price", 0);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Adding product failed \nPlease try again");
            }
            finally
            {
                connection.Close();
            }
        }


        /// <summary>
        /// Updates the price of a product in the database.
        /// </summary>
        /// <param name="product">The product whose price will be updated.</param>
        public void UpdatePriceDatabase(Product product)
        {
            string query = "UPDATE Product SET price = @price WHERE productId = @productId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@price", product.getPrice());
                        command.Parameters.AddWithValue("@productId", product.getId());

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Updating price failed. \nPlease try again later!");
                }
            }
        }


        /// <summary>
        /// Retrieves products from the depot.
        /// </summary>
        /// <returns>A list of <see cref="Product"/> objects.</returns>
        public List<Product> TakeDepotProducts()
        {
            string query = "SELECT * from DepotProduct";
            List<Product> fetchedProducts = new List<Product>();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    int id = Convert.ToInt32(reader["DepotProductId"]);
                    string name = reader["name"].ToString();
                    string productCategory = reader["category"].ToString();
                    ProductCategory category = (ProductCategory)Enum.Parse(typeof(ProductCategory), productCategory);
                    int year = Convert.ToInt32(reader["year"]);
                    string description = reader["description"].ToString();
                    int quantityInStock = Convert.ToInt32(reader["quantity"]);

                    Product newProduct = new Product(name, year, description, category, id, quantityInStock);
                    fetchedProducts.Add(newProduct);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Reading products failed.");

            }
            finally
            {
                connection.Close();
            }
            return fetchedProducts;
        }


        /// <summary>
        /// Gets the quantity of a depot product by its ID.
        /// </summary>
        /// <param name="productID">The ID of the product.</param>
        /// <returns>The quantity of the product.</returns>
        public int GetDepoProductQuantityByID(int productID)
        {
            int quantity = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT quantity FROM DepotProduct WHERE DepotProductId = @DepotProductId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DepotProductId", productID);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        quantity = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Reading product id failed.");

                }
            }

            return quantity;
        }


        /// <summary>
        /// Gets the quantity of a store product by its ID.
        /// </summary>
        /// <param name="productID">The ID of the product.</param>
        /// <returns>The quantity of the product.</returns>
        public int GetStoreProductQuantityByID(int productID)
        {
            int quantity = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT quantityInStock FROM Product WHERE productId = @productId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@productId", productID);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        quantity = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Reading product quantity failed.");

                }
            }

            return quantity;
        }


        /// <summary>
        /// Updates the quantity of a store product.
        /// </summary>
        /// <param name="productId">The ID of the product.</param>
        /// <param name="quantityInStock">The new quantity of the product.</param>
        public void UpdateStoreProductQuantity(int productId, int quantityInStock)
        {
            string query = "UPDATE Product SET quantityInStock = @quantityInStock WHERE productId = @productId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@quantityInStock", quantityInStock);
                        command.Parameters.AddWithValue("@productId", productId);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Updating product quantity failed.");

                }
            }
        }


        /// <summary>
        /// Updates the quantity of a depot product.
        /// </summary>
        /// <param name="DepotProductId">The ID of the depot product.</param>
        /// <param name="quantity">The new quantity of the product.</param>
        public void UpdateDepoProductQuantity(int DepotProductId, int quantity)
        {
            string query = "UPDATE DepotProduct SET quantity = @quantity WHERE DepotProductId = @DepotProductId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@quantity", quantity);
                        command.Parameters.AddWithValue("@DepotProductId", DepotProductId);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Reading product quantity failed.");

                }
            }
        }

        /// <summary>
        /// Deletes a restocking request from the database.
        /// </summary>
        /// <param name="productID">The ID of the product.</param>
        /// <param name="Quantity">The quantity of the product.</param>
        public void DeleteRequest(int productID, int Quantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "DELETE FROM [RestockingRequests] WHERE ProductID = @ProductID AND Quantity = @Quantity";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductID", productID);
                    command.Parameters.AddWithValue("@Quantity", Quantity);


                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Deleting request failed.");

                }
            }
        }


        /// <summary>
        /// Creates a new restocking request.
        /// </summary>
        /// <param name="ProductID">The ID of the product.</param>
        /// <param name="productName">The name of the product.</param>
        /// <param name="Quantity">The quantity of the product.</param>
        /// <param name="Date">The date of the request.</param>
        /// <param name="RequestFrom">The requester.</param>
        public void CreateNewRestockRequest(int ProductID, string productName, int Quantity, DateOnly Date, string RequestFrom)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO RestockingRequests (ProductID, productName, Quantity, Date, RequestFrom) VALUES (@ProductID, @productName, @Quantity, @Date, @RequestFrom)";
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                cmd.Parameters.AddWithValue("@productName", productName);
                cmd.Parameters.AddWithValue("@Quantity", Quantity);
                cmd.Parameters.AddWithValue("@Date", Date);
                cmd.Parameters.AddWithValue("@RequestFrom", RequestFrom);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Creating request failed.");

            }
            finally
            {
                connection.Close();
            }
        }



        /// <summary>
        /// Checks if a request already exists for a given product and requester.
        /// </summary>
        /// <param name="productID">The ID of the product.</param>
        /// <param name="requestFrom">The requester.</param>
        /// <returns>True if the request exists, otherwise false.</returns>
        public bool CheckRequestAlreadyExists(int productID, string requestFrom)
        {
            bool exists = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM RestockingRequests WHERE ProductID = @ProductID AND RequestFrom = @RequestFrom";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductID", productID);
                    command.Parameters.AddWithValue("@RequestFrom", requestFrom);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        exists = true;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Checking duplicate request failed.");
                }
            }
            return exists;
        }



        /// <summary>
        /// Retrieves restocking requests from depot workers.
        /// </summary>
        /// <returns>A list of <see cref="RestockingRequest"/> objects.</returns>
        public List<RestockingRequest> GetRequestsFromDepoWorker()
        {
            List<RestockingRequest> requests = new List<RestockingRequest>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT * FROM RestockingRequests WHERE RequestFrom = 'Depot worker' ORDER BY ProductID DESC";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        RestockingRequest request = new RestockingRequest((int)reader["ProductID"],
                            reader["productName"].ToString(),
                            (int)reader["Quantity"],
                            DateOnly.FromDateTime((DateTime)reader["Date"]),
                            (string)reader["RequestFrom"]);
                        requests.Add(request);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Retrieving requests failed.");
                }
            }

            return requests;
        }

        /// <summary>
        /// Finds a product by its barcode.
        /// </summary>
        /// <param name="barcode">The barcode of the product.</param>
        /// <returns>A <see cref="Product"/> object.</returns>
        public Product FindProductByBarcode(string barcode)
        {
            Product product = null;
            string query = "SELECT * from Product " +
                "WHERE barcode = @barcode;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@barcode", barcode);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    int id = Convert.ToInt32(reader["productId"]);
                    string name = reader["name"].ToString();
                    string productCategory = reader["category"].ToString();
                    ProductCategory category = (ProductCategory)Enum.Parse(typeof(ProductCategory), productCategory);
                    int year = Convert.ToInt32(reader["year"]);
                    string description = reader["description"].ToString();
                    int quantityInStock = Convert.ToInt32(reader["quantityInStock"]);
                    double price = Convert.ToDouble(reader["price"]);
					int maxCapacity = Convert.ToInt32(reader["maxQuantity"]);

					product = new Product(name, year, description, category, barcode, maxCapacity, price, id, quantityInStock);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Reading barcode failed.");
            }
            finally
            {
                connection.Close();
            }
            return product;
        }


        /// <summary>
        /// Gets the maximum quantity of a depot product by its ID.
        /// </summary>
        /// <param name="productID">The ID of the product.</param>
        /// <returns>The maximum quantity of the product.</returns>
        public int GetDepoProductMaxQuantityByID(int productID)
        {
            int quantity = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT MaxQuantity FROM DepotProduct WHERE DepotProductId = @DepotProductId";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@DepotProductId", productID);

                    connection.Open();

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        quantity = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Reading maximum quantity failed.");
                }
            }

            return quantity;
        }


        /// <summary>
        /// Gets the total number of orders.
        /// </summary>
        /// <returns>The total order count.</returns>
        public int GetOrderCount()
        {
            int orderCount = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT COUNT(*) FROM [Order]";

                    SqlCommand command = new SqlCommand(query, connection);

                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        orderCount = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Reading orders number failed.");

                }
            }

            return orderCount;
        }


        /// <summary>
        /// Gets the names of suppliers for a given product ID.
        /// </summary>
        /// <param name="ProductID">The ID of the product.</param>
        /// <returns>A list of supplier names.</returns>
        public List<string> GetSupplierNamesByProductID(int ProductID)
        {
            List<string> supplierNames = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT SupplierName FROM Supplier Where ProductID = @ProductID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", ProductID);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string supplierName = reader.GetString(reader.GetOrdinal("SupplierName"));
                        supplierNames.Add(supplierName);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Reading supplier failed.");
                }
            }
            return supplierNames;
        }


        /// <summary>
        /// Creates a new order item.
        /// </summary>
        /// <param name="orderId">The ID of the order.</param>
        /// <param name="ProductID">The ID of the product.</param>
        /// <param name="quantity">The quantity of the product.</param>
        public void CreateNewOrderItem(int orderId, int ProductID, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"INSERT INTO [OrderItem] (OrderID, ProductID, Quantity)
                         VALUES (@OrderId, @ProductId, @Quantity)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    command.Parameters.AddWithValue("@ProductId", ProductID);
                    command.Parameters.AddWithValue("@Quantity", quantity);


                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw new Exception("Creating new order item failed.");

                }
            }
        }


        /// <summary>
        /// Creates a new order.
        /// </summary>
        /// <param name="orderId">The ID of the order.</param>
        /// <param name="supplier">The supplier's name.</param>
        /// <param name="orderDate">The date of the order.</param>
        /// <param name="arrivalDate">The expected arrival date.</param>
        /// <param name="status">The status of the order.</param>
        public void CreateNewOrder(int orderId, string supplier, DateTime orderDate, DateTime arrivalDate, string status)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    string query = @"INSERT INTO [Order] (OrderId, Supplier, OrderDate, ArrivalDate, Status)
                         VALUES (@OrderId, @Supplier, @OrderDate, @ArrivalDate, @Status)";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    command.Parameters.AddWithValue("@Supplier", supplier);
                    command.Parameters.AddWithValue("@OrderDate", orderDate);
                    command.Parameters.AddWithValue("@ArrivalDate", arrivalDate);
                    command.Parameters.AddWithValue("@Status", status);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Creating new order failed.");
                }
            }
        }


        /// <summary>
        /// Retrieves all orders from the database.
        /// </summary>
        /// <returns>A list of <see cref="Order"/> objects.</returns>
        public List<Order> GetAllOrders()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM [Order]";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int orderId = reader.GetInt32(reader.GetOrdinal("OrderId"));
                        DateTime orderDate = reader.GetDateTime(reader.GetOrdinal("OrderDate"));
                        DateTime arrivalDate = reader.GetDateTime(reader.GetOrdinal("ArrivalDate"));
                        string status = reader.GetString(reader.GetOrdinal("Status"));

                        Order order = new Order(orderId, orderDate, arrivalDate, status, getOrderItemsByOrderID(orderId));
                        orders.Add(order);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Reading orders failed.");
                }
            }

            return orders;
        }


        /// <summary>
        /// Retrieves the items of an order by the order ID.
        /// </summary>
        /// <param name="orderId">The ID of the order.</param>
        /// <returns>A list of <see cref="OrderItem"/> objects.</returns>
        public List<OrderItem> getOrderItemsByOrderID(int orderId)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM [OrderItem] WHERE OrderID = @OrderId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderId", orderId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int productId = reader.GetInt32(reader.GetOrdinal("ProductID"));
                        int quantity = reader.GetInt32(reader.GetOrdinal("Quantity"));

                        OrderItem orderItem = new OrderItem(GetProductByID(productId), quantity);
                        orderItems.Add(orderItem);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Retrieving items failed");
                }
            }

            return orderItems;
        }


        /// <summary>
        /// Retrieves a product by its ID.
        /// </summary>
        /// <param name="productId">The ID of the product.</param>
        /// <returns>A <see cref="Product"/> object.</returns>
        public Product GetProductByID(int productId)
        {
            Product product = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM DepotProduct WHERE DepotProductId = @ProductId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductId", productId);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["DepotProductId"]);
                        string name = reader["name"].ToString();
                        string productCategory = reader["category"].ToString();
                        ProductCategory category = (ProductCategory)Enum.Parse(typeof(ProductCategory), productCategory);
                        int year = Convert.ToInt32(reader["year"]);
                        string description = reader["description"].ToString();
                        int quantityInStock = Convert.ToInt32(reader["quantity"]);


                        product = new Product(name, year, description, category, id, quantityInStock);

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Reading product Id failed.");
                }
            }

            return product;
        }


        /// <summary>
        /// Retrieves the name of the supplier for a specific order.
        /// </summary>
        /// <param name="orderId">The ID of the order.</param>
        /// <returns>The supplier's name.</returns>
        public string GetSupplierNameByOrderID(int orderId)
        {
            string supplierName = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Supplier FROM [Order] WHERE OrderID = @OrderId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OrderId", orderId);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        supplierName = Convert.ToString(result);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Reading supplier failed.");
                }
            
            }

            return supplierName;
        }


        /// <summary>
        /// Changes the status of an order.
        /// </summary>
        /// <param name="orderId">The ID of the order.</param>
        /// <param name="newStatus">The new status of the order.</param>
        public void ChangeOrderStatus(int orderId, string newStatus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE [Order] SET Status = @NewStatus WHERE OrderId = @OrderId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewStatus", newStatus);
                command.Parameters.AddWithValue("@OrderId", orderId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Updating status failed.");
                }
            }
        }

        /// <summary>
        /// Changes the quantity of a depot product.
        /// </summary>
        /// <param name="productId">The ID of the product.</param>
        /// <param name="newQuantity">The new quantity of the product.</param>
        public void ChangeProductQuantity(int productId, int newQuantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE DepotProduct SET quantity = @NewQuantity WHERE DepotProductID = @ProductId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@NewQuantity", newQuantity);
                command.Parameters.AddWithValue("@ProductId", productId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                                        
                }
                catch (Exception ex)
                {
                    throw new Exception("Chanign quantity failed.");
                }
            }
        }
    }
}

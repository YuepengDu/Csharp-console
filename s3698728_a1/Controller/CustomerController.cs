using System;
using System.Collections.Generic;
using System.Linq;
using ConnectionLib;
using s3698728_a1.Model;
namespace s3698728_a1.Controller
{
    public class CustomerController : AbstractCustomerController
    {
        private readonly string _connectionString;
        public List<Customer> Customers { get; }
        public CustomerController(string connectionString)
        {
            _connectionString = connectionString;

            using var connection = _connectionString.CreateConnection();
            var command = connection.CreateCommand();
            command.CommandText = "select * from Customer";

            var accController = new AccountController(_connectionString);

            Customers = command.GetDataTable().Select().Select(x => new Customer
            {
                CustomerID = (int)x["CustomerID"],
                Name = (string)x["Name"],
                Address = (string)x["Address"],
                City = (string)x["City"],
                PostCode = (string)x["PostCode"],
            }).ToList();
        }
        public override void InsertCustomer(Customer customer)
        {
            using var connection = _connectionString.CreateConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                "insert into Customer (CustomerID, Name, Address, City, PostCode) values (@customerID, @name, @address, @city, @postcode)";
            command.Parameters.AddWithValue("customerID", customer.CustomerID);
            
            command.Parameters.AddWithValue("name", customer.Name);
            if (string.IsNullOrEmpty(customer.Address)) 
            {
                command.Parameters.AddWithValue("address", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("address", customer.Address);
            }
            if (string.IsNullOrEmpty(customer.City))
            {
                command.Parameters.AddWithValue("city", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("city", customer.City);
            }
            if (string.IsNullOrEmpty(customer.PostCode))
            {
                command.Parameters.AddWithValue("postcode", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("postcode", customer.PostCode);
            }
            command.ExecuteNonQuery();
        }

    }
}

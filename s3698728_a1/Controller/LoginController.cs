using s3698728_a1.Model;
using s3698728_a1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using ConnectionLib;


namespace s3698728_a1.Controller
{
    public class LoginController : AbstractLoginController
    {
        private readonly string _connectionString;

        public List<Login> Login { get; }

        public LoginController(string connectionString)
        {
            _connectionString = connectionString;

            using var connection = _connectionString.CreateConnection();
            var command = connection.CreateCommand();
            command.CommandText = "select * from Login";

            Login = command.GetDataTable().Select().Select(x => new Login
            {
                LoginID = (string)x["LoginID"],
                CustomerID = (int)x["CustomerID"],
                PasswordHash = (string)x["PasswordHash"],
            }).ToList();
        }

        public override void InsertLogin(Login login)
        {
            using var connection = _connectionString.CreateConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                "insert into Login (LoginID, CustomerID, PasswordHash) values (@loginID, @customerID, @passwordHash)";
            command.Parameters.AddWithValue("loginID", login.LoginID);
            command.Parameters.AddWithValue("customerID", login.CustomerID);
            command.Parameters.AddWithValue("passwordHash", login.PasswordHash);

            command.ExecuteNonQuery();
        }
    }
}

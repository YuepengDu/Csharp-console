using s3698728_a1.Model;
using ConnectionLib;
using System.Collections.Generic;
using System.Linq;

namespace s3698728_a1.Controller
{
    public class AccountController : AbstractAccountController
    {
        private readonly string _connectionString;

        public AccountController(string connectionString)
        {
            _connectionString = connectionString;
        }

        public override List<Account> GetAccount(int CustomerID)
        {
            using var connection = _connectionString.CreateConnection();
            var command = connection.CreateCommand();
            command.CommandText = "select * from Account where AccountNumber = @AccountNumber";
            command.Parameters.AddWithValue("CustomerID", CustomerID);
            var transactionController = new TransactionController(_connectionString);

            return command.GetDataTable().Select().Select(x => new Account
            {
                AccountNumber = (int)x["AccountNumber"],
                AccountType = (char)x["AccountType"],
                CustomerID = (int)x["CustomerID"],
                Balance = (decimal)x["Balance"],
            }).ToList();
        }

        public override void InsertAccount(Account account)
        {
            using var connection = _connectionString.CreateConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                "insert into Account (CustomerID, AccountNumber, AccountType, Balance) values (@customerID, @accountNumber, @accountType, @balance)";
            command.Parameters.AddWithValue("customerID", account.CustomerID);
            command.Parameters.AddWithValue("accountNumber", account.AccountNumber);
            command.Parameters.AddWithValue("accountType", account.AccountType);
            command.Parameters.AddWithValue("balance", account.Balance);
            command.ExecuteNonQuery();
        }
    }
}

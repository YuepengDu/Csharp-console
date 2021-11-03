using Microsoft.Data.SqlClient;
using s3698728_a1.Model;
using System;
using System.Collections.Generic;
using ConnectionLib;

namespace s3698728_a1.Controller
{
    public class TransactionController: AbstractTransactionController
    {
        private readonly string _connectionString; 

        public TransactionController(string connectionString)
        {
            _connectionString = connectionString;
        }
        public override List<Transactions> GetTransaction(int accountNumber)
        {
            using var connection = _connectionString.CreateConnection();
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM [Transaction] WHERE AccountNumber = @acNumber";
            command.Parameters.AddWithValue("acNumber", accountNumber);
            //preloading the customer lists 
            List<Transactions> transactions = new List<Transactions>();

            using (SqlDataReader Reader = command.ExecuteReader())
            {
                while (Reader.Read())
                {
                    Transactions transaction = new Transactions();
                    transaction.TransactionID = Int32.Parse(Reader["TransactionID"].ToString());
                    transaction.TransactionType = Char.Parse(Reader["TransactionType"].ToString());
                    transaction.AccountNumber = Int32.Parse(Reader["AccountNumber"].ToString());
               //     transaction.DestinationAccountNumber = Int32.Parse(Reader["DestinationAccountNumber"].ToString());
                    transaction.Amount = decimal.Parse(Reader["Amount"].ToString());
                    transaction.Comment = Reader["Comment"].ToString();
                    transaction.TransactionTimeUtc = DateTime.Parse(Reader["TransactionTimeUtc"].ToString());

                    transactions.Add(transaction);
                }
            }
            connection.Close();
            return transactions;
        }
        public override List<Transactions> FindAllTransaction(int accountNumber)
        {
            List<Transactions> trans = GetTransaction(accountNumber);
            List<Transactions> result = new List<Transactions>();
            foreach (var item in trans)
            {
                result.Add(item);
            }
            return result;
        }
        public override void InsertTranscation(Transactions transaction)
        {
            using var connection = _connectionString.CreateConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                "INSERT INTO [Transaction](TransactionType,AccountNumber,DestinationAccountNumber,Amount,Comment,TransactionTimeUtc) VALUES( @TransactionType, @AccountNumber, @DestinationAccountNumber, @Amount, @Comment, @TransactionTimeUtc )";

            if (String.IsNullOrEmpty(transaction.TransactionType.ToString()))
            {
                command.Parameters.AddWithValue("TransactionType", "T");
            }
            else
            {
                command.Parameters.AddWithValue("TransactionType", transaction.TransactionType);
            }
            //-----------------------------------------------------------------------------------------------
            if (String.IsNullOrEmpty(transaction.AccountNumber.ToString()))
            {
                command.Parameters.AddWithValue("AccountNumber", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("AccountNumber", transaction.AccountNumber);
            }

            //-----------------------------------------------------------------------------------------------
            if (String.IsNullOrEmpty(transaction.DestinationAccountNumber.ToString()))
            {
                command.Parameters.AddWithValue("DestinationAccountNumber", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("DestinationAccountNumber", transaction.DestinationAccountNumber);
            }
            //-----------------------------------------------------------------------------------------------
            if (String.IsNullOrEmpty(transaction.Amount.ToString()))
            {
                command.Parameters.AddWithValue("Amount", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("Amount", transaction.Amount);
            }
            //-----------------------------------------------------------------------------------------------
            if (String.IsNullOrEmpty(transaction.Comment))
            {
                command.Parameters.AddWithValue("Comment", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("Comment", transaction.Comment);
            }
            //-----------------------------------------------------------------------------------------------
            if (String.IsNullOrEmpty(transaction.TransactionTimeUtc.ToString()))
            {
                command.Parameters.AddWithValue("TransactionTimeUtc", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("TransactionTimeUtc", transaction.TransactionTimeUtc);
            }

            command.ExecuteNonQuery();
        }
        public override void InsertDeposit(Transactions transaction)
        {
            using var connection = _connectionString.CreateConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                "INSERT INTO [Transaction](TransactionType,AccountNumber,Amount,TransactionTimeUtc) VALUES( @TransactionType, @AccountNumber, @Amount, @TransactionTimeUtc )";

            if (String.IsNullOrEmpty(transaction.TransactionType.ToString()))
            {
                command.Parameters.AddWithValue("TransactionType", "D");
            }
            else
            {
                command.Parameters.AddWithValue("TransactionType", transaction.TransactionType);
            }
            //-----------------------------------------------------------------------------------------------
            if (String.IsNullOrEmpty(transaction.AccountNumber.ToString()))
            {
                command.Parameters.AddWithValue("AccountNumber", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("AccountNumber", transaction.AccountNumber);
            }

            //-----------------------------------------------------------------------------------------------
            if (String.IsNullOrEmpty(transaction.Amount.ToString()))
            {
                command.Parameters.AddWithValue("Amount", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("Amount", transaction.Amount);
            }

            //-----------------------------------------------------------------------------------------------
            if (String.IsNullOrEmpty(transaction.TransactionTimeUtc.ToString()))
            {
                command.Parameters.AddWithValue("TransactionTimeUtc", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("TransactionTimeUtc", transaction.TransactionTimeUtc);
            }

            command.ExecuteNonQuery();
        }
        public override void InsertWithdraw(Transactions transaction)
        {
            using var connection = _connectionString.CreateConnection();
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                "INSERT INTO [Transaction](TransactionType,AccountNumber,Amount,TransactionTimeUtc) VALUES( @TransactionType, @AccountNumber, @Amount, @Comment, @TransactionTimeUtc )";

            if (String.IsNullOrEmpty(transaction.TransactionType.ToString()))
            {
                command.Parameters.AddWithValue("TransactionType", "W");
            }
            else
            {
                command.Parameters.AddWithValue("TransactionType", transaction.TransactionType);
            }
            //-----------------------------------------------------------------------------------------------
            if (String.IsNullOrEmpty(transaction.AccountNumber.ToString()))
            {
                command.Parameters.AddWithValue("AccountNumber", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("AccountNumber", transaction.AccountNumber);
            }

            //-----------------------------------------------------------------------------------------------
            if (String.IsNullOrEmpty(transaction.Amount.ToString()))
            {
                command.Parameters.AddWithValue("Amount", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("Amount", transaction.Amount);
            }
            //-----------------------------------------------------------------------------------------------
            if (String.IsNullOrEmpty(transaction.TransactionTimeUtc.ToString()))
            {
                command.Parameters.AddWithValue("TransactionTimeUtc", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("TransactionTimeUtc", transaction.TransactionTimeUtc);
            }

            command.ExecuteNonQuery();
        }
        }
    }



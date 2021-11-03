using System;

namespace s3698728_a1.Model
{
    public class Transactions
    {
        //Variable Declarations
        public int TransactionID { get; set; }
        public char TransactionType { get; set; }
        public int AccountNumber { get; set; }
        public int? DestinationAccountNumber { get; set; }
        public Decimal Amount { get; set; }
        public string? Comment { get; set; }
        public DateTime TransactionTimeUtc { get; set; }
        public Account account { get; set; }
        public Transactions(char transactionType, int accountNumber, int destinationAccountNumber,
            Decimal amount, string comment, DateTime transactionTimeUtc)
        {
            TransactionType = transactionType;
            AccountNumber = accountNumber;
            DestinationAccountNumber = destinationAccountNumber;
            Amount = amount;
            Comment = comment;
            TransactionTimeUtc = transactionTimeUtc;

        }
        public Transactions(char transactionType, int accountNumber,
            Decimal amount, DateTime transactionTimeUtc)
        {
            TransactionType = transactionType;
            AccountNumber = accountNumber;

            Amount = amount;
            TransactionTimeUtc = transactionTimeUtc;

        }
        public Transactions()
        {

        }
    }

}

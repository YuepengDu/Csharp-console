using System.Collections.Generic;

namespace s3698728_a1.Model
{
    public class Account
    {
        //Variables Declaration
        public int AccountNumber { get; set; }
        public char AccountType { get; set; }
        public int CustomerID { get; set; }
        public decimal Balance { get; set; }
        public List<Transactions> Transaction { get; set; }

        public Account()
        {
            Transaction = new List<Transactions>();
        }
        public Account(int accountNumber,char accountType, int customerId, decimal balance)
        {
            AccountNumber = accountNumber;
            AccountType = accountType;
            CustomerID = customerId;
            Balance = balance;
        }
    }
}

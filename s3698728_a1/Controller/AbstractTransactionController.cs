using s3698728_a1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s3698728_a1.Controller
{/// <summary>
/// Controller for working with instances of {Transaction}
/// </summary>
    public abstract class AbstractTransactionController
    {/// <summary>
    ///  Search transaction in database
    /// </summary>
    /// <param name="accountNumber"></param>
    /// <returns></returns>
        public abstract List<Transactions> GetTransaction(int accountNumber);
        /// <summary>
        ///  a collection of all transaction returned by GetTransaction
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <returns></returns>
        public abstract List<Transactions> FindAllTransaction(int accountNumber);
        /// <summary>
        /// Insert into database of Transaction table as transfer 
        /// </summary>
        /// <param name="transaction"></param>
        public abstract void InsertTranscation(Transactions transaction);
        /// <summary>
        /// Insert into database of Transaction table as Deposit 
        /// </summary>
        /// <param name="transaction"></param>
        public abstract void InsertDeposit(Transactions transaction);
        /// <summary>
        /// Insert into database of Transaction table as Withdraw 
        /// </summary>
        /// <param name="transaction"></param>
        public abstract void InsertWithdraw(Transactions transaction);
    }
}

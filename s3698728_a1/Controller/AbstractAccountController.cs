using s3698728_a1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
///     Controller for working with instances of {Account}
/// </summary>
namespace s3698728_a1.Controller
{
    public abstract class AbstractAccountController
    {
        /// <summary>
        ///     Search for desired account based on CustomerID given
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        public abstract List<Account> GetAccount(int CustomerID);
        /// <summary>
        ///     Make insertion for account into database
        /// </summary>
        /// <param name="account"></param>
        public abstract void InsertAccount(Account account);
    }
}

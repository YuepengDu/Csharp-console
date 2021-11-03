using s3698728_a1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s3698728_a1.Controller
{/// <summary>
/// Controller for working with instances of {Customer}
/// </summary>
    public abstract class AbstractCustomerController
    {/// <summary>
    /// Insert customer into database
    /// </summary>
    /// <param name="customer"></param>
        public abstract void InsertCustomer(Customer customer);
    }
}

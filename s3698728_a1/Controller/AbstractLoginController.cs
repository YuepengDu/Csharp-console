using s3698728_a1.Model;


namespace s3698728_a1.Controller
{/// <summary>
/// Controller for working with instances of {Login}
/// </summary>
    public abstract class AbstractLoginController
    {/// <summary>
    /// Insert new user with username & password as login details
    /// </summary>
    /// <param name="login"></param>
        public abstract void InsertLogin(Login login);
    }
}

using System;
using PartisanNET.Modules.Identity.Contracts;

namespace PartisanNET.Modules.Identity.Models;

public class IdentityResult
{
    public class Success : IdentityResult
    {
        public IUserSession Session { get; init; }
    }
    
    public class Failed : IdentityResult
    {
        public Exception Exception { get; init; }
    }
}
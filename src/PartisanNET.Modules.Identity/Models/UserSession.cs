using System.Security.Claims;
using PartisanNET.Modules.Identity.Contracts;

namespace PartisanNET.Modules.Identity.Models;

public class UserSession : IUserSession
{
    public bool IsAnon => Identity is null;
    public ClaimsIdentity? Identity { get; private set; }

    public void Authenticate(ClaimsIdentity? identity)
    {
        Identity = identity;
    }
}
using System.Security.Claims;

namespace PartisanNET.Modules.Identity.Contracts;

public interface IUserSession
{
    bool IsAnon { get; }
    ClaimsIdentity? Identity { get; }
}
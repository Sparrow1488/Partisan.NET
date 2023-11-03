namespace PartisanNET.Modules.Identity.Models;

public record IdentityStatus(IdStatus Status);

public enum IdStatus
{
    SignIn = 0,
    SignOut = 1,
    InvalidCredentials = 2
}
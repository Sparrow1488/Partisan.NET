using System;
using System.Threading;
using System.Threading.Tasks;
using PartisanNET.Modules.Identity.Models;

namespace PartisanNET.Modules.Identity.Contracts;

public interface IIdentityService
{
    IObservable<IdentityStatus> StatusShell { get; }
    Task<IdentityResult> AuthenticateAsync(LoginCredentials credentials, CancellationToken ctk = default);
}
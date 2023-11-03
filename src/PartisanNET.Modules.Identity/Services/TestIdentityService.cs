using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using PartisanNET.Modules.Identity.Contracts;
using PartisanNET.Modules.Identity.Models;

namespace PartisanNET.Modules.Identity.Services;

public class TestIdentityService : IIdentityService
{
    private readonly UserSession _userSession;
    private readonly Subject<IdentityStatus> _statusShell = new();

    public TestIdentityService(IUserSession userSession)
    {
        _userSession = (UserSession) userSession;
    }
    
    public IObservable<IdentityStatus> StatusShell => _statusShell;
    
    public Task<IdentityResult> AuthenticateAsync(LoginCredentials credentials, CancellationToken ctk = default)
    {
        if (credentials.Login == "asd" && credentials.Password == "1234")
        {
            _userSession.Authenticate(new ClaimsIdentity(new List<Claim>
            {
                new("id", "1"),
                new("name", "test")
            }));
            
            _statusShell.OnNext(new IdentityStatus(IdStatus.SignIn));
            return Task.FromResult((IdentityResult) new IdentityResult.Success { Session = _userSession });
        }
        
        _statusShell.OnNext(new IdentityStatus(IdStatus.InvalidCredentials));
        return Task.FromResult((IdentityResult) new IdentityResult.Failed { Exception = new Exception("Failed login") });
    }
}


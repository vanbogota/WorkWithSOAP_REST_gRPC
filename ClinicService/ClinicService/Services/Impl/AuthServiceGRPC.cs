using Azure;
using Azure.Core;
using ClinicService.Models.Requests;
using ClinicServiceNamespace;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;
using static ClinicServiceNamespace.AuthenticateService;

namespace ClinicService.Services.Impl
{
    [Authorize]
    public class AuthServiceGRPC : AuthenticateServiceBase
    {
        private readonly IAuthenticateService _authenticateService;

        public AuthServiceGRPC(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [AllowAnonymous]
        public override Task<AuthenticationResponseGRPC> Login(AuthenticationRequestGRPC request, ServerCallContext context)
        {
            AuthenticationResponse response = _authenticateService.Login(new AuthenticationRequest
            {
                Login = request.UserName,
                Password = request.Password,
            });

            if (response.Status == Models.AuthenticationStatus.Success)
            {
                context.ResponseTrailers.Add("X-Session-Token", response.SessionContext.SessionToken);
            }

            return Task.FromResult(new AuthenticationResponseGRPC
            {
                Status = (int)response.Status,
                SessionContext = new SessionContext
                {
                    SessionId = response.SessionContext.SessionId,
                    SessionToken= response.SessionContext.SessionToken,
                    Account = new AccountDto
                    {
                        AccountId = response.SessionContext.Account.AccountId,
                        EMail = response.SessionContext.Account.EMail,
                        FirstName= response.SessionContext.Account.FirstName,
                        LastName= response.SessionContext.Account.LastName,
                        Locked= response.SessionContext.Account.Locked,
                        SecondName = response.SessionContext.Account.SecondName
                    }
                }
            });
        }

        public override Task<GetSessionResponseGRPC> GetSession(GetSessionRequestGRPC request, ServerCallContext context)
        {
            var authHeader = context.RequestHeaders.FirstOrDefault(header => header.Key == "Authorization");

            if (AuthenticationHeaderValue.TryParse(authHeader.Value, out var headerValue))
            {
                var scheme = headerValue.Scheme;
                var sessionToken = headerValue.Parameter;

                if (string.IsNullOrEmpty(sessionToken))
                {
                    return Task.FromResult(new GetSessionResponseGRPC());
                }

                Models.SessionContext sessionContext = _authenticateService.GetSessionInfo(sessionToken);

                if (sessionContext == null)
                {
                    return Task.FromResult(new GetSessionResponseGRPC());
                }

                return Task.FromResult(new GetSessionResponseGRPC
                {
                    SessionContext = new SessionContext
                    {
                        SessionId = sessionContext.SessionId,
                        SessionToken = sessionContext.SessionToken,
                        Account = new AccountDto
                        {
                            AccountId = sessionContext.Account.AccountId,
                            EMail = sessionContext.Account.EMail,
                            FirstName = sessionContext.Account.FirstName,
                            LastName = sessionContext.Account.LastName,
                            Locked = sessionContext.Account.Locked,
                            SecondName = sessionContext.Account.SecondName
                        }
                    }
                });
            }
            return Task.FromResult(new GetSessionResponseGRPC());
        }
    }
}

using ClinicService.Models;
using ClinicService.Models.Requests;
using ClinicService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net.Http.Headers;

namespace ClinicService.Controllers
{
    [Authorize]
    [Route("api/auth")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;

        public AuthenticateController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult<AuthenticationResponse> Login([FromBody] AuthenticationRequest request) 
        {
            AuthenticationResponse authenticationResponse = _authenticateService.Login(request);
            if(authenticationResponse.Status == Models.AuthenticationStatus.Success)
            {
                Response.Headers.Add("X-Session-Token", authenticationResponse.SessionContext.SessionToken);
            }
            return Ok(authenticationResponse);
        }

        [HttpGet("session")]
        public ActionResult<SessionContext> GetSession()
        {
            var auth = Request.Headers[HeaderNames.Authorization];
            if (AuthenticationHeaderValue.TryParse(auth, out var headerValue))
            {
                var scheme = headerValue.Scheme;
                var sessionToken = headerValue.Parameter;

                if (string.IsNullOrEmpty(sessionToken))
                {
                    return Unauthorized();
                }

                SessionContext sessionContext = _authenticateService.GetSessionInfo(sessionToken);
                if (sessionContext == null) 
                {
                    return Unauthorized();
                }

                return Ok(sessionContext);
            }
            return Unauthorized();
        }
    }
}

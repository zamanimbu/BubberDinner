using BubberDinner.Application.Services.Authintication;
using BubberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BubberDinner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthinticationController : ControllerBase
    {
        private readonly IAuthinticationService _authinticationService;

        public AuthinticationController(IAuthinticationService authinticationService)
        {
            _authinticationService = authinticationService;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authModel = _authinticationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password
                );
            var response = new AuthinticationResponse(
                authModel.Id,
                authModel.FirstName,
                authModel.LastName,
                authModel.Email,
                authModel.Token
                );
            return Ok(response);
        }
        [Route("login")]
        public IActionResult LogIn(LoginRequest request)
        {
            var authModel = _authinticationService.Login(
                request.Email,
                request.Password
                );
            var response = new AuthinticationResponse(
                authModel.Id,
                authModel.FirstName,
                authModel.LastName,
                authModel.Email,
                authModel.Token
                );
            return Ok(response); 
        }
    }
}

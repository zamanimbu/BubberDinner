using BubberDinner.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubberDinner.Application.Services.Authintication
{
    internal class AuthinticationService : IAuthinticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator ;

        public AuthinticationService( IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {

            Guid userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

            return new AuthenticationResult(
                userId,
                firstName,
                lastName,
                email,
                token);
        }
        public AuthenticationResult Login(string email, string password)
        {         
            return new AuthenticationResult(
                Guid.NewGuid(),
                "firstName",
                "lastName",
                email,
                "token");
        }   

       
    }
}

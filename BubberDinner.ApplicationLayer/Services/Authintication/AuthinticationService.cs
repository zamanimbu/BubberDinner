using BubberDinner.Application.Common.Interfaces;
using BubberDinner.Application.Common.Persistence;
using BubberDinner.Domain.Entities;
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
        private readonly IUesrRepository _uesrRepository ;
        public AuthinticationService( IJwtTokenGenerator jwtTokenGenerator, IUesrRepository uesrRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _uesrRepository = uesrRepository;
        }
        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            if(_uesrRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User with emqail already exist");
            }
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Passowrd = password
            };

            _uesrRepository.Add(user);

            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
               user,
                token);
        }
        public AuthenticationResult Login(string email, string password)
        {   
            if(_uesrRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User doesn't ecist");
            }
            if(user.Passowrd != password)
            {
                throw new Exception("Invalid Password");
            }
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(
                user,
                token);
        }   

       
    }
}

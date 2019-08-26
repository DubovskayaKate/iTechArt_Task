using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using MoneyManager.DataAccess;
using MoneyManager.DataAccess.Models;
using MoneyManager.DataAccess.Repositories;

namespace MoneyManager.Business.Services
{
    public class UserService : BaseService<User>
    {
        private readonly UserRepository<User> _userRepository; 

        public UserService(UserRepository<User> userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetUserByEmail(string email)
        {
            Expression < Func<User, bool> >  expression = user => user.Email == email;
            return _userRepository.List(expression).ToList();
            throw new NotImplementedException();
        }
        




    }
}

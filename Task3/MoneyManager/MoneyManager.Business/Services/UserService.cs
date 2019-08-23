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
    public class UserService
    {
        private readonly UserRepository<User> userRepository; 

        public UserService(UserRepository<User> user)
        {
            userRepository = user;
        }
        public List<User> GetAllUser()
        {
            return userRepository.List().ToList();
        }

        public User GetUserById(int id)
        {
            return userRepository.GetById(id);
        }

        public List<User> GetUserByEmail(string email)
        {
            //return userRepository.List(new Expression<Func<User, bool>> (user => user.Email == email) );
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            userRepository.Update(user);
        }

        public void Delete(User user)
        {
            userRepository.Delete(user);
        }

        public void Insert(User user)
        {
            userRepository.Update(user);
        }




    }
}

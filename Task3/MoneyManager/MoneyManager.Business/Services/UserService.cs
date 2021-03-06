﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MoneyManager.Business.Models;
using MoneyManager.DataAccess.Models;
using MoneyManager.DataAccess.Repositories;

namespace MoneyManager.Business.Services
{
    public class UserService : BaseService<User>
    {
        private readonly UserRepository _userRepository; 
        public UserService(UserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }
        public List<User> GetUserByEmail(string email)
        {
            Expression < Func<User, bool> >  expression = user => user.Email == email;
            return _userRepository
                .GetAllItems(expression)
                .ToList();
        }
        /// <summary>
        /// Query returns the user list sorted by the user’s name.
        /// </summary>
        /// <returns>Output model includes User.Id, User.Name and User.Email</returns>
        public List<UserWithoutBalance> GetUsersSortedList()
        {
            return _userRepository
                .GetAllItems()
                .Select(user =>new UserWithoutBalance()
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Email = user.Email
                })
                .OrderBy(user => user.Name)
                .ToList();
        }
        /// <summary>
        /// Query returns the current balance for the users.
        /// </summary>
        /// <returns>Output model includes User.Id, User.Email, User.Name, and Balance.</returns>
        //Query returns the current balance for the users.
        //Each record of the output model includes User.Id, User.Email, User.Name, and Balance.
        public List<UserWithBalance> GetUsersBalances()
        {
            return _userRepository
                .GetAllItems()
                .Select(user => new UserWithBalance
                {
                    UserId = user.UserId,
                    Balance = user.Balance,
                    Name = user.Name,
                    Email = user.Email
                })
                .ToList();
        }





    }
}

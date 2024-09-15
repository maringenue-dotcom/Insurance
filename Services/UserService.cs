﻿using API.DBContext;
using API.DBModels;
using API.Models;
using Microsoft.AspNetCore.Identity;

namespace API.Services
{
    public class UserService : IUserService
    {
        private dbcontext _db;
        private PasswordHasher<User> hash = new PasswordHasher<User>();
        public UserService(dbcontext db)
        {
            _db = db;
        }

        public User GetById(int id)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public int IsValidUserInformation(LoginModel model)
        {
            var user = _db.Users.Where(u => u.Login == model.Login );

            foreach (var row in user)
                if (row != null && hash.VerifyHashedPassword(row, row.Password, model.Password) == PasswordVerificationResult.Success)
                    return row.Id;
                else return 00;
            return 00;
        }
    }
}

﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Vehicles06.API.Data;
using Vehicles06.API.Data.Entities;

namespace Vehicles06.API.Helpers
{
    public class UserHelper : IUserHelper
    {                           //clase personalizada
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _rolManager;
        private readonly DataContext _context;

        public UserHelper(UserManager<User> userManager,
            RoleManager<IdentityRole> rolManager, DataContext context)
        {
            _userManager = userManager;
            _rolManager = rolManager;
            _context = context;
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task AddUserToRoleAsync(User user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExist = await _rolManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await _rolManager.CreateAsync(new IdentityRole { Name = roleName });
            }
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await _context.Users
                .Include(x => x.DocumentType)
                .FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> IsUserInRoleAsync(User user, string rolename)
        {
            return await _userManager.IsInRoleAsync(user, rolename);
        }
    }
}
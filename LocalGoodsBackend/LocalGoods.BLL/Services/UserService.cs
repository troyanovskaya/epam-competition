using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LocalGoods.BLL.Exceptions.NotFoundException;
using LocalGoods.BLL.Models.User;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LocalGoods.BLL.Services
{
    public class UserService: IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public UserService(
            UserManager<User> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }


        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return _mapper.Map<IEnumerable<UserModel>>(users);
        }

        public async Task<UserModel> GetByIdAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                throw new UserNotFoundException(id);
            }

            return _mapper.Map<UserModel>(user);
        }

        public async Task<IEnumerable<string>> GetRolesByUserId(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                throw new UserNotFoundException(userId);
            }

            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }
    }
}
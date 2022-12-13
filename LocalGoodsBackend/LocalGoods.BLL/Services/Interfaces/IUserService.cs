using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalGoods.BLL.Models.User;

namespace LocalGoods.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAllAsync();
        Task<UserModel> GetByIdAsync(Guid id);
        Task<IEnumerable<string>> GetRolesByUserId(Guid userId);
    }
}
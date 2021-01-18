using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserApi.Models;

namespace UserApi.IServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserService
    {
        Task<IEnumerable<IdentityUser>> GetUsers();
        Task<IdentityUser> GetUserById(string id);
        Task<string> AddUser(IdentityUser user, string password);
        Task<IdentityUser> UpdateUser(IdentityUser user);
        Task<string> DeleteUser(string id);
        //Task<bool> LogInUser(LoginModel model);
        //Task<IActionResult> LogInUser(LoginModel model);
    }
}

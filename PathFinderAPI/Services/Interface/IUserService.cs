using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PathFinderAPI.Models.User.Entity;
using PathFinderAPI.Models.User.Response;

namespace PathFinderAPI.Services.Interface
{
    public interface IUserService
    {
        Task<bool> Register(User user);
        Task<AuthenticateResponse> Authenticate(string username, string password);
        Task<List<User>> getAllUsers();
         Task<List<User>> GetUsersByRole();
    Task UpdateUser(User user);
        Task RemoveUser(Guid cid);
        Task ForgotPassword(User Email);
        Task ResetPassword(User user, string password);
  }
}

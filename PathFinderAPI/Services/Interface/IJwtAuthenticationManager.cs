using System;
using System.Threading.Tasks;
using PathFinderAPI.Models.User.Response;

namespace PathFinderAPI.Services.Interface
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string userId, string role);
    }
}
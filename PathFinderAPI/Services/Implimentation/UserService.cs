using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PathFinderAPI.Data;
using PathFinderAPI.Models.User.Entity;
using PathFinderAPI.Models.User.Response;
using PathFinderAPI.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace PathFinderAPI.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;

        public UserService(ApplicationDbContext context, IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _context = context;
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        public async Task<bool> Register(User user)
        {
            if (await _context.Users.Where(u => u.EmailAddress == user.EmailAddress).FirstOrDefaultAsync() != null)
            {
                throw new Exception("Email address is already taken. Please use another email address");
            }
            else if (await _context.Users.Where(u => u.PhoneNumber == user.PhoneNumber).FirstOrDefaultAsync() != null)
            {
                throw new Exception("Phone number is already taken. Please use another phone number");
            }
            else if (await _context.Users.Where(u => u.Username == user.Username).FirstOrDefaultAsync() != null)
            {
                throw new Exception("Username is already taken. Please use another username");
            }

            user.UserId = new Guid();
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Role = "customer";
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            //bool verified = BCrypt.Net.BCrypt.Verify("Pa$$w0rd", passwordHash); returns a bool

            return true;
        }

        public async Task<AuthenticateResponse> Authenticate(string username, string password)
        {
            string HashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            User user = await _context.Users.Where(u => u.Username == username).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Exception("User not registered");
            }

            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new Exception("Incorrect Password");
            }
            

            AuthenticateResponse response = new AuthenticateResponse();

            response.UserId = user.UserId;
            response.Username = user.Username;
            response.Role = user.Role;
            response.Token = _jwtAuthenticationManager.Authenticate(user.UserId.ToString(), user.Role);

            return response;
        }

        public async Task<List<User>> getAllUsers()
        {
            return await _context.Users.ToListAsync();
;       }
        public async Task  ResetPassword(User Email, string password)
        {
          User user = await _context.Users.Where(u => u.EmailAddress == Email.EmailAddress).FirstOrDefaultAsync();
          
        }
        public async Task<List<User>> GetUsersByRole()
        {
          return await _context.Users.Where(p => p.Role == "customer").ToListAsync();
        }
        public async Task ForgotPassword(User user)
        {
          if (await _context.Users.Where(u => u.EmailAddress == user.EmailAddress).FirstOrDefaultAsync() == null)
          {
            throw new Exception("Email address is not found. Please enter registerd email address");
          }

        }
        public async Task RemoveUser(Guid ptid)
        {
          User user = await _context.Users.Where(pt => pt.UserId == ptid).FirstOrDefaultAsync();

          if (user != null)
          {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
          }
        }
        public async Task UpdateUser(User user)
        {
          User users = await _context.Users.Where(pt => pt.UserId == user.UserId).FirstOrDefaultAsync();

          if (users != null)
          {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
          }
        }
  }
}

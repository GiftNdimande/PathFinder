using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using PathFinderAPI.Data;
using PathFinderAPI.Models.User.Entity;
using PathFinderAPI.Models.User.Request;
using PathFinderAPI.Models.User.Response;
using PathFinderAPI.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PathFinderAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/[controller]/register")]
        public async Task<IActionResult> Register([FromBody] registerRequest request)
        {
            try
            {
                User user = new User();
                user.FirstName = request.FirstName;
                user.EmailAddress = request.EmailAddress;
                user.IDNumber = request.IDNumber;
                user.LastName = request.LastName;
                user.Password = request.Password;
                user.PhoneNumber = request.PhoneNumber;
                user.Title = request.Title;
                user.Username = request.Username;
                var res = await _userService.Register(user);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(
                        new
                        {
                            message = e.Message
                        }
                    );
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/[controller]/login")]
        public async Task<IActionResult> Login([FromBody] AuthenticateRequest request)
        {
            try
            {
                AuthenticateResponse  response= await _userService.Authenticate(request.Username, request.Password);

                if(response.Token == null)
                {
                    return Unauthorized();
                }
                else
                {
                    return Ok(response);
                }
                
            }
            catch(Exception e)
            {
                return BadRequest(
                        new
                        {
                            message = e.Message
                        }
                    );
            }
        }
    private readonly ApplicationDbContext _context;
    [Route("api/isvalidemail")]
    [HttpPost]
    public object isValidEmail([FromBody] User user)
    {
      try
      {
        if (user != null || user.EmailAddress != null)
        {
          //db.Configuration.ProxyCreationEnabled = false;
          var useremail = _context.Users.Where(x => x.EmailAddress == user.EmailAddress).Select(x => x.EmailAddress).FirstOrDefault();
          if (useremail == null)
          {
            dynamic obj = new ExpandoObject();
            obj.Message = "Email Address is valid.";
            return obj;
          }
          else
          {
            dynamic obj = new ExpandoObject();
            obj.Error = "Email Address is already in use.";
            return obj;
          }
        }
        else
        {
          dynamic obj = new ExpandoObject();
          obj.Error = "Referral code is empty.";
          return obj;
        }
      }
      catch (Exception e)
      {
        dynamic obj = new ExpandoObject();
        obj.Error = (e.InnerException);
        return obj;
      }
    }


         [AllowAnonymous]
        [HttpGet]
        [Route("api/[controller]/getAllUsers")]
        public async Task<List<User>> getAllUsers()
        {
            return await _userService.getAllUsers();
        }
        [HttpGet]
        [Route("api/[controller]/getUsersByRole")]
        public async Task<List<User>> GetUsersByRole()
        {
          return await _userService.GetUsersByRole();
        }
        [HttpDelete]
        [Route("api/[controller]/removeUser")]
        public async Task<IActionResult> RemoveUser([FromQuery] Guid ptid)
        {
          await _userService.RemoveUser(ptid);

          return Ok();
        }
        [HttpPut]
        [Route("api/[controller]/updateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
          await _userService.UpdateUser(user);

          return Ok();
        }
  }
}

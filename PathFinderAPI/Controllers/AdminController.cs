using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PathFinderAPI.Controllers
{
    //[Authorize]
    [ApiController]
    public class AdminController: ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminrService)
        {
            _adminService = adminrService;
        }

 

        [HttpPost]
        [Route("api/[controller]/addCourse")]
        public async Task<IActionResult> AddCourse([FromBody] AddCourseRequest request)
        {
          await _adminService.AddCourse(request);
          return Ok();
        }

       [HttpGet]
        [Route("api/[controller]/getEmployeeTypes")]
        public async Task<List<Courses>> GetCourse()
        {
          return await _adminService.GetCourses();
        }


        [HttpDelete]
        [Route("api/[controller]/removeCourse")]
        public async Task<IActionResult> RemoveCourse([FromQuery] Guid ptid)
        {
          await _adminService.RemoveCourse(ptid);

          return Ok();
        }
        [HttpPut]
        [Route("api/[controller]/updateCourse")]
        public async Task<IActionResult> UpdateCourse([FromBody] UpdateCourse course)
        {
          await _adminService.UpdateCourse(course);
     
          return Ok();
        }



        [HttpPost]
        [Route("api/[controller]/addBursarie")]
        public async Task<IActionResult> AddBursarie([FromBody] AddBursarieRequest request)
        {
          await _adminService.AddBursarie(request);
          return Ok();
        }

        [HttpGet]
        [Route("api/[controller]/getBursaries")]
        public async Task<List<Bursarie>> GetBursaries()
        {
          return await _adminService.GetBursaries();
        }

        [HttpDelete]
        [Route("api/[controller]/removeBursarie")]
        public async Task<IActionResult> RemoveBursarie([FromQuery] Guid ptid)
        {
          await _adminService.RemoveBursarie(ptid);

          return Ok();
        }

        [HttpPut]
        [Route("api/[controller]/updateEmployeeType")]
        public async Task<IActionResult> UpdateBursarie([FromBody] Bursarie )
        {
          await _adminService.UpdateBursarie(bursarie);

          return Ok();
        }

        [HttpPost]
        [Route("api/[controller]/addLearnership")]
        public async Task<IActionResult> AddLearnership([FromBody] AddLearnershipRequest request)
        {
          await _adminService.AddLearnership(request);
          return Ok();
        }

        [HttpGet]
        [Route("api/[controller]/getLearnerships")]
        public async Task<List<Learnerships>> GetLearnerships()
        {
          return await _adminService.GetLearnerships();
        }
          
        [HttpDelete]
        [Route("api/[controller]/removeLearnership")]
        public async Task<IActionResult> RemoveLearnership([FromQuery] Guid ptid)
        {
          await _adminService.RemoveLearnership(ptid);

          return Ok();
        }

        [HttpPut]
        [Route("api/[controller]/updateLearnership")]
        public async Task<IActionResult> UpdateLearnership([FromBody] Learnership learnership)
        {
          await _adminService.UpdateELearnership(learnership);

          return Ok();
        }

    }
}

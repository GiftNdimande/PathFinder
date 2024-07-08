using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PathFinderAPI.Models.Admin.Entity;
using PathFinderAPI.Models.Admin.Request;
using PathFinderAPI.Models.Course.Entity;
using PathFinderAPI.Models.Course.Request;

namespace PathFinderAPI.Services.Interface
{
    public interface IAdminService
    {
     

        Task AddCourse(AddCourseRequest request);
        Task<List<Course>> GetCourses();
        Task UpdateCourse(Course course);
        Task RemoveCourse(Guid ptid);

        Task AddLearnership(AddLearnershipRequest request);
        Task<List<Learnership>> GetLearnerships();
        Task UpdateLearnership(Learnership learnership);
        Task RemoveLearnership(Guid ptid);

        Task AddBursarie(AddBursarieRequest request);
        Task<List<Bursarie>> GetBursaries();
         
       Task UpdateBursarie(Bursarie bursarie);
        Task RemoveBursarie(Guid ptid);

        
    }


}

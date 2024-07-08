using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PathFinderAPI.Data;
using PathFinderAPI.Models.Admin.Entity;
using PathFinderAPI.Models.Admin.Request;
using PathFinderAPI.Models.Course.Entity;
using PathFinderAPI.Models.Course.Request;
using PathFinderAPI.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace PathFinderAPI.Services.Implementation
{
  public class AdminService : IAdminService
  {
    private readonly ApplicationDbContext _context;

    public AdminService(ApplicationDbContext context)
    {
      _context = context;
    }



    public async Task AddCourse(AddCourseRequest request)
    {
      Course course = new Course();
      course.Description = request.Description;
      course.Faculty = request.Faculty;
      course.Aps = request.Aps;
      course.Requirements = request.Requirements;
      course.Institution = request.Institution;
      course.Name = request.Name;
      course.CourseId = new Guid();


      await _context.Courses.AddAsync(course);
      await _context.SaveChangesAsync();
    }
    public async Task RemoveCourse(Guid ptid)
    {
      Course courses = await _context.Courses.Where(pt => pt.CourseId == ptid).FirstOrDefaultAsync();

      if (courses != null)
      {
        _context.Courses.Remove(courses);
        await _context.SaveChangesAsync();
      }
    }
    public async Task UpdateCourse(Course course)
    {
      Course courses = await _context.Courses.Where(pt => pt.CourseId == course.CourseId).FirstOrDefaultAsync();

      if (courses != null)
      {
        _context.Courses.Update(courses);
        await _context.SaveChangesAsync();
      }
    }
    public async Task<List<Course>> GetCourses()
    {
      return await _context.Courses.ToListAsync();
    }
    public async Task AddLearnership(AddLearnershipRequest request)
    {
      Learnership learnership = new Learnership();
      learnership.Name = request.FirstName;
      learnership.Program = request.LastName;
      learnership.Institution = request.PhoneNumber;
      learnership.Requirements = request.EmailAddress;
      learnership.LearnershipId = new Guid();

      await _context.Learnerships.AddAsync(learnership);
      await _context.SaveChangesAsync();
    }
    public async Task AddBursarie(AddBursarieRequest request)
    {
      Bursarie bursarie = new Bursarie();
      bursarie.Description = request.Description;
      bursarie.Name = request.Name;
      bursarie.Institution = request.Institution;
      bursarie.Course = request.Course;
      bursarie.Requirements = request.Requirements;
      bursarie.BursarieId = new Guid();

      await _context.Bursaries.AddAsync(bursarie);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateLearnership(Learnership learnership)
    {
      Learnership learnership1 = await _context.Learnerships.Where(pt => pt.LearnershipId == learnership.LearnershipId).FirstOrDefaultAsync();

      if (learnership1 != null)
      {
        _context.Learnership.Update(learnership);
        await _context.SaveChangesAsync();
      }
    }
    public async Task RemoveLearnership(Guid ptid)
    {
      Learnership learnership = await _context.Learnerships.Where(pt => pt.LearnershipId == ptid).FirstOrDefaultAsync();

      if (learnership != null)
      {
        _context.Learnerships.Remove(learnership);
        await _context.SaveChangesAsync();
      }
    }
    public async Task<List<Learnership>> GetLearnerships()
    {
      return await _context.Learnerships.ToListAsync();
    }
    public async Task<List<Bursarie>> GetBursaries()
    {
      return await _context.Bursaries.ToListAsync();
    }
    public async Task RemoveBursarie(Guid ptid)
    {
      Bursarie bursarie = await _context.Bursaries.Where(pt => pt.EmployeeId == ptid).FirstOrDefaultAsync();

      if (bursarie != null)
      {
        _context.Bursaries.Remove(bursarie);
        await _context.SaveChangesAsync();
      }
    }
    public async Task UpdateBursarie(Bursarie bursarie)
    {
      Bursarie bursarie1 = await _context.Bursarie.Where(pt => pt.BursarieId == bursarie.BursarieId).FirstOrDefaultAsync();

      if (bursarie1 != null)
      {
        _context.Bursarie.Update(bursarie);
        await _context.SaveChangesAsync();
      }
    }
  }
}

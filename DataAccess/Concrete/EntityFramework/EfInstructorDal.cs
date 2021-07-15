using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfInstructorDal : EfEntityRepositoryBase<Instructor, SchoolManagementContext>, IInstructorDal
    {
        public InstructorDetailDto GetInstructorDetail(int instructorId)
        {
           using (SchoolManagementContext context =new SchoolManagementContext())
            {
                var result = from instructor in context.Instructors.Where(i => i.InstructorId == instructorId)
                             join course in context.Courses
                             on instructor.InstructorId equals course.InstructorId

                             select new InstructorDetailDto()
                             {
                                 InstructorId = instructor.InstructorId,
                                 FirstName=instructor.FirstName,
                                 LastName=instructor.LastName,
                                 CourseName=course.CourseName
                             };

                return result.FirstOrDefault();
            }
        }

        public List<InstructorDetailDto> GetInstructorsDetails(Expression<Func<InstructorDetailDto, bool>> filter = null)
        {
            using (SchoolManagementContext context = new SchoolManagementContext())
            {
                var result = from instructor in context.Instructors
                             join course in context.Courses
                             on instructor.InstructorId equals course.InstructorId

                             select new InstructorDetailDto()
                             {
                                 InstructorId = instructor.InstructorId,
                                 FirstName = instructor.FirstName,
                                 LastName = instructor.LastName,
                                 CourseName = course.CourseName
                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}


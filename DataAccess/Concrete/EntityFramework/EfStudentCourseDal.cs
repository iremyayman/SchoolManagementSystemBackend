using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfStudentCourseDal : EfEntityRepositoryBase<StudentCourse, SchoolManagementContext>, IStudentCourseDal
    {
        public StudentCourseDetailDto GetStudentCourseDetails(int studentCourseId)
        {
            using (SchoolManagementContext context =new SchoolManagementContext())
            {
                var result = from studentCourse in context.StudentCourses.Where(s => s.StudentId == studentCourseId)
                             join student in context.Students
                             on studentCourse.StudentId equals student.StudentId

                             join course in context.Courses
                             on studentCourse.CourseId equals course.CourseId
                             select new StudentCourseDetailDto()
                             {
                                 CourseId = course.CourseId,
                                 StudentId = student.StudentId,
                                 CourseName = course.CourseName,
                                 FirstName = student.FirstName,
                                 LastName = student.LastName,
                                 StudentNumber = student.StudentNumber,
                                 Grade1 = studentCourse.Grade1,
                                 Grade2 = studentCourse.Grade2,
                                 Final = studentCourse.Final,
                                 TotalGrade = studentCourse.TotalGrade
                             };
                return result.FirstOrDefault();
            }
        }

        public List<StudentCourseDetailDto> GetStudentsCourseDetails(Expression<Func<StudentCourseDetailDto, bool>> filter = null)
        {
           using (SchoolManagementContext context=new SchoolManagementContext())
            {
                var result = from studentCourse in context.StudentCourses
                             join student in context.Students
                             on studentCourse.StudentId equals student.StudentId

                             join course in context.Courses
                             on studentCourse.CourseId equals course.CourseId

                             select new StudentCourseDetailDto()
                             {
                                 CourseId = course.CourseId,
                                 StudentId = student.StudentId,
                                 CourseName = course.CourseName,
                                 FirstName = student.FirstName,
                                 LastName = student.LastName,
                                 StudentNumber=student.StudentNumber,
                                 Grade1=studentCourse.Grade1,
                                 Grade2=studentCourse.Grade2,
                                 Final=studentCourse.Final,
                                 TotalGrade=studentCourse.TotalGrade

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }

        }
    }
}

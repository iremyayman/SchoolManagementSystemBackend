using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IStudentCourseDal :IEntityRepository<StudentCourse>
    {
        List<StudentCourseDetailDto> GetStudentsCourseDetails(Expression<Func<StudentCourseDetailDto, bool>> filter = null);
        StudentCourseDetailDto GetStudentCourseDetails(int studentCourseId);
    }
}

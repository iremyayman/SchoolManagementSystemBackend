using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IInstructorDal :IEntityRepository<Instructor>
    {
        List<InstructorDetailDto> GetInstructorsDetails(Expression<Func<InstructorDetailDto, bool>> filter = null);
        InstructorDetailDto GetInstructorDetail(int instructorId);
    }
}

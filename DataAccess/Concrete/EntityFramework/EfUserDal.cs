using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
   public  class EfUserDal :EfEntityRepositoryBase<User,SchoolManagementContext>,IUserDal
    {
    }
}

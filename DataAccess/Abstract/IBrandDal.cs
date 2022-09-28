using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;

namespace DataAccess.Abstract
{
   public interface IBrandDal :  IEntityRepository<Brand>
    {
    }
}

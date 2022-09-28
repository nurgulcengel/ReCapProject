using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {
 
        public string GetBrandNameByBrandId(int id)
        {
            using (RentCarContext context= new RentCarContext())
            {
               return   context.Brands.SingleOrDefault(b => b.Id == id).Name;
                
            }
            
        }

        public List<CarDetailsDTO> GetCarsDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {

                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join co in context.Colors
                             on c.ColorId equals co.Id
                             select new CarDetailsDTO
                             {
                                 ColorName = co.Name,
                                 BrandName = b.Name,
                                 CarId=c.Id,
                                 DailyPrice=c.DailyPrice,
                                 ModelYear=c.ModelYear,
                                 Description=c.Description

                             };

                return result.ToList();

            }
        }
    }
}

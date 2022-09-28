using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
        public IResult Add(Car car);
        public IResult Delete(Car car);
        public IResult Update(Car car);
        public IDataResult<List<Car>>GetCarsByBrandId(int id);
        public IDataResult<List<Car>>GetCarsByColorId(int id);
        public IDataResult<Car>GetById(int id);
        public IDataResult<List<Car>> GetAll();


    }
}

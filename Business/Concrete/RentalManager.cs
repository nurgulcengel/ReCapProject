using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentDal;

        public RentalManager(IRentalDal rentDal)
        {
            _rentDal = rentDal;
        }

        //Add kiralama anlamında kullanıldı
        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate.HasValue)
            {
                _rentDal.Add(rental);

            }
            return new SuccessResult(Messages.SuccessAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentDal.Delete(rental);
            return new SuccessResult(Messages.SuccessDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            List < Rental > result= _rentDal.GetAll();
            return new SuccessDataResult<List<Rental>>(result, Messages.SuccesListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
          Rental rental= _rentDal.Get(r => r.Id == id);
            return new SuccessDataResult<Rental>(rental, Messages.SuccessGet);
        }

        public IResult Update(Rental rental)
        {
            _rentDal.Update(rental);
            return new SuccessResult(Messages.SuccessUpdated);
        }
    }
}

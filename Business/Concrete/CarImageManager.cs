using Business.Abstract;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        IFileHelper _fileHelper;
        ICarImageDal _carImageDal;

        public CarImageManager(IFileHelper fileHelper, ICarImageDal carImageDal)
        {
            _fileHelper = fileHelper;
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            if (file == null)
            {
                return new ErrorResult();
            }
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage));
            if (result != null)
            {
                return new ErrorResult();
            }
            carImage.ImagePath = _fileHelper.Upload(file, PathConstans.CarImageRoot);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();

        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstans.CarImageRoot + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var result = _fileHelper.Update(file, PathConstans.CarImageRoot + carImage.ImagePath, PathConstans.CarImageRoot);
            carImage.ImagePath = result;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarIsHaveImage(carId));
            if (result != null)
            {
                return new SuccessDataResult<List<CarImage>>(GetDefaultImage(carId));
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        private IResult CheckIfCarImageLimit(CarImage carImage)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carImage.CarId).Count();
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IResult CheckCarIsHaveImage(int carId)
        {
            if (_carImageDal.GetAll(c => c.CarId == carId).Count == 0)
            {
                return new ErrorResult();
            }

            return new SuccessResult();

        }

        private List<CarImage> GetDefaultImage(int carId)
        {
            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage {CarId=carId, Date = DateTime.Now, ImagePath = "defaultpic.jpg" });
            return carImage;
        }
    }
}
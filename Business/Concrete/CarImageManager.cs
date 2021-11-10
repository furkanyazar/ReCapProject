using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        private IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        [SecuredOperation("customer,admin")]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageLimit(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = _fileHelper.Add(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.CarImageAdded);
        }

        [SecuredOperation("customer,admin")]
        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);

            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<CarImage> GetByCarImageId(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == carImageId), Messages.CarImagesListed);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data, Messages.CarImageIsNotExists);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId), Messages.CarImagesListed);
        }

        [SecuredOperation("customer,admin")]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = _fileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagePath, PathConstants.ImagesPath);

            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckIfCarImageLimit(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;

            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImage = new List<CarImage>();

            carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "default.png" });

            return new SuccessDataResult<List<CarImage>>(carImage, Messages.CarImagesListed);
        }

        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;

            if (result > 0)
            {
                return new SuccessResult(Messages.CarImagesListed);
            }

            return new ErrorResult(Messages.CarImageIsNotExists);
        }
    }
}

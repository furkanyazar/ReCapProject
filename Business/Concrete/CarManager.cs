using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        private ICarImageService _carImageService;

        public CarManager(ICarDal carDal, ICarImageService carImageService)
        {
            _carDal = carDal;
            _carImageService = carImageService;
        }

        [SecuredOperation("customer,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        [SecuredOperation("customer,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);

            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<Car> GetByCarId(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId), Messages.CarsListed);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetails()
        {
            List<CarDetailDto> carDetailDtos = _carDal.GetCarsDetails();

            foreach (var carDetailDto in carDetailDtos)
            {
                carDetailDto.CarImagesPaths = new List<string>();

                foreach (var data in _carImageService.GetByCarId(carDetailDto.CarId).Data)
                {
                    carDetailDto.CarImagesPaths.Add(data.ImagePath);
                }
            }

            return new SuccessDataResult<List<CarDetailDto>>(carDetailDtos, Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.CarsListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.CarsListed);
        }

        [SecuredOperation("customer,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new SuccessResult(Messages.CarUpdated);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandId(int brandId)
        {
            List<CarDetailDto> carDetailDtos = _carDal.GetCarsDetailsByBrandId(brandId);

            foreach (var carDetailDto in carDetailDtos)
            {
                carDetailDto.CarImagesPaths = new List<string>();

                foreach (var data in _carImageService.GetByCarId(carDetailDto.CarId).Data)
                {
                    carDetailDto.CarImagesPaths.Add(data.ImagePath);
                }
            }

            return new SuccessDataResult<List<CarDetailDto>>(carDetailDtos, Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailsByColorId(int colorId)
        {
            List<CarDetailDto> carDetailDtos = _carDal.GetCarsDetailsByColorId(colorId);

            foreach (var carDetailDto in carDetailDtos)
            {
                carDetailDto.CarImagesPaths = new List<string>();

                foreach (var data in _carImageService.GetByCarId(carDetailDto.CarId).Data)
                {
                    carDetailDto.CarImagesPaths.Add(data.ImagePath);
                }
            }

            return new SuccessDataResult<List<CarDetailDto>>(carDetailDtos, Messages.CarsListed);
        }

        public IDataResult<CarDetailDto> GetCarDetail(int carId)
        {
            CarDetailDto carDetailDto = _carDal.GetCarDetailDto(carId);
            carDetailDto.CarImagesPaths = new List<string>();

            foreach (var data in _carImageService.GetByCarId(carId).Data)
            {
                carDetailDto.CarImagesPaths.Add(data.ImagePath);
            }

            return new SuccessDataResult<CarDetailDto>(carDetailDto, Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandIdAndColorId(int brandId, int colorId)
        {
            List<CarDetailDto> carDetailDtos = _carDal.GetCarsDetailsByBrandIdAndColorId(brandId, colorId);

            foreach (var carDetailDto in carDetailDtos)
            {
                carDetailDto.CarImagesPaths = new List<string>();

                foreach (var data in _carImageService.GetByCarId(carDetailDto.CarId).Data)
                {
                    carDetailDto.CarImagesPaths.Add(data.ImagePath);
                }
            }
            return new SuccessDataResult<List<CarDetailDto>>(carDetailDtos, Messages.CarsListed);
        }
    }
}

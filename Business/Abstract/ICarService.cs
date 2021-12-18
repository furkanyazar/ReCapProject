using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();

        IDataResult<List<Car>> GetCarsByBrandId(int brandId);

        IDataResult<List<Car>> GetCarsByColorId(int colorId);

        IDataResult<Car> GetByCarId(int carId);

        IResult Add(Car car);

        IResult Update(Car car);

        IResult Delete(Car car);

        IDataResult<List<CarDetailDto>> GetCarsDetails();

        IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandId(int brandId);

        IDataResult<List<CarDetailDto>> GetCarsDetailsByColorId(int colorId);

        IDataResult<List<CarDetailDto>> GetCarsDetailsByBrandIdAndColorId(int brandId, int colorId);

        IDataResult<CarDetailDto> GetCarDetail(int carId);
    }
}

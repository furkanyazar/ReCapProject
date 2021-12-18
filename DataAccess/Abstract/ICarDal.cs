using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarsDetails();

        List<CarDetailDto> GetCarsDetailsByBrandId(int brandId);

        List<CarDetailDto> GetCarsDetailsByColorId(int colorId);

        List<CarDetailDto> GetCarsDetailsByBrandIdAndColorId(int brandId, int colorId);

        CarDetailDto GetCarDetailDto(int carId);
    }
}

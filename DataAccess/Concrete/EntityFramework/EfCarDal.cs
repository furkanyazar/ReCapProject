using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public CarDetailDto GetCarDetailDto(int carId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             where c.CarId == carId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto { BrandName = b.BrandName, CarId = c.CarId, CarName = c.CarName, ColorName = co.ColorName, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear, CarImagesPaths = new List<string>() };

                return result.SingleOrDefault();
            }
        }

        public List<CarDetailDto> GetCarsDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto { BrandName = b.BrandName, CarId = c.CarId, CarName = c.CarName, ColorName = co.ColorName, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear, CarImagesPaths = new List<string>() };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetailsByBrandId(int brandId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             where c.BrandId == brandId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto { BrandName = b.BrandName, CarId = c.CarId, CarName = c.CarName, ColorName = co.ColorName, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear, CarImagesPaths = new List<string>() };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetailsByBrandIdAndColorId(int brandId, int colorId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             where c.BrandId == brandId
                             where c.ColorId == colorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto { BrandName = b.BrandName, CarId = c.CarId, CarName = c.CarName, ColorName = co.ColorName, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear, CarImagesPaths = new List<string>() };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarsDetailsByColorId(int colorId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             where c.ColorId == colorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto { BrandName = b.BrandName, CarId = c.CarId, CarName = c.CarName, ColorName = co.ColorName, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear, CarImagesPaths = new List<string>() };

                return result.ToList();
            }
        }
    }
}

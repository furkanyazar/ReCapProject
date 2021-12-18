using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public RentalDetailDto GetRentalDetails(int rentalId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             where r.RentalId == rentalId
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new RentalDetailDto { BrandName = b.BrandName, CarName = c.CarName, ColorName = co.ColorName, CompanyName = cu.CompanyName, DailyPrice = c.DailyPrice, Description = c.Description, ModelYear = c.ModelYear, RentalId = r.RentalId, RentDate = r.RentDate, ReturnDate = r.ReturnDate };

                return result.SingleOrDefault();
            }
        }

        public List<RentalsDetailDto> GetRentalsDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             select new RentalsDetailDto { RentalId = r.RentalId, CarName = c.CarName, CompanyName = cu.CompanyName, RentDate = r.RentDate, ReturnDate = r.ReturnDate };

                return result.ToList();
            }
        }
    }
}

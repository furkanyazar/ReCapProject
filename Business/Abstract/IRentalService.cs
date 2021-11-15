using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();

        IDataResult<Rental> GetByRentalId(int rentalId);

        IResult Add(Rental rental);

        IResult Update(Rental rental);

        IResult Delete(Rental rental);

        IResult AddTransactionalTest(Rental rental);

        IDataResult<List<RentalDetailDto>> GetRentalsDetails();
    }
}

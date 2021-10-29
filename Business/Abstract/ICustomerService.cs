using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();

        IDataResult<Customer> GetByCustomerId(int customerId);

        IDataResult<Customer> GetByUserId(int userId);

        IResult Add(Customer customer);

        IResult Update(Customer customer);

        IResult Delete(Customer customer);

        IDataResult<List<CustomerDetailDto>> GetCustomersDetails();
    }
}

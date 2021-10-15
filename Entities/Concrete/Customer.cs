using Core.Entities;

namespace Entities.Concrete
{
    public class Customer : User, IEntity
    {
        public int CustomerId { get; set; }
        public string CompanyName { get; set; }
    }
}
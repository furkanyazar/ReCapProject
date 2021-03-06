using Core.Entities.Abstract;
using System;

namespace Entities.DTOs
{
    public class RentalsDetailDto : IDto
    {
        public int RentalId { get; set; }
        public string CarName { get; set; }
        public string CompanyName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}

using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public List<RentDetailDto> GetRentDetails()
        {
            using (var context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                             join ca in context.Cars
                             on r.CarId equals ca.Id
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join b in context.Brands
                             on ca.BrandId equals b.BrandId
                             join u in context.Users
                             on cu.UserId equals u.UserId
                             select new RentDetailDto
                             {
                                 Id = r.RentalId,
                                 CarBrand = b.BrandName,
                                 CarModel = ca.Description,
                                 CustomerFirstName = u.FirstName,
                                 CustomerLastName = u.LastName,
                                 CompanyName = cu.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = (DateTime)r.ReturnDate
                             };

                return result.ToList();
            }
        }
    }
}

using System;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
            public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
            {
                using (RentACarContext context = new RentACarContext())
                {
                var result = from r in context.Rentals
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join cl in context.Colors
                             on c.ColorId equals cl.ColorId
                             join cs in context.Customers
                             on r.CustomerId equals cs.CustomerId
                             join u in context.Users
                             on cs.UserId equals u.UserId
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarId = c.CarId,
                                 BrandId = b.BrandId,
                                 ColorId = cl.ColorId,
                                 CustomerId = cs.CustomerId,
                                 DailyPrice = c.DailyPrice,
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = cl.ColorName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = cs.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                    return result.ToList();
                }
            }
    }
}



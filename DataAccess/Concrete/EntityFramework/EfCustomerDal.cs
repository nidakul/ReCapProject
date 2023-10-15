using System;
using System.Linq.Expressions;
using Castle.Core.Resource;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from u in context.Users
                             join cs in context.Customers
                             on u.UserId equals cs.UserId
                             join r in context.Rentals
                             on cs.CustomerId equals r.CustomerId
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             select new CustomerDetailDto
                             {
                                 CustomerId = cs.CustomerId,
                                 UserId = u.UserId,
                                 CarId = c.CarId,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 CompanyName = cs.CompanyName
                             };

                return result.ToList();
            }
        }

    }
}


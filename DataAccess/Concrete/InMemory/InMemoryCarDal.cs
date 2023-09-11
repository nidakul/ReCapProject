using System;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;
using System.Linq.Expressions;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car { CarId = 1, BrandId = 2, ColorId = 3, ModelYear = 1995, DailyPrice = 135.34m, Description = "New Car" },
                new Car { CarId = 2, BrandId = 4, ColorId = 4, ModelYear = 1985, DailyPrice = 136.34m, Description = "New Car2" },
                new Car { CarId = 3, BrandId = 1, ColorId = 2, ModelYear = 2004, DailyPrice = 134.34m, Description = "New Car3" },
                new Car { CarId = 4, BrandId = 2, ColorId = 1, ModelYear = 2007, DailyPrice = 123.34m, Description = "New Car4" },
                new Car { CarId = 5, BrandId = 3, ColorId = 3, ModelYear = 2018, DailyPrice = 193.34m, Description = "New Car5" }
        };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;

        }
    }
}


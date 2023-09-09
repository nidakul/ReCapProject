using System;
using Entities.Concrete;

namespace Business.Abstract
{
	public interface ICarService
	{
		List<Car> GetAll();
		List<Car> GetByCarId(int carId);

		List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);

    }
}


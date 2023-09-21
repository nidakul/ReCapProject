using System;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
	public interface ICarImageService
	{
		IDataResult<List<CarImage>> GetAll();
		IDataResult<CarImage> GetByCarImageId(int carImageId);

		IResult Add(IFormFile formFile, CarImage carImage);
		IResult Update(IFormFile formFile, CarImage carImage);
		IResult Delete(CarImage carImage);
	}
}

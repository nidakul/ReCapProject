using System;
using System.IO;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;

        }

        public IResult Add(IFormFile formFile ,CarImage carImage)
        {
            IResult result =  BusinessRules.Run(CheckCarImageCount(carImage.CarId), GetDefaultCarImage(carImage.CarId));

            carImage.ImagePath = GuidCarName(formFile, carImage.ImagePath);

            if (result != null)
            {
                return result; 
            }
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageListed);
        }

        public IDataResult<CarImage> GetByCarImageId(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == carImageId));
        }

        public IResult Update(IFormFile formFile, CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckCarImageCount(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count();
            if(result > 5)
            {
                return new ErrorResult(Messages.CarImageCountError);
            }
            return new SuccessResult();
        }

        
        private IResult GetDefaultCarImage(int carId)
        {
            List<CarImage> carImage = new List<CarImage>();
            carImage.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "/Images/default.png"});
            return new SuccessDataResult<List<CarImage>>(carImage);
            
        }


        private string GuidCarName (IFormFile formFile,string imagePath) //IFormFile 
        {
            var result = _carImageDal.GetAll(c => c.ImagePath == imagePath);
            if (result != null)
            {
                var extend = Path.GetExtension(formFile.FileName);
                string guidName = Guid.NewGuid().ToString() + extend;
                imagePath = guidName;
                return imagePath;
            }
            return imagePath;

        }
    }
}


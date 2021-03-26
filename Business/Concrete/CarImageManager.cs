using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckCarImageLimit(carImage.CarId));

            if (result != null)
                return result;

            SaveImage(carImage);

            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);

            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(CarImage carImage)
        {
            DeleteImage(carImage.Id);

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            var getById = _carImageDal.Get(c => c.Id == carImageId);
            return new SuccessDataResult<CarImage>(getById);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var getAll = _carImageDal.GetAll();

            return new SuccessDataResult<List<CarImage>>(getAll);
        }

        public IDataResult<List<CarImage>> GetListByCarId(int carId)
        {
            var getListByCarId = _carImageDal.GetAll(c => c.CarId == carId);

            if (getListByCarId.Count > 0)
                return new SuccessDataResult<List<CarImage>>(getListByCarId);

            var path = PathNames.CarDefaultImages;
            var defaultImage = new List<CarImage> { new CarImage { ImagePath = path } };

            return new SuccessDataResult<List<CarImage>>(defaultImage);
        }

        public IResult Update(CarImage carImage)
        {
            DeleteImage(carImage.Id);
            SaveImage(carImage);

            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id));
        }

        //business rules
        private static void SaveImage(CarImage carImage)
        {
            carImage.ImagePath = UploadPathFounder.CarImageSave(carImage.Image).Result.ToString();
        }

        private void DeleteImage(int carImageId)
        {
            var image = _carImageDal.Get(c => c.Id == carImageId);
            var path = image.ImagePath;

            File.Delete(Directory.GetParent(Directory.GetCurrentDirectory()) + path);
        }

        private IResult CheckCarImageLimit(int carId)
        {
            var imageCount = _carImageDal.GetAll(c => c.CarId == carId).Count;

            if (imageCount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }

            return new SuccessResult();
        }
        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = @"\Images\logo.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImageDal.GetAll(p => p.CarId == id);
        }

    }
}

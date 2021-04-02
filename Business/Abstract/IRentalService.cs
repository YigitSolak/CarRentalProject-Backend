using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentDetailDto>> GetRentalDetail();
        IDataResult<Rental> GetByRentalId(int id);
        IDataResult<List<RentDetailDto>> GetRentDetails();
        IDataResult<List<Rental>> GetRentalByCarId(int carId);
    }
}

using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService : ICrudBase<Car>
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetByCarId(int id);
    }
}

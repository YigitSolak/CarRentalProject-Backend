using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService : ICrudBase<Brand>
    {
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetByBrandId(int id);
    }
}

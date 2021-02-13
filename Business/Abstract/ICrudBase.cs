using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICrudBase<T> where T:class,IEntity,new()
    {
        IResult Add(T entity);
        IResult Delete(T entity);
        IResult Update(T entity);
    }
}

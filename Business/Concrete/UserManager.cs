using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            //if (DateTime.Now.Hour == 23)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.Listed);
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(User user)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(User user)
        {
            IResult result = BusinessRules.Run();
            if (result != null)
            {
                return result;
            }
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}

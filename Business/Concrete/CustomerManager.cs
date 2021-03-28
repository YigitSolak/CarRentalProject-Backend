using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer entity)
        {
            if (entity.CompanyName.Length < 2)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            _customerDal.Add(entity);
            return new SuccessResult(Messages.Added);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Delete(Customer entity)
        {
            _customerDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer entity)
        {
            _customerDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.Listed);
        }

        public IDataResult<Customer> GetByCustomerId(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(b => b.CustomerId == id), Messages.Listed);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            var getCustomerDetails = _customerDal.GetCustomerDetails();
            return new SuccessDataResult<List<CustomerDetailDto>>(getCustomerDetails);
        }
    }
}

using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerUpdateValidator : AbstractValidator<Customer>
    {
        public CustomerUpdateValidator()
        {
            RuleFor(p => p.CompanyName).NotEmpty();
            RuleFor(p => p.CompanyName).MinimumLength(2);
            RuleFor(p => p.CustomerId).NotEmpty();
            RuleFor(p => p.UserId).NotEmpty();
        }
    }
}

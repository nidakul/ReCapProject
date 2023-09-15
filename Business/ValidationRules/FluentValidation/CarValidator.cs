using System;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
	public class CarValidator : AbstractValidator<Car>
	{
		public CarValidator()
		{
			RuleFor(c => c.CarName).NotEmpty();
			RuleFor(c => c.CarName).MinimumLength(2);
			RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(10).When(c => c.CarId == 1);
			RuleFor(c => c.CarName).Must(StartWithA).WithMessage("Car name must start with A");
        }

        private bool StartWithA(string arg)
        {
			return arg.StartsWith("A");
        }
    }
}


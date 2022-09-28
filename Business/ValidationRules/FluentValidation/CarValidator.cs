using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
   public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).Length(2, 250);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.ModelYear).Must(ModelYearStart).WithMessage("Hatalı model yılı girdiniz.");

        }

        private bool ModelYearStart(int year)
        {

            string ModelYear = year.ToString();
            if (ModelYear.StartsWith("19")||ModelYear.StartsWith("20"))
            {
                return true;
            }return false;
        }
    }
}



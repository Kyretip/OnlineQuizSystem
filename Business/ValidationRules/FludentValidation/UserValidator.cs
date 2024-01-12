using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FludentValidation
{
    public class UserValidator: AbstractValidator<User>
    {
        //1:17:40
        //2.49
        //2:57
        // Buraya user kuralları gelecek
        //2:57:47
        public UserValidator() {
           // RuleFor(p => p.Password).MinimumLength(8);
        }
    }
}

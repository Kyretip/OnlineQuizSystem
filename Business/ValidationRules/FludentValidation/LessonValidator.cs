﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FludentValidation
{
    public class LessonValidator: AbstractValidator<Lesson>
    {
        public LessonValidator() { 
        //RuleFor()..
        }
    }
}

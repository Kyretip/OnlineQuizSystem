﻿using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfLessonDal: EfEntityRepositoryBase<Lesson,OnlineQuizContext>, ILessonDal
    {
    }
}

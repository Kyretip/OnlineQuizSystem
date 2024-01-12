﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Results.Abstract
{
    public interface IDataResult<out T> : IResult
    {

        T Data { get; } //geriye verilen hatayı göndürür
    }
}

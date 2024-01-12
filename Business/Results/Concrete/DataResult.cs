using Business.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, string message) : base(success, message)//data mesaj durum getirir
        {
            Data = data;
        }
        public DataResult(T data, bool success) : base(success)//sadece data ve durumu getirir
        {
            Data = data;
        }
        public T Data { get; }
    }
}

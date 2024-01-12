using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Results.Concrete
{
    public class SuccessResult : Result
    {
        //True İşlem sonucu döndürür
        public SuccessResult() : base(true)//success true
        {
        }

        public SuccessResult(string message) : base(true, message)//success true ve mesaj
        {
        }
    }
}

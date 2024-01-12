using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Results.Concrete
{
     public class ErrorResult : Result
    {
        //False İşlem sonucu döndürür
        public ErrorResult() : base(false)//error false bura yanlış olmuş.
        {
        }

        public ErrorResult(string message) : base(false, message)//Error false ve mesaj
        {
        }
    }
}

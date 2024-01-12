using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserAnswerDTO
    {
        public int UserAnswerID { get; set;}  
        public QuestionDTO question {  get; set; }

        public string AnswerText { get; set; }


    }
}

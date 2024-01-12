using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
     public class AnswerDTO
    {
        public int userId { get; set; }
        public int QuestionID { get; set; }
        public int AnswerID { get; set; }
        public string text { get; set; }
    }
}

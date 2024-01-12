using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class QuestionDTO
    {
        public int QuestionID { get; set;}
        public string Name { get; set;}    
         
        public bool AnswerType { get; set;}

        public float Point { get; set;}
        public string Photo { get; set; }
        public List<Answer> Answers { get; set; }
    }
}

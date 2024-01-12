using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Question
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool AnswerType { get; set; }
        public bool HaveAnswer { get; set; }
        public int AnswerId { get; set; }
        public string Photo { get; set; }
        public int QuizId { get; set; }
        public float Point { get; set; }

    }
}

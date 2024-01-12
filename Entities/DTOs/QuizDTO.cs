using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class QuizDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }    
        public int LessonID { get; set; }
        public DateTime DueDate { get; set; }
        public List<QuestionDTO> Questions { get; set; }

    }
}

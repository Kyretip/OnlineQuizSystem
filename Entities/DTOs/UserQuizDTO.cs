using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UserQuizDTO
    {
        public int QuizId { get; set; }
        public int UserID { get; set; }
        public int LessonID { get; set; }
        public string UserName { get; set; }
        public string QuizName { get; set; }
        public string LessonName { get; set; }
        public List<UserAnswerDTO> Answers { get; set; }

    }
}

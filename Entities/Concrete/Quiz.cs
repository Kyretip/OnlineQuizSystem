using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LessonId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }

        public bool isFinalized { get; set; }

        public bool Return { get; set; }
    }
}

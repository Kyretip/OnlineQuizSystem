using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class QuizUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public float Score { get; set; }
        public bool IsActive { get; set; }

        public bool Entered { get; set; }

    }
}

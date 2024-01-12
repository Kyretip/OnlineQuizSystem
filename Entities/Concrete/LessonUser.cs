using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class LessonUser
    {
      public int Id { get; set; }
      public int UserId { get; set; }
      public int LessonId {get; set; }
      public bool isActive { get; set; }
    }
}

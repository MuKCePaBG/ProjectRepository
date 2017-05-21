using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrisiCourseWorkOOP.Entity
{
    public class DailyNoteEntity : BaseEntity
    {
       public DateTime Date { get; set; }
       public string Description { get; set; }
    }
}

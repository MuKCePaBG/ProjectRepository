using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrisiCourseWorkOOP.Entity;

namespace XrisiCourseWorkOOP.DRRepo
{
    public class DailyNoteRepository : BaseRepository<DailyNoteEntity>
    {
        public DailyNoteRepository(string filePath) : base(filePath)
        {

        }
        protected override void PopulateEntity(StreamReader sr, DailyNoteEntity item)
        {
            item.Date = Convert.ToDateTime(sr.ReadLine());
            item.ID =int.Parse(sr.ReadLine());
            item.Description = sr.ReadLine();
        }
        protected override void WriteEntity(StreamWriter sw, DailyNoteEntity item)
        {
            sw.WriteLine(item.Date);
            sw.WriteLine(item.ID);
            sw.WriteLine(item.Description);
        }
    }
}

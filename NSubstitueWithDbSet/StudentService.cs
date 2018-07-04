using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSubstitueWithDbSet
{
    public class StudentService
    {
        public DevEntities db;

        public StudentService(DevEntities db)
        {
            this.db = db;
        }

        public void GetStuden()
        {
            var tmp = db.Student.Where(x => true);
            return;
        }
    }
}

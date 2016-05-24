using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PjBaySite.Models
{
    public class Field
    {
        public int ID { get; set; }
        public string fieldName { get; set; }

        public List<Course> Courses { get; set; }

    }
}

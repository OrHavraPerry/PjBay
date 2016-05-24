using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PjBaySite.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int FieldID { get; set; }
        public Field Field { get; set; }
        public int InstatuteID { get; set; }
        public Instatute Instatute { get; set; }
        public List<Project> Projects { get; set; }
    }
}

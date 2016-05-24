using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PjBaySite.Models
{
    public class Institute : IBoxItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Course> Courses { get; set; }
        [NotMapped]
        public string Description
        {
            get
            {
                return "";
            }
        }
        [NotMapped]
        public IEnumerable<IBoxItem> Childs
        {
            get
            {
                return null;
                //Courses.Cast<IBoxItem>();
            }
        }
    }
}

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
        [Required]
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required(ErrorMessage ="Please enter institute name")]
        [StringLength(100,ErrorMessage ="Please enter a name that smaller than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter adress")]
        [StringLength(200, ErrorMessage = "Please enter an adress that smaller than 200 characters")]
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PjBaySite.Models
{
    public class Field
    {
        [Required]
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Display(Name = "Field Name")]
        [Required(ErrorMessage = "Please enter field name")]
        [StringLength(100, ErrorMessage = "Please enter an field name which is smaller than 100 characters")]
        public string fieldName { get; set; }

        public List<Course> Courses { get; set; }

    }
}

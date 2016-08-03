using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PjBaySite.Models
{
    public class Course
    {
        [Required]
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "plz enter a name between 1-100")]
        public string Name { get; set; }
        public int FieldID { get; set; }
        public Field Field { get; set; }
        public int InstatuteID { get; set; }
        public Institute Instatute { get; set; }
        public List<Project> Projects { get; set; }

        [NotMapped]
        public string Description { get; set; }


    }
}

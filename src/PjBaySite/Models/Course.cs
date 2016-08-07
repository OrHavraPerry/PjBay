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
        public string Name { get; set; }
        public int FieldID { get; set; }
        public Field Field { get; set; }
        public int InstatuteID { get; set; }
        public Institute Instatute { get; set; }
        public List<Project> Projects { get; set; }

    }
}

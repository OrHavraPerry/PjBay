using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PjBaySite.Models
{
    public class Project : IBoxItem
    {
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage ="Please enter roject name")]
        [StringLength(50,ErrorMessage ="please enter name that smaller than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter project grade")]
        [Range(0, 100,ErrorMessage = "Grade must be between 0 and 100")]
        public int Grade { get; set; }

        [Required(ErrorMessage = "Please enter project price")]
        [Range(0.00, 10000.00, ErrorMessage = "Grade must be between 0.00 and 10000.00")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter project description")]
        [StringLength(500, ErrorMessage = "please enter desciption that smaller than 500 characters")]
        public string Description { get; set; }

        public string Picture { get; set; }
        public string Video { get; set; }

        [Required]
        [ScaffoldColumn(false)]
        public bool Purchased { get; set; }

        [Display(Name="Submit date")]
        [ScaffoldColumn(false)]
        public DateTime? SubmitDate { get; set; }


        public int CourseID { get; set; }

        public Course Course { get; set; }
        [NotMapped]
        public IEnumerable<IBoxItem> Childs
        {
            get
            {
                return new List<IBoxItem>();
            }
        }
    }
}

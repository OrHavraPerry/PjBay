using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PjBaySite.Models
{
    public class Project : IBoxItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string Video { get; set; }
        public bool Purchased { get; set; }
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

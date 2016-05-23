using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PjBaySite.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string Video { get; set; }
        public bool Purchased { get; set; }
        public DateTime? SubmiteDate { get; set; }
        public int CourseID { get; set; }
        public Course Course { get; set; }
    }
}

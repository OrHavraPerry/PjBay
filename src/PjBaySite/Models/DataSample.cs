using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PjBaySite.Models
{
    public class DataSample
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            ApplicationDbContext context = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));
            if (!context.Instatutes.Any())
            {
                var ins = new List<Instatute>()
                {
                    new Instatute()
                    {
                        Name="Colman",
                        Address="Rishon Le Zion",
                        Courses=new List<Course>()
                        {
                            //TODO: Continue
                        }
                        
                    }
                };
            }
        }
    }
}

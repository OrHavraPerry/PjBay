using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PjBaySite.Models
{
    public class DataSample
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            
            ApplicationDbContext context = (ApplicationDbContext)serviceProvider.GetService(typeof(ApplicationDbContext));

            if (!context.Institutes.Any())
            {
                var Fields = new List<Field>()
                {
                    new Field()
                    {
                        fieldName="Computer Science"
                    },
                    new Field()
                    {
                        fieldName="Psycology"
                    },
                    new Field()
                    {
                        fieldName="Geography"
                    },
                    new Field()
                    {
                        fieldName="electrical engineering"
                    }
                };

                var ins = new List<Institute>()
                {
                    new Institute()
                    {
                        Name="Colman",
                        Address="Rishon Le Zion",
                        Courses=new List<Course>()
                        {
                            new Course()
                            {
                                Name="Introduction to Big Data",
                                Field=Fields[1],
                                Projects=new List<Project>()
                                {
                                    new Project()
                                    { 
                                        Name="analyzing website logs",
                                        Grade=85,
                                        Price=350,
                                        Description="Answering questions about big sales data and analyzing large website logs",
                                        Picture="https://lh5.ggpht.com/JJc55ckwLOPH2koySqtvwd8Hc4vzFodhg-x5JxcvFKth-dKW_iD8zy9Ax2W8oPvyR6iOYoeVPRvclIhVmdE=s0#w=1725&h=1060",
                                        Video="https://youtu.be/44K_bzTL_SM",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("07/3/2016 19:45"),

                                    },
                                    new Project()
                                    {
                                        Name="Web Development",
                                        Grade=90,
                                        Price=250,
                                        Description="Try to picture yourself sitting down with your computer, ready to start developing a fully functional web application for the first time, available online for millions to use. “Where should I even begin? How long is this going to take me? Am I making any mistakes along the way?” The questions may leave you with an uneasy feeling that you will learn many lessons the hard way.",
                                        Picture="https://lh5.ggpht.com/JJc55ckwLOPH2koySqtvwd8Hc4vzFodhg-x5JxcvFKth-dKW_iD8zy9Ax2W8oPvyR6iOYoeVPRvclIhVmdE=s0#w=1725&h=1060",
                                        Video="https://youtu.be/4z37fUbpJ3s",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("11/10/2016 13:45"),

                                    }
                                }
                            }
                        }
                        
                    },
                    new Institute()
                    {
                        Name ="Tel Aviv University",
                        Address="Tel Aviv Jaffa",
                        Courses=new List<Course>()
                        {
                            new Course()
                            {
                                Name="Introduction to C",
                                Field=Fields[0],
                                Projects=new List<Project>()
                                {
                                    new Project()
                                    {
                                        Name="Black Jeck",
                                        Grade=95,
                                        Price=230,
                                        Description="Building black jack with pointers",
                                        Picture="https://lh5.ggpht.com/JJc55ckwLOPH2koySqtvwd8Hc4vzFodhg-x5JxcvFKth-dKW_iD8zy9Ax2W8oPvyR6iOYoeVPRvclIhVmdE=s0#w=1725&h=1060",
                                        Video="https://youtu.be/44K_bzTL_SM",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("05/11/2016 19:45"),

                                    },
                                    new Project()
                                    {
                                        Name="8 horses game chess",
                                        Grade=98,
                                        Price=230,
                                        Description="allocating 8 horses in a chess board,that they can't eat each other,using recursion",
                                        Picture="https://lh5.ggpht.com/JJc55ckwLOPH2koySqtvwd8Hc4vzFodhg-x5JxcvFKth-dKW_iD8zy9Ax2W8oPvyR6iOYoeVPRvclIhVmdE=s0#w=1725&h=1060",
                                        Video="https://youtu.be/4z37fUbpJ3s",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("08/12/2015 13:45"),

                                    }
                                }
                            }
                        }

                    },
                    new Institute()
                    {
                        Name ="Technion",
                        Address="Haifa",
                        Courses=new List<Course>()
                        {
                            new Course()
                            {
                                Name="introduction to soul",
                                Field=Fields[1],
                                Projects=new List<Project>()
                                {
                                    new Project()
                                    {
                                        Name="sum on paper number 1",
                                        Grade=95,
                                        Price=450,
                                        Description="tring to understand the human soul",
                                        Picture="https://lh5.ggpht.com/JJc55ckwLOPH2koySqtvwd8Hc4vzFodhg-x5JxcvFKth-dKW_iD8zy9Ax2W8oPvyR6iOYoeVPRvclIhVmdE=s0#w=1725&h=1060",
                                        Video="https://youtu.be/44K_bzTL_SM",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("14/2/2011 19:43"),

                                    }
                                }
                            },
                            new Course()
                            {
                                Name="The oceans",
                                Field=Fields[2],
                                Projects=new List<Project>()
                                {
                                    new Project()
                                    {
                                        Name="The atlantic ocean winds",
                                        Grade=95,
                                        Price=130,
                                        Description="very intreating",
                                        Picture="https://lh5.ggpht.com/JJc55ckwLOPH2koySqtvwd8Hc4vzFodhg-x5JxcvFKth-dKW_iD8zy9Ax2W8oPvyR6iOYoeVPRvclIhVmdE=s0#w=1725&h=1060",
                                        Video="https://youtu.be/44K_bzTL_SM",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("12/5/2014 19:43"),

                                    }
                                }
                            },
                            new Course()
                            {
                                Name="Mechanics",
                                Field=Fields[0],
                                Projects=new List<Project>()
                                {
                                    new Project()
                                    {
                                        Name="Energy",
                                        Grade=95,
                                        Price=130,
                                        Description="very intreating",
                                        Picture="https://lh5.ggpht.com/JJc55ckwLOPH2koySqtvwd8Hc4vzFodhg-x5JxcvFKth-dKW_iD8zy9Ax2W8oPvyR6iOYoeVPRvclIhVmdE=s0#w=1725&h=1060",
                                        Video="https://youtu.be/44K_bzTL_SM",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("22/10/2014 19:43"),

                                    }
                                }
                            }
                        }
                    }
                };

                

                context.Fields.AddRange(Fields);
                context.Institutes.AddRange(ins);

                context.SaveChanges();
            }

            UserManager<ApplicationUser> userManager = (UserManager<ApplicationUser>)serviceProvider.GetService(typeof(UserManager<ApplicationUser>));
            RoleManager<IdentityRole> roleManager = (RoleManager<IdentityRole>)serviceProvider.GetService(typeof(RoleManager<IdentityRole>));

            string adminRole = "Admin";
            string AdminName = "Admin@PjBay.com";
            string AdminPass = "1234";

            if (!roleManager.Roles.Any(t=>t.Name== adminRole))
            {
                var res = roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            if (!userManager.Users.Any(u=>u.UserName == AdminName))
            {
                var user = new ApplicationUser { UserName = AdminName, Email = AdminName };
                var task = userManager.CreateAsync(user, AdminPass);

                if (task.Result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, adminRole);
                }
            }
        }
    }
}

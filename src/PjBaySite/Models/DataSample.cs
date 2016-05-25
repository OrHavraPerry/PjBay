﻿using System;
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
                        fieldName="Harta"
                    },
                    new Field()
                    {
                        fieldName="Weed"
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
                                        SubmitDate=DateTime.Parse("07/23/2016 19:45"),

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
                                        SubmitDate=DateTime.Parse("11/13/2016 13:45"),

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
                                Field=Fields[2],
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
                                        SubmitDate=DateTime.Parse("05/13/2016 19:45"),

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

                    }
                };

                context.Fields.AddRange(Fields);
                context.Institutes.AddRange(ins);

                context.SaveChanges();
            }
        }
    }
}

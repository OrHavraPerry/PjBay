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
                        fieldName="Electrical Engineering"
                    },
                    new Field()
                    {
                        fieldName="Economics"
                    },
                    new Field()
                    {
                        fieldName="Law"
                    },
                    new Field()
                    {
                        fieldName="Media"
                    },
                    new Field()
                    {
                        fieldName="Architeture"
                    },
                    new Field()
                    {
                        fieldName="Education"
                    }
                };

                var ins = new List<Institute>()
                {
                    new Institute()
                    {
                        Name="College of Management",
                        Address="Rishon Le Zion",
                        Courses=new List<Course>()
                        {
                            new Course()
                            {
                                Name="Big Data",
                                Field=Fields[0],
                                Projects=new List<Project>()
                                {
                                    new Project()
                                    { 
                                        Name="Map Reduce",
                                        Grade=35,
                                        Price=350,
                                        Description="Drive better business decisions with an overview of how big data is organized, analyzed, and interpreted. Apply your insights to real-world problems and questions.",
                                        Picture="http://blog.sqlauthority.com/i/b/mapreduce.jpg",
                                        Video="https://www.youtube.com/embed/bcjSe0xCHbE",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("2011-03-21 13:26"),

                                    },
                                    new Project()
                                    {
                                        Name="Machine Learning",
                                        Grade=45,
                                        Price=250,
                                        Description="Interested in increasing your knowledge of the Big Data landscape?  This course is for those new to data science and interested in understanding why the Big Data Era has come to be.",
                                        Picture="https://d3njjcbhbojbot.cloudfront.net/api/utilities/v1/imageproxy/https://coursera.s3.amazonaws.com/topics/ml/large-icon.png",
                                        Video="https://www.youtube.com/embed/WXHM_i-fgGo",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("2016-07-12 14:35"),

                                    }
                                }
                            },
                            new Course()
                            {
                                Name="Social Media Marketing Specialization",
                                Field=Fields[6],
                                Projects=new List<Project>()
                                {
                                    new Project()
                                    {
                                        Name="Media and us",
                                        Grade=55,
                                        Price=350,
                                        Description="In today’s marketplace, organizations need effective, profitable social marketing strategies. In this Specialization, you’ll learn to match markets to social strategies to profitably grow your business. ",
                                        Picture="http://www.ereachconsulting.com/wp-content/uploads/2012/12/Social-Media-Management.png",
                                        Video="https://www.youtube.com/embed/f6LKl4RKIew",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("2014-11-14 18:13"),

                                    }
                                }
                            },
                            new Course()
                            {
                                Name="Early Renaissance Architecture in Italy: from Alberti to Bramante",
                                Field=Fields[7],
                                Projects=new List<Project>()
                                {
                                    new Project()
                                    {
                                        Name="Milan",
                                        Grade=10,
                                        Price=130,
                                        Description="The course will examine problems of the architectural spaces, technology and forms looking to the antiquity in the XV century in Italy.",
                                        Picture="https://media-cdn.tripadvisor.com/media/photo-s/06/9f/d0/38/the-duomo-s-structure.jpg",
                                        Video="https://www.youtube.com/embed/UlelEbPxCLg",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("2015-07-29 22:13"),

                                    }
                                }
                            },
                            new Course()
                            {
                                Name="Roman Art and Archaeology",
                                Field=Fields[7],
                                Projects=new List<Project>()
                                {
                                    new Project()
                                    {
                                        Name="Build a Church",
                                        Grade=65,
                                        Price=130,
                                        Description="The objective of this course is to provide an overview of the culture of ancient Rome beginning about 1000 BCE and ending with the so-called :Fall of Rome.",
                                        Picture="https://i.ytimg.com/vi/76J_wv7bCtk/maxresdefault.jpg",
                                        Video="https://www.youtube.com/embed/76J_wv7bCtk",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("2016-06-24 09:23"),

                                    }
                                }
                            },
                            new Course()
                            {
                                Name="Business Tools for Successful Execution",
                                Field=Fields[4],
                                Projects=new List<Project>()
                                {
                                    new Project()
                                    {
                                        Name="Tool 1",
                                        Grade=67,
                                        Price=130,
                                        Description="In order to effectively manage and operate a business, managers and leaders need to understand the market characteristics and economic environment they operate in. In this Specialization, you will build a solid understanding of the operation of markets and the macro-economic environment with real-world examples.",
                                        Picture="http://image.shutterstock.com/z/stock-vector-successful-business-steps-idea-planning-execution-concept-vector-illustration-194322317.jpg",
                                        Video="https://www.youtube.com/embed/CfhudBQ3VwA",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("2011-10-18 17:26"),

                                    }
                                }
                            }
                        }


                        
                    },
                    new Institute()
                    {
                        Name ="The Hebrew University",
                        Address="Jerusalem",
                        Courses=new List<Course>()
                        {
                            new Course()
                            {
                                Name="Introduction to the Arctic: Climate",
                                Field=Fields[2],
                                Projects=new List<Project>()
                                {
                                    new Project()
                                    {
                                        Name="climate changing discussion",
                                        Grade=75,
                                        Price=360,
                                        Description="The University of Alberta, the University of Tromso and the University of the Arctic invite you to explore this four week course that examines the environment and climate of the circumpolar North.",
                                        Picture="https://uofa.ualberta.ca/-/media/ualberta/courses/arctic/changing-arctic-mooc-video.png",
                                        Video="https://www.youtube.com/embed/WmbBWdW1naY",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("2010-06-01 16:13"),
                                    },
                                    new Project()
                                    {
                                        Name="Water in the Western United States",
                                        Grade=74,
                                        Price=360,
                                        Description="This course combines an overview of the science behind water and climate in the Western United States with a survey of the major legal, political, and cultural issues focused on this precious resource.",
                                        Picture="http://www.thesolutionsjournal.com/sites/default/files/imagecache/headline-image/headline/Per_Sabo_Figure1.jpg",
                                        Video="https://www.youtube.com/embed/psOL3EEUlNs",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("2015-11-25 10:14"),
                                    }
                                }
                            },
                            new Course()
                            {
                                Name="Social Psychology",
                                Field=Fields[1],
                                Projects=new List<Project>()
                                {
                                    new Project()
                                    {
                                        Name="Paper on how i changed a person",
                                        Grade=81,
                                        Price=360,
                                        Description="Ever wonder why people do what they do? This course offers some answers based on the latest research from social psychology.",
                                        Picture="http://collegefun-d.com/wp-content/uploads/2014/07/MarketPsychology.jpg",
                                        Video="https://d1a2y8pfnfh44t.cloudfront.net/rTORfM5Yhw8/full/540p/index.mp4",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("2011-03-21 13:26"),
                                    },
                                    new Project()
                                    {
                                        Name="The Brain and Space",
                                        Grade=87,
                                        Price=360,
                                        Description="This course is about how the brain creates our sense of spatial location from a variety of sensory and motor sources, and how this spatial sense in turn shapes our cognitive abilities.",
                                        Picture="https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSaX0WwiXodllxeNvP-8x6CO_2DbAneTvQF0E2MWD_mhLFrpavT",
                                        Video="https://www.youtube.com/embed/n6phmqNxogw",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("2015-06-23 13:19"),
                                    }
                                }
                            }

                        }
                    },
                    new Institute()
                    {
                        Name ="Ono Academic college",
                        Address="Kiryat Ono",
                        Courses=new List<Course>()
                        {
                            new Course()
                            {
                                Name="A Law Student's Toolkit",
                                Field=Fields[5],
                                Projects=new List<Project>()
                                {
                                    new Project()
                                    {
                                        Name="Law in Israel",
                                        Grade=95,
                                        Price=360,
                                        Description=" Whether you are an advanced law student looking to review the basics, or an aspiring law student looking for head start, this course will help you build the foundation you will need to succeed in law school and beyond. ",
                                        Picture="http://kklawus.com/en/uploads/151219/4-15121Z53403B4.jpg",
                                        Video="https://www.youtube.com/embed/6Hoj3lvNwLk",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("2011-08-30 21:24"),
                                    }
                                }
                            },
                            new Course()
                            {
                                Name="Evolution: A Course for Educators",
                                Field=Fields[8],
                                Projects=new List<Project>()
                                {
                                    new Project()
                                    {
                                        Name="Education in kindergarden",
                                        Grade=93,
                                        Price=360,
                                        Description="How are all of the species living on Earth today related? How does understanding evolutionary science contribute to our well-being? In this course, participants will learn about evolutionary relationships, population genetics, and natural and artificial selection. Participants will explore evolutionary science and learn how to integrate it into their classrooms.",
                                        Picture="http://www.news-track.com/wp-content/uploads/2015/06/Evolution-des-wissens.jpg",
                                        Video="https://www.youtube.com/embed/BcpB_986wyk",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("2011-07-15 23:13"),
                                    },
                                    new Project()
                                    {
                                        Name="Critical Issues in Urban Education",
                                        Grade=95,
                                        Price=360,
                                        Description="This course explores a set of critical issues in the education and educational reform space, with a focus on aspects of the field that have sparked controversy and polarized views. ",
                                        Picture="https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcS2cBuu9PAIkvs3dGKGjlfg07gDD1ZYk1RLkjnh6XNIQkoG-hR-",
                                        Video="https://www.youtube.com/embed/S91SaRDZUwI?list=PLAXSVuGaw0KwhhJQr9Je2SKMcS8Wan7Cw",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("2011-07-05 14:27"),
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
                                        Grade=92,
                                        Price=230,
                                        Description="Building black jack with pointers",
                                        Picture="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRzOQdnbHtg36Uo812HUKiOr8niqWodrDJtg3f-QAsWGJ9JnGJi",
                                        Video="https://www.youtube.com/embed/4_9woj77UMQ",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("2015-09-27 13:12"),

                                    },
                                    new Project()
                                    {
                                        Name="8 horses game chess",
                                        Grade=91,
                                        Price=230,
                                        Description="allocating 8 horses in a chess board,that they can't eat each other,using recursion",
                                        Picture="https://chess-teacher.com/wp-content/uploads/2016/01/chess-8.jpg",
                                        Video="https://www.youtube.com/embed/rk2fK2IIiiQ",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("2011-09-21 13:23"),

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
                                        Picture="https://marktaylorpsychology.files.wordpress.com/2014/04/psychology.jpg",
                                        Video="https://www.youtube.com/embed/vo4pMVb0R6M",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("2012-12-23 00:23"),

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
                                        Picture="http://meche.mit.edu/sites/default/files/styles/hero/public/slides/Research%20Oceans.jpg?itok=okSrE16D",
                                        Video="https://www.youtube.com/embed/J2BKd5e15Jc",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("2011-07-27 23:24"),

                                    }
                                }
                            },
                            new Course()
                            {
                                Name="Introduction to Engineering Mechanics",
                                Field=Fields[3],
                                Projects=new List<Project>()
                                {
                                    new Project()
                                    {
                                        Name="Energy",
                                        Grade=95,
                                        Price=130,
                                        Description="very intreating",
                                        Picture="http://www.easypars.com/wp-content/uploads/2012/05/mechanics-in-golf-swing.jpg",
                                        Video="https://www.youtube.com/embed/ApUFtLCrU90",
                                        Purchased=false,
                                        SubmitDate=DateTime.Parse("2016-11-11 11:11"),

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

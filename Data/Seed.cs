using ModelTrainWebApp.Data.Enum;
using ModelTrainWebApp.Models;

namespace ModelTrainWebApp.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Clubs.Any())
                {
                    context.Clubs.AddRange(new List<Club>()
                    {
                        new Club()
                        {
                            Title = "Kentuckiana Society of N-Scalers",
                            Image = "http://res.cloudinary.com/daqljyteo/image/upload/v1656802984/qzspwgo4g06mnsnxpihl.jpg",
                            Description = "The Kentuckiana Society of N Scalers (KSONS) are dedicated to the advancement and enjoyment of N scale model railroading in Louisville, Southern Indiana, and the surrounding area. We have several home layouts and will often meet to run trains. Our current emphasis is building and developing Free-moN modules.",
                            Email = "KSONSmrc@gmail.com",
                            Website = "https://sites.google.com/view/ksonsmrc/home",
                            ClubCategory = ClubCategory.FreeMoN,
                            Address = new Address()
                            {
                                Street = "600 N Hurstboune Pkwy",
                                City = "Louisville",
                                State = "KY"
                            }
                         },
                        new Club()
                        {
                            Title = "NMRA Division 8",
                            Image = "http://res.cloudinary.com/daqljyteo/image/upload/v1656627009/aqnojh8pinn5hiezt1z3.png",
                            Description = "Division 8 is a division of the Mid-Central Region of the National Model Railroad Association (NMRA). It is designed to be local chapter of the NMRA for Central Kentucky and Southern Indiana. The purpose of Division 8 is to promote the hobby of model railroading through education of the public, to promote fellowship among the members, to develop technical skills of those involved in the hobby, to educate members engaged in model railroading in methods of building and operating model railroad equipment and of prototype practices, and to advance the hobby wherever and whenever possible by publications, meetings, events, and all things necessary.",
                            Email = "division8.mcr.nmra@gmail.com",
                            Website = "http://div8-mcr-nmra.org/",
                            ClubCategory = ClubCategory.Organization,
                            Address = new Address()
                            {
                                Street = "600 N Hurstboune Pkwy",
                                City = "Louisville",
                                State = "KY"
                            }
                        },
                        new Club()
                        {
                            Title = "K&I Model Railroad Club",
                            Image = "http://res.cloudinary.com/daqljyteo/image/upload/v1656802911/wy4wrpgysbk6bunvnogg.jpg",
                            Description = "The K & I Model Railroad Club is a diverse group of modelers and railroad enthusiasts whose purpose is to foster their creative interests in the model railroading hobby in a family-friendly environment. Model railroading is FUN, and membership in our club is a great way to share the fun with others. Additionally, we share our hobby by opening our club to the public on a scheduled basis throughout the year and by displaying our traveling layout at public venues in Louisville and the surrounding area.",
                            Email = "kandimodelrailroadclub@gmail.com",
                            Website = "http://www.kandimrr.com/",
                            ClubCategory = ClubCategory.Modular,
                            Address = new Address()
                            {
                                Street = "2621 S 4th Street",
                                City = "Louisville",
                                State = "KY"
                            }
                        },
                        new Club()
                        {
                            Title = "Southern Indiana Railroad Club",
                            Image = "http://res.cloudinary.com/daqljyteo/image/upload/v1656799888/fcsfocsw7aiwjs8velzl.jpg",
                            Description = "The Southern Indiana Railroad is a club made up of a small group of men who are interested in promoting the hobby of model railroading. We have a layout in the basement of the First Presbyterian Church at the corner of Chestnut and Walnut streets in downtown Jeffersonville, Indiana.  We model primarily in HO scale, but our members have interests in other scales as well. ",
                            Email = "SouthernIndianaRR@gmail.com",
                            Website = "http://www.southernindianarailroad.com/home.html",
                            ClubCategory = ClubCategory.Modular,
                            Address = new Address()
                            {
                                Street = "222 Walnut Street",
                                City = "Jeffersonville",
                                State = "IN"
                            }
                        }
                    });
                    context.SaveChanges();
                }
                //Meets
                if (!context.Meetups.Any())
                {
                    context.Meetups.AddRange(new List<Meetup>()
                    {
                        new Meetup()
                        {
                            Title = "Southern Indiana Railroad - Work Session",
                            Image = "http://res.cloudinary.com/daqljyteo/image/upload/v1656802852/ycwrj4zonlpqsash7kel.jpg",
                            Description = "Work session when we work on the layout or run trains.",
                            MeetupCategory = MeetupCategory.Work_Session,
                            StartTime = new DateTime(2022, 8, 18, 18, 30, 00),
                            Email = "cbroughton67@gmail.com",
                            Address = new Address()
                            {
                                Street = "222 Walnut Street",
                                City = "Jeffersonville",
                                State = "IN"
                            }
                        },
                        new Meetup()
                        {
                            Title = "Division 8 Business Meeting",
                            Image = "http://res.cloudinary.com/daqljyteo/image/upload/v1656802822/mgc9ctobiq1zacdtmi0t.png",
                            Description = "Monthly Business Meeting",
                            MeetupCategory = MeetupCategory.Business_Meeting,
                            StartTime = new DateTime(2022, 8, 18, 14, 00, 00),
                            Email = "division8.mcr.nmra@gmail.com",
                            Address = new Address()
                            {
                                Street = "600 N Hurstboune Pkwy",
                                City = "Louisville",
                                State = "KY"
                            }
                        },
                        new Meetup()
                        {
                            Title = "Division 8 Show & Sale",
                            Image = "http://res.cloudinary.com/daqljyteo/image/upload/v1656802777/s2o81fkebpxhisie7hed.jpg",
                            Description = "Model Trains in All Scales, Operating Layouts and Displays, Retail Sales - Over 100 Dealer Tables",
                            MeetupCategory = MeetupCategory.Show,
                            StartTime = new DateTime(2022, 11, 12, 10, 00, 00),
                            Email = "division8.mcr.nmra@gmail.com",
                            Address = new Address()
                            {
                                Street = "3938 Poplar Level Rd",
                                City = "Louisville",
                                State = "KY"
                            }
                        },
                        new Meetup()
                        {
                            Title = "Great American Train Show",
                            Image = "http://res.cloudinary.com/daqljyteo/image/upload/v1656802724/dlszs1xhyyty2e8rxetp.png",
                            Description = "Our train shows are designed for the general public, modelers, hobbyists, families, and the just plain curious. Each show features hundreds of tables of trains and accessories for sale, huge operating exhibits, activities for kids, and more. All scales are welcome as are books, videos, and railroadiana. Don’t miss your chance to be a part of the best train shows in America. ",
                            MeetupCategory = MeetupCategory.Show,
                            StartTime = new DateTime(2022, 12, 11, 10, 00, 00),
                            Email = "Dillon@Trainshow.email",
                            Address = new Address()
                            {
                                Street = "Kentucky Expo Center",
                                City = "Louisville",
                                State = "KY"
                            }
                        }

                    });
                    context.SaveChanges();
                }
            }
        }

    }
}

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
                            Title = "Train Club 1",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the 1st club",
                            Email = "cbroughton67@gmail.com",
                            ClubCategory = ClubCategory.Permanent,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Louisville",
                                State = "KY"
                            }
                         },
                        new Club()
                        {
                            Title = "Train Club 2",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the 2nd club",
                            Email = "cbroughton67@gmail.com",
                            ClubCategory = ClubCategory.Modular,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Louisville",
                                State = "KY"
                            }
                        },
                        new Club()
                        {
                            Title = "Train Club 3",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the 3rd club",
                            Email = "cbroughton67@gmail.com",
                            ClubCategory = ClubCategory.Organization,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Louisville",
                                State = "KY"
                            }
                        },
                        new Club()
                        {
                            Title = "Train Club 4",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the 4th club",
                            Email = "cbroughton67@gmail.com",
                            ClubCategory = ClubCategory.Show,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Louisville",
                                State = "KY"
                            }
                        }
                    });
                    context.SaveChanges();
                }
                //Meets
                if (!context.Meets.Any())
                {
                    context.Meets.AddRange(new List<Meet>()
                    {
                        new Meet()
                        {
                            Title = "Train Show 1",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first show",
                            MeetCategory = MeetCategory.Show,
                            Email = "cbroughton67@gmail.com",
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Louisville",
                                State = "KY"
                            }
                        },
                        new Meet()
                        {
                            Title = "Business Meeting",
                            Image = "https://www.eatthis.com/wp-content/uploads/sites/4/2020/05/running.jpg?quality=82&strip=1&resize=640%2C360",
                            Description = "This is the description of the first race",
                            MeetCategory = MeetCategory.Business_Meeting,
                            Email = "cbroughton67@gmail.com",
                            AddressId = 5,
                            Address = new Address()
                            {
                                Street = "123 Main St",
                                City = "Louisville",
                                State = "KY"
                            }
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        //Roles
        //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //        if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //        //Users
        //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        //        string adminUserEmail = "teddysmithdeveloper@gmail.com";

        //        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        //        if (adminUser == null)
        //        {
        //            var newAdminUser = new AppUser()
        //            {
        //                UserName = "teddysmithdev",
        //                Email = adminUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "123 Main St",
        //                    City = "Charlotte",
        //                    State = "NC"
        //                }
        //            };
        //            await userManager.CreateAsync(newAdminUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
        //        }

        //        string appUserEmail = "user@etickets.com";

        //        var appUser = await userManager.FindByEmailAsync(appUserEmail);
        //        if (appUser == null)
        //        {
        //            var newAppUser = new AppUser()
        //            {
        //                UserName = "app-user",
        //                Email = appUserEmail,
        //                EmailConfirmed = true,
        //                Address = new Address()
        //                {
        //                    Street = "123 Main St",
        //                    City = "Charlotte",
        //                    State = "NC"
        //                }
        //            };
        //            await userManager.CreateAsync(newAppUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        //        }
        //    }
        //}
    }
}

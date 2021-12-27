using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;


namespace Infrastructure.Identity
{
    public class IdentityDbSeed
    {
        public static async Task SeedUDerAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Bob",
                    Email = "bob@gamil.com",
                    Address = new Address
                    {
                        FirstName = "Bob",
                        LastName = "Marly",
                        Street = "Ida Ognidif",
                        City = "New Tarrast",
                        State = "NT",
                        ZipCode = "80000"
                    }
                };
                await userManager.CreateAsync(user, "P@ssw0rd22");
            }
        }
    }
}
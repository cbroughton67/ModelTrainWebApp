using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelTrainWebApp.Models
{
    // In Package Manager Console, create the migration by running the command:
    //          Add-Migration InitialCreate
    //
    // Create the database by running the command:
    //          Update-Database 
    //
    // Seed data from Developer PowerShell, and run the command:
    //          dotnet run seeddata
    //
    // Update migration by running the command:
    //          Add-Migration [migration update name]
    //

    public class AppUser
    {
        [Key]
        public int Id { get; set; }
        public string? Scale { get; set; }
        public string? Layout { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address? Address { get; set; }
        public ICollection<Club> Clubs { get; set; }
        public ICollection<Meetup> Meetups { get; set; }
    }
}

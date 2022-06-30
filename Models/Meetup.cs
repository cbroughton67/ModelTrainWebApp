using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ModelTrainWebApp.Data.Enum;

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

    public class Meetup
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public string? URL { get; set; }
        public DateTime? StartTime { get; set; }
        public string? Website { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public MeetupCategory MeetupCategory { get; set; }
        [ForeignKey("AppUser")]
        public int? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}

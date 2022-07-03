using ModelTrainWebApp.Data.Enum;
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


    public class Club
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        [ForeignKey("Address")]
        public int AddressID { get; set; }
        public Address? Address { get; set; }
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string? Email { get; set; }
        public string? Website { get; set; }
        public ClubCategory ClubCategory { get; set; }
    }
}

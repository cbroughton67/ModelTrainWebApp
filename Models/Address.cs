using System.ComponentModel.DataAnnotations;

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

    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }

    }
}

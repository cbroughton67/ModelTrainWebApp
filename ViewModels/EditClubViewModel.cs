using ModelTrainWebApp.Data.Enum;
using ModelTrainWebApp.Models;

namespace ModelTrainWebApp.ViewModels
{
    public class EditClubViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Website { get; set; }
        public String? Email { get; set; }
        public ClubCategory ClubCategory { get; set; }
        //public string? URL { get; set; }
        public int AddressID { get; set; }
        public Address? Address { get; set; }
        public string? URL { get; set; }
        public IFormFile? Image { get; set; }
    }
}

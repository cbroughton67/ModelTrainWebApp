using ModelTrainWebApp.Data.Enum;
using ModelTrainWebApp.Models;

namespace ModelTrainWebApp.ViewModels
{
    public class EditMeetupViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public string? URL { get; set; }
        public DateTime? StartTime { get; set; }
        public string? Website { get; set; }
        public string? Contact { get; set; }
        public String Email { get; set; }
        public int AddressID { get; set; }
        public Address Address { get; set; }
        public MeetupCategory MeetupCategory { get; set; }

    }
}

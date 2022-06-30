using ModelTrainWebApp.Data.Enum;
using ModelTrainWebApp.Models;

namespace ModelTrainWebApp.ViewModels
{
    public class CreateMeetupViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public DateTime? StartTime { get; set; }
        public Address Address { get; set; }
        public IFormFile Image { get; set; }
        public MeetupCategory MeetupCategory { get; set; }

    }

}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelTrainWebApp.Models
{
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
        public ICollection<Meet> Meets { get; set; }
    }
}

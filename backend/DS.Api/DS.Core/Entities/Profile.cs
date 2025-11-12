
namespace DS.Core.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public int UserId { get; set; } //FK
        public string FullName { get; set; } = null!;
        public string Bio { get;set; } = null!;
        public string ProfilePicUrl { get; set; } = null!;
        public DateTime JoinedDate { get; set; }

    }
}

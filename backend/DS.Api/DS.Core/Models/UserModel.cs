namespace DS.Core.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; } = String.Empty;
        public string UserEmail { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
    }
}

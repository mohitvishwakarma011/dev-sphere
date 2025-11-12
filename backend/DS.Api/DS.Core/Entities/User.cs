namespace DS.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = null!;
        public List<Post> Posts { get; set; } = new List<Post>();
        public Profile Profile { get; set; } = null!;
    }
}

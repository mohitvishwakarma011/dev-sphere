using DS.Core.Utilities;

namespace DS.Core.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; } = String.Empty;
        public string UserEmail { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public Constants.RecordStatus Status { get; set; }
    }
}

using DS.Core.Utilities;

namespace DS.Core.Dto.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserName { get; set; } = String.Empty;
        public string UserEmail { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
        public Constants.RecordStatus Status { get; set; }
    }
}

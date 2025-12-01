namespace DS.Core.Dto.Comment
{
    public class UpsertCommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int PostId { get; set; }
    }
}

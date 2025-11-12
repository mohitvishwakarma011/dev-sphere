namespace DS.Core.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get;set ; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int ViewsCount { get; set; }
    }
}
    
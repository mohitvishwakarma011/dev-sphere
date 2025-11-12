namespace DS.Core.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get;set ; }
        public int AuthorId { get; set; } //this is the userId FK
        public int CategoryId { get; set; }// FK for Category
        public int ViewsCount { get; set; }
        public User User { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<PostTag> PostTags { get; set; } = new List<PostTag>();
    }
}
    
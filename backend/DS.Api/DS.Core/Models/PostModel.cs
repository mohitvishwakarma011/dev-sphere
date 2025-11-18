namespace DS.Core.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Content { get; set; } = String.Empty;
        public int CategoryId { get ; set; }
        public int SubCategoryId { get; set; }
        public int AuthorId { get ; set; }
    }
}
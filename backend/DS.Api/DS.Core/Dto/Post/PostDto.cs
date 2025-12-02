using DS.Core.Dto.Category;
using DS.Core.Dto.Comment;
using DS.Core.Dto.SubCategory;
using DS.Core.Dto.Tag;

namespace DS.Core.Dto.Post
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public int ViewsCount { get; set; }
        public int Likes { get; set; }
        public bool Liked { get; set; }

        public UserDto User { get; set; } = new UserDto();
        public CategoryDto Category { get; set; } = new CategoryDto();
        public SubCategoryDto SubCategory { get; set; } = new SubCategoryDto();
        public List<TagDto> Tags { get; set; } = new List<TagDto>();
        public List<CommentDto> Comments { get; set;} = new List<CommentDto>();
    }
}

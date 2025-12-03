namespace DS.Core.Models.FilterModel
{
    public class CommentFilterModel : FilterModel
    {
        public int PostId { get; set; } 

        public CommentFilterModel()
        {
            this.Sort = "CreatedAt";
            this.Order = "asc";
        }
    }
}

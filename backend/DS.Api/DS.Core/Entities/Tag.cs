namespace DS.Core.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<PostTag> PostTags { get; set; } = new List<PostTag>();
    }
}

using DS.Core.Utilities;

namespace DS.Core.Entities
{
    public class Subcategory
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Constants.RecordStatus Status {  get; set; }
        public Category Category { get; set; } = null!;
    }
}

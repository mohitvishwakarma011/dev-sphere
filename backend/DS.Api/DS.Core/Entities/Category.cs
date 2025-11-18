
using DS.Core.Utilities;

namespace DS.Core.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Constants.RecordStatus Status { get; set; }
        public List<Subcategory> Subcategories { get; set; } = new List<Subcategory>();
    }
}

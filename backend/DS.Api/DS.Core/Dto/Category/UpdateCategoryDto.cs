using DS.Core.Dto.SubCategory;
using DS.Core.Utilities;

namespace DS.Core.Dto.Category
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;    
        public List<int> SubCategoryIds { get; set; } = new();
    }
}

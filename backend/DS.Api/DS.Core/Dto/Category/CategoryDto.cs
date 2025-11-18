using DS.Core.Dto.SubCategory;
using DS.Core.Utilities;

namespace DS.Core.Dto.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Constants.RecordStatus Status { get; set; }
        public List<SubCategoryDto> SubCategories { get; set; } = new List<SubCategoryDto>();
    }
}

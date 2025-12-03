using DS.Core.Dto.Tag;
using DS.Core.Dto;

namespace DS.Core.Abstraction.Repositories
{
    public interface ITagRepository
    {
        Task AddTagAsync(Tag tag);
        void UpdateAsync(Tag tag);
        Task<Tag?> GetTrackedTagByIdAsync(int id);
        Task<Tag?> GetUntrackedTagByIdAsync(int id);
        Task<TableResponseDto<TagDto>> GetTagListAsync();
        void DeleteTagAsync(Tag tag);
    }
}

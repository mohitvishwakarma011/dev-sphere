using DS.Core.Dto;
using DS.Core.Dto.Tag;

namespace DS.Core.Abstraction.Managers
{
    public interface ITagManager
    {
        Task AddTagAync(UpsertTagDto tagDto);
        Task UpdateTagAsync(UpsertTagDto tagDto);
        Task<TagDto> GetTagByIdAsync(int id);
        Task<TableResponseDto<TagDto>> GetTagListAsync();
        Task DeleteTagAsync(int id);
    }
}

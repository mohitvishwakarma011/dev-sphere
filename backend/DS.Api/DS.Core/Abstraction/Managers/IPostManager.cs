using DS.Core.Dto;
using DS.Core.Dto.Post;
using DS.Core.Models.FilterModel;

namespace DS.Core.Abstraction.Managers
{
    public interface  IPostManager
    {
        Task AddAsync(PostModel postModel);
        Task Update(PostModel postModel);
        Task<bool> IsExistAsync(int id);
        Task<TableResponseDto<PostDto>> GetListAsync(PostFilterModel model);
        Task<PostDto> GetByIdAsync(int id);
        Task DeletePost(int id);
    }
}

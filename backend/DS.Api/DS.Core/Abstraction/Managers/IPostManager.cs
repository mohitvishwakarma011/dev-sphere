using DS.Core.Dto;
using DS.Core.Dto.Post;
using DS.Core.Models.FilterModel;

namespace DS.Core.Abstraction.Managers
{
    public interface  IPostManager
    {
        Task AddAsync(PostModel postModel,int userId);
        Task Update(PostModel postModel);
        Task<bool> IsExistAsync(int id);
        Task<TableResponseDto<PostDto>> GetListAsync(PostFilterModel model, int userId);
        Task<PostDto> GetByIdAsync(int id, int userId);
        Task DeletePost(int id);
    }
}

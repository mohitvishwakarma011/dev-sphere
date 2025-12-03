using DS.Core.Dto;
using DS.Core.Dto.Post;
using DS.Core.Models.FilterModel;

namespace DS.Core.Abstraction.Repositories
{
    public interface IPostRepository
    {
        Task AddAsync(Post post);
        Task<bool> IsExistAsync(int id);
        Task Update(Post post);
        Task<TableResponseDto<PostDto>> GetListAsync(PostFilterModel model,int userId);
        Task<PostDto> GetByIdAsync(int id, int userId);
        Task DeletePost(int id);
    }
}

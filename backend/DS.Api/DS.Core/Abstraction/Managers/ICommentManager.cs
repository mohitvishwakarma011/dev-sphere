using DS.Core.Dto;
using DS.Core.Dto.Comment;
using DS.Core.Models.FilterModel;

namespace DS.Core.Abstraction.Managers
{
    public interface ICommentManager
    {
        Task AddCommentAsync(UpsertCommentDto commentDto, int userId);
        Task UpdateCommentAsync(UpsertCommentDto commentDto);
        Task<CommentDto> GetCommentByIdAsync(int id);
        Task<TableResponseDto<CommentDto>> GetCommentList(CommentFilterModel filterModel);
    }
}

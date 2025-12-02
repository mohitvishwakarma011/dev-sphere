using DS.Core.Dto;
using DS.Core.Dto.Comment;
using DS.Core.Models.FilterModel;

namespace DS.Core.Abstraction.Repositories
{
    public interface ICommentRepository
    {
        Task AddCommentAsync(Comment comment);
        void UpdateComment(Comment comment);
        Task<Comment> GetTrackedCommentByIdAsync(int id);
        Task<CommentDto> GetUntrackedCommentByIdAsync(int id);
        Task<TableResponseDto<CommentDto>> GetCommentList(CommentFilterModel filterModel);
    }
}

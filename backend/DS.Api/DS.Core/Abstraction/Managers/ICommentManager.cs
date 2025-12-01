using DS.Core.Dto.Comment;

namespace DS.Core.Abstraction.Managers
{
    public interface ICommentManager
    {
        Task AddCommentAsync(UpsertCommentDto commentDto, int userId);
        Task UpdateCommentAsync(UpsertCommentDto commentDto);
        Task<CommentDto> GetCommentByIdAsync(int id);
    }
}

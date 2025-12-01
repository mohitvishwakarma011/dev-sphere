using DS.Core.Dto.Comment;

namespace DS.Core.Abstraction.Repositories
{
    public interface ICommentRepository
    {
        Task AddCommentAsync(Comment comment);
        void UpdateComment(Comment comment);
        Task<Comment> GetTrackedCommentByIdAsync(int id);
        Task<CommentDto> GetUntrackedCommentByIdAsync(int id);
    }
}

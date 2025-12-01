using DS.Core.Dto.Comment;

namespace DS.Infrastructure.Repositories
{
    public class CommentRepository(AppDbContext context) : ICommentRepository
    {
        public async Task AddCommentAsync(Comment comment)
        {
            await context.Comments.AddAsync(comment);
        }

        public void UpdateComment(Comment comment)
        {
            context.Comments.Update(comment);
        }

        public async Task<Comment> GetTrackedCommentByIdAsync(int id)
        {
            return await context.Comments.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<CommentDto> GetUntrackedCommentByIdAsync(int id)
        {
            var comment = await context.Comments.AsNoTracking().SingleOrDefaultAsync(c => c.Id == id);

            if(comment == null)
            {
                throw new InvalidOperationException("Comment does not exist.");
            }
            return new CommentDto
            {
                Content = comment.Content,
                Id = comment.Id,
                CreatedAt = comment.CreatedAt,
                PostId = comment.PostId,
                UserId = comment.UserId
            };
        }
    }
}

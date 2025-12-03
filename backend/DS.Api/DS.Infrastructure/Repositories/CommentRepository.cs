using DS.Core.Dto;
using DS.Core.Dto.Comment;
using DS.Core.Models.FilterModel;

using System.Linq.Dynamic.Core;
using System.Runtime.InteropServices;

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

            if (comment == null)
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

        public async Task<TableResponseDto<CommentDto>> GetCommentList(CommentFilterModel filterModel)
        {
            var query = context.Comments.AsNoTracking().AsQueryable().Where(c => c.PostId == filterModel.PostId && c.Status != Constants.RecordStatus.Deleted);

            var count = await query.CountAsync();
            var result = await query.OrderBy(filterModel.SortExpression())
                .Skip(filterModel.RecordToSkip()).Take(filterModel.PageSize)
                .Select(c => new CommentDto
                {
                    Content = c.Content,
                    CreatedAt = c.CreatedAt,
                    Id = c.Id,
                    PostId = c.PostId,
                    UserId = c.UserId,
                    Status = c.Status
                }).ToListAsync();

            return new TableResponseDto<CommentDto>
            {
                TotalCount = count,
                Items = result
            };
        }
    }
}

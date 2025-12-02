using DS.Core.Dto;
using DS.Core.Dto.Comment;
using DS.Core.Models.FilterModel;

namespace DS.Application.Managers
{
    public class CommentManager(ICommentRepository commentRepository, IUnitOfWork unitOfWork) : ICommentManager
    {
        public async Task AddCommentAsync(UpsertCommentDto commentDto, int userId)
        {
            var comment = new Comment
            {
                Content = commentDto.Content,
                CreatedAt = DateTime.UtcNow,
                PostId = commentDto.PostId,
                UserId = userId,
            };

            await commentRepository.AddCommentAsync(comment);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateCommentAsync(UpsertCommentDto commentDto)
        {
            var comment = await commentRepository.GetTrackedCommentByIdAsync(commentDto.Id);
            if (comment == null)
            {
                throw new InvalidOperationException("Comment does not exist.");
            }

            comment.Content = commentDto.Content;

            commentRepository.UpdateComment(comment);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<CommentDto> GetCommentByIdAsync(int id)
        {
            return await commentRepository.GetUntrackedCommentByIdAsync(id);
        }

        public async Task<TableResponseDto<CommentDto>> GetCommentList(CommentFilterModel filterModel)
        {
            return await commentRepository.GetCommentList(filterModel);
        }
    }
}

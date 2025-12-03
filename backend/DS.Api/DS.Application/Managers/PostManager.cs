
using DS.Core.Dto;
using DS.Core.Dto.Post;
using DS.Core.Entities;
using DS.Core.Models.FilterModel;

namespace DS.Application.Managers
{
    public class PostManager(IPostRepository repository,IUnitOfWork unitOfWork) : IPostManager
    {
        public async Task AddAsync(PostModel model,int userId)
        {
            var post = new Post
            {
                AuthorId = userId,
                CategoryId = model.CategoryId,
                Title = model.Title,
                Content = model.Content,
                SubCategoryId = model.SubCategoryId,
                CreatedAt = DateTime.UtcNow,
                Status = Constants.RecordStatus.Active,
                PostTags = model.TagIds.Select(t=> new PostTag { TagId = t}).ToList()
            };

            await repository.AddAsync(post);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task Update(PostModel postModel)
        {
            var post = new Post
            {
                Id = postModel.Id,
                AuthorId = postModel.AuthorId,
                CategoryId = postModel.CategoryId,
                Title = postModel.Title,
                Content = postModel.Content,
                SubCategoryId = postModel.SubCategoryId
            };

            await repository.Update(post);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await repository.IsExistAsync(id);
        }

        public async Task<TableResponseDto<PostDto>> GetListAsync(PostFilterModel filterModel, int userId)
        {
            return await repository.GetListAsync(filterModel,userId);
        }

        public async Task<PostDto> GetByIdAsync(int id, int userId)
        {
            return await repository.GetByIdAsync(id,userId);
        }

        public async Task DeletePost(int id)
        {
            await repository.DeletePost(id);
            await unitOfWork.SaveChangesAsync();
        }
    }
}

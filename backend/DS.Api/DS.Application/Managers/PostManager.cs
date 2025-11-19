
using DS.Core.Dto;
using DS.Core.Dto.Post;
using DS.Core.Models.FilterModel;

namespace DS.Application.Managers
{
    public class PostManager(IPostRepository repository,IUnitOfWork unitOfWork) : IPostManager
    {
        public async Task AddAsync(PostModel model)
        {
            var post = new Post
            {
                AuthorId = model.AuthorId,
                CategoryId = model.CategoryId,
                Title = model.Title,
                Content = model.Content,
                SubCategoryId = model.SubCategoryId,
                CreatedAt = DateTime.Now,
                Status = Constants.RecordStatus.Active
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

        public async Task<TableResponseDto<PostDto>> GetListAsync(PostFilterModel filterModel)
        {
            return await repository.GetListAsync(filterModel);
        }

        public async Task<PostDto> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task DeletePost(int id)
        {
            await repository.DeletePost(id);
            await unitOfWork.SaveChangesAsync();
        }
    }
}


namespace DS.Infrastructure.Repositories
{
    public class PostRepository(AppDbContext context) : IPostRepository
    {
        public async Task AddAsync(Post post)
        {
            await context.Posts.AddAsync(post);
        }

        public async Task<bool> IsExistAsync(int id)
        {
            return await context.Posts.AnyAsync(post => post.Id == id);
        }

        public async Task Update(Post post)
        {
            var postEntity = await context.Posts.SingleAsync(x=>x.Id == post.Id);

            postEntity.Title = post.Title;
            postEntity.Content = post.Content;
            postEntity.CategoryId = post.CategoryId;
            postEntity.SubCategoryId = post.SubCategoryId;
            postEntity.AuthorId = post.AuthorId;

            context.Posts.Update(postEntity);
        }
    }
}

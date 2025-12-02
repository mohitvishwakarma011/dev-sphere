namespace DS.Infrastructure.Repositories
{
    public class LikeRepository(AppDbContext context) : ILikeRepository
    {
        public async Task<bool> ToggleLike(int postId, int userId)
        {
            var likeEntity = await context.Likes.SingleOrDefaultAsync(l=>l.PostId == postId && l.UserId == userId);

            if (likeEntity == null)
            {
                var like = new Like
                {
                    UserId = userId,
                    PostId = postId,
                };

                await context.Likes.AddAsync(like);
                return true;
            }
            else
            {
                context.Likes.Remove(likeEntity);
                return false;
            }
        }
    }
}

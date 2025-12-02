namespace DS.Application.Managers
{
    public class LikeManager(ILikeRepository likeRpeository,IUnitOfWork unitOfWork) : ILikeManager
    {
        public async Task<bool> ToggleLike(int postId, int userId)
        {
            var res = await likeRpeository.ToggleLike(postId, userId);
            await unitOfWork.SaveChangesAsync();
            return res;
        }
    }
}

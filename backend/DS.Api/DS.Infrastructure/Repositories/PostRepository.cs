
using DS.Core.Dto;
using DS.Core.Dto.Category;
using DS.Core.Dto.Comment;
using DS.Core.Dto.Post;
using DS.Core.Dto.SubCategory;
using DS.Core.Dto.Tag;
using DS.Core.Dto.User;
using DS.Core.Models.FilterModel;
using System.Linq.Dynamic.Core;

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
            var postEntity = await context.Posts.SingleAsync(x => x.Id == post.Id);

            postEntity.Title = post.Title;
            postEntity.Content = post.Content;
            postEntity.CategoryId = post.CategoryId;
            postEntity.SubCategoryId = post.SubCategoryId;
            postEntity.AuthorId = post.AuthorId;

            context.Posts.Update(postEntity);
        }

        public async Task<TableResponseDto<PostDto>> GetListAsync(PostFilterModel filterModel)
        {
            var query = context.Posts
        .AsNoTracking()
        .Include(x => x.User)
        .Include(x => x.Category)
        .Include(x => x.SubCategory)
        .Include(x => x.Likes)
        .Include(x => x.PostTags)
            .ThenInclude(pt => pt.Tag)
        .AsQueryable()
        .Where(x => x.Status != Constants.RecordStatus.Deleted);

            if (!string.IsNullOrWhiteSpace(filterModel.FilterKey))
            {
                var upperFilterKey = filterModel.FilterKey.ToUpper();
                query = query.Where(x => EF.Functions.Like(x.Title.ToUpper(), $"%{upperFilterKey}%"));
            }

            // Get total count before pagination
            var totalCount = await query.CountAsync();

            // Project to DTO and apply pagination
            var items = await query
                .OrderBy(filterModel.SortExpression())
                .Skip(filterModel.RecordToSkip())
                .Take(filterModel.PageSize)
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    CreatedAt = p.CreatedAt,
                    ViewsCount = p.ViewsCount,
                    Likes = p.Likes.Count, // Assuming Post has a Likes navigation property
                    User = new UserDto
                    {
                        Id = p.User.Id,
                        //Role = p.User.Role,
                        Status = p.User.Status,
                        UserEmail = p.User.UserEmail,
                        UserName = p.User.UserName,
                    },
                    Category = new CategoryDto
                    {
                        Id = p.Category.Id,
                        Name = p.Category.Name,
                        Description = p.Category.Description,
                        Status = p.Category.Status,
                    },
                    SubCategory = new SubCategoryDto
                    {
                        Id = p.SubCategory.Id,
                        Name = p.SubCategory.Name,
                        Description = p.SubCategory.Description,
                        CategoryId = p.SubCategory.CategoryId,
                        Status = p.SubCategory.Status
                    },
                    Tags = p.PostTags.Select(pt => new TagDto
                    {
                        Id = pt.Tag.Id,
                        Title = pt.Tag.Name
                    }).ToList(),
                    Comments = p.Comments.Select(x => new CommentDto
                    {
                        Content = x.Content,
                        CreatedAt = x.CreatedAt,
                        Id = x.Id,
                        PostId = x.PostId,
                        UserId = x.UserId
                    }).ToList()
                })
                .ToListAsync();

            return new TableResponseDto<PostDto>
            {
                TotalCount = totalCount,
                Items = items
            };
        }

        public async Task<PostDto> GetByIdAsync(int id)
        {
            var result = await context.Posts.AsQueryable()
                .AsNoTracking()
                .Where(x => x.Id == id && x.Status != Constants.RecordStatus.Deleted)
                .Select(p => new PostDto
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content,
                    CreatedAt = p.CreatedAt,
                    ViewsCount = p.ViewsCount,
                    Likes = p.Likes.Count, // Assuming Post has a Likes navigation property
                    User = new UserDto
                    {
                        Id = p.User.Id,
                        //Role = p.User.Role,
                        Status = p.User.Status,
                        UserEmail = p.User.UserEmail,
                        UserName = p.User.UserName,
                    },
                    Category = new CategoryDto
                    {
                        Id = p.Category.Id,
                        Name = p.Category.Name,
                        Description = p.Category.Description,
                        Status = p.Category.Status,
                    },
                    SubCategory = new SubCategoryDto
                    {
                        Id = p.SubCategory.Id,
                        Name = p.SubCategory.Name,
                        Description = p.SubCategory.Description,
                        CategoryId = p.SubCategory.CategoryId,
                        Status = p.SubCategory.Status
                    },
                    Tags = p.PostTags.Select(pt => new TagDto
                    {
                        Id = pt.Tag.Id,
                        Title = pt.Tag.Name
                    }).ToList(),
                    Comments = p.Comments.Select(x => new CommentDto
                    {
                        Content = x.Content,
                        CreatedAt = x.CreatedAt,
                        Id = x.Id,
                        PostId = x.PostId,
                        UserId = x.UserId
                    }).ToList()
                }).FirstOrDefaultAsync();

            return result;
        }

        public async Task DeletePost(int id)
        {
            var post = await context.Posts.SingleAsync(p => p.Id == id);
            post.Status = Constants.RecordStatus.Deleted;
        }
    }
}

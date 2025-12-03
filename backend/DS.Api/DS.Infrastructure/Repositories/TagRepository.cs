using DS.Core.Dto;
using DS.Core.Dto.Tag;

namespace DS.Infrastructure.Repositories
{
    public class TagRepository(AppDbContext context):ITagRepository
    {
        public async Task AddTagAsync(Tag tag)
        {
            await context.Tags.AddAsync(tag);
        }

        public void UpdateAsync(Tag tag)
        {
            context.Tags.Update(tag);
        }

        public async Task<Tag?> GetTrackedTagByIdAsync(int id)
        {
            return await context.Tags.SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Tag?> GetUntrackedTagByIdAsync(int id)
        {
            return await context.Tags.AsNoTracking().SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TableResponseDto<TagDto>> GetTagListAsync()
        {
            var result = await context.Tags.AsNoTracking().OrderBy(t => t.Name).Select(t => new TagDto
            {
                Id = t.Id,
                Title = t.Name
            }).ToListAsync();

            return new TableResponseDto<TagDto>
            {
                TotalCount = result.Count,
                Items = result
            };
        }

        public void DeleteTagAsync(Tag tag)
        {
            context.Tags.Remove(tag);
        }
    }
}

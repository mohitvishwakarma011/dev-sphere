using DS.Core.Dto;
using DS.Core.Dto.Tag;

namespace DS.Application.Managers
{
    public class TagManager(ITagRepository tagRepository, IUnitOfWork unitOfWork) : ITagManager
    {
        public async Task AddTagAync(UpsertTagDto tagDto)
        {
            var tag = new Tag
            {
                Name = tagDto.Title,
            };
            await tagRepository.AddTagAsync(tag);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateTagAsync(UpsertTagDto tagDto)
        {
            var tag = await tagRepository.GetTrackedTagByIdAsync(tagDto.Id);

            if (tag == null)
            {
                throw new InvalidOperationException("Tag does not exist.");
            }

            tag.Name = tagDto.Title;
            tagRepository.UpdateAsync(tag);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<TagDto>GetTagByIdAsync(int id)
        {
            var tag = await tagRepository.GetUntrackedTagByIdAsync(id);
            if (tag == null)
            {
                throw new InvalidOperationException("Tag does not exist.");
            }

            return new TagDto
            {
                Id = tag.Id,
                Title = tag.Name
            };
        }

        public async Task<TableResponseDto<TagDto>> GetTagListAsync()
        {
            return await tagRepository.GetTagListAsync();
        }

        public async Task DeleteTagAsync(int id)
        {
            var tag = await tagRepository.GetTrackedTagByIdAsync(id);
            if (tag == null)
            {
                throw new InvalidOperationException("Tag does not exist.");
            }

            tagRepository.DeleteTagAsync(tag);
            await unitOfWork.SaveChangesAsync();
        }
    }
}

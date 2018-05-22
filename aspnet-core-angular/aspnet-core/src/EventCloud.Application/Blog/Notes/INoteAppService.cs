using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using EventCloud.Blog.Notes.Dto;

namespace EventCloud.Blog.Notes
{
    public interface INoteAppService: IAsyncCrudAppService<NoteDto,int,PagedResultRequestDto,CreateNoteDto,UpdateNoteDto>
    {
        Task PublicNote(PublicNoteDto input);
        Task<PublicNoteDto> GetNote(EntityDto<int> input);
    }
}

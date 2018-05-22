using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using EventCloud.Authorization;
using EventCloud.Blog.Notes.Dto;
using Microsoft.EntityFrameworkCore;

namespace EventCloud.Blog.Notes
{
    [AbpAuthorize(PermissionNames.Pages_Blogs_Notes)]
    public class NoteAppService:AsyncCrudAppService<Note,NoteDto,int,PagedResultRequestDto,CreateNoteDto,UpdateNoteDto>,INoteAppService
    {
        private readonly IRepository<Note> _noteRepository;
        public NoteAppService(IRepository<Note> repository) : base(repository)
        {
            _noteRepository = repository;
        }

        public override async Task<NoteDto> Create(CreateNoteDto input)
        {
            var note = ObjectMapper.Map<Note>(input);
            var result = await _noteRepository.InsertAsync(note);
            return ObjectMapper.Map<NoteDto>(result);
        }

        public async Task PublicNote(PublicNoteDto input)
        {
            var note = _noteRepository.Get(input.Id);
            ObjectMapper.Map(input, note);
            var result = await _noteRepository.UpdateAsync(note);
        }
        public override async Task<NoteDto> Update(UpdateNoteDto input)
        {
            CheckUpdatePermission();

            var note = _noteRepository.Get(input.Id);

            MapToEntity(input, note);

            var response=await _noteRepository.UpdateAsync(note);
            return await Get(input);
        }

        //public async Task<PagedResultDto<NoteDto>> GetAll(GetNoteListDto input)
        //{
        //    var data = Repository.GetAll().Where(m => !m.IsDeleted);
        //    if (!string.IsNullOrEmpty(input.Key))
        //    {
        //        data = data.Where(m => m.Title.Contains(input.Key) || m.Tags.Contains(input.Key));
        //    }
        //    int count = await data.CountAsync();
        //    var notes = await data.OrderByDescending(q => q.CreationTime)
        //        .PageBy(input)
        //        .ToListAsync();
        //    return new PagedResultDto<NoteDto>()
        //    {
        //        TotalCount = count,
        //        Items = ObjectMapper.Map<List<NoteDto>>(notes)
        //    };
        //}
        public async Task<PublicNoteDto> GetNote(EntityDto<int> input)
        {
            var note = await Repository.GetAsync(input.Id);
            return ObjectMapper.Map<PublicNoteDto>(note);
        }
    }
}

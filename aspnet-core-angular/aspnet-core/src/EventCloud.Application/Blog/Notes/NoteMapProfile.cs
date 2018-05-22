using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using EventCloud.Blog.Notes.Dto;

namespace EventCloud.Blog.Notes
{
    public class NoteMapProfile:Profile
    {
        public NoteMapProfile()
        {
            CreateMap<CreateNoteDto, Note>();
            CreateMap<UpdateNoteDto, Note>();
            CreateMap<PublicNoteDto, Note>();
            //使用自定义解析
            CreateMap<Note, NoteDto>().ForMember(x => x.IsPublic, opt => { opt.ResolveUsing<NoteToNoteDtoResolver>(); });
            CreateMap<Note, PublicNoteDto>();
        }
        public class NoteToNoteDtoResolver:IValueResolver<Note,NoteDto,string>
        {
            public string Resolve(Note source, NoteDto destination, string destMember, ResolutionContext context)
            {
                return source.IsPublic ? "已发布" : "未发布";
            }
        }
    }
}

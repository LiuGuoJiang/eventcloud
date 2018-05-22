using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace EventCloud.Blog.Notes.Dto
{
    public class GetNoteListDto:PagedResultRequestDto
    {
        /// <summary>
        /// 用于搜索的关键字
        /// </summary>
        public string Key { get; set; }
    }
}

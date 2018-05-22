using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using Abp.Runtime.Validation;

namespace EventCloud.Blog.Notes.Dto
{
    /// <summary>
    /// 自动更新所传的数据
    /// </summary>
    public class UpdateNoteDto : EntityDto<int>,IShouldNormalize
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 上次修改时间
        /// </summary>
        public DateTime? LastModificationTime { get; set; }

        public void Normalize()
        {
            if (!LastModificationTime.HasValue)
            {
                LastModificationTime=DateTime.Now;
            }
        }
    }
}

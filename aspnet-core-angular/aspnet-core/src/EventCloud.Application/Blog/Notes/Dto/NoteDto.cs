using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventCloud.Blog.Notes.Dto
{
    /// <summary>
    /// 用于列表展示
    /// </summary>
    public class NoteDto : EntityDto<int>
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// 点赞次数
        /// </summary>
        public long Like { get; set; }
        /// <summary>
        /// 收藏次数
        /// </summary>
        public long Collect { get; set; }
        /// <summary>
        /// 浏览次数
        /// </summary>
        public long Scan { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        public string IsPublic { get; set; }
    }
}

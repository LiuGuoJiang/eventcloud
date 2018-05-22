using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventCloud.Blog.Notes
{
    public class NoteToNoteBook: Entity, IHasCreationTime, ICreationAudited
    {
        /// <summary>
        /// 文章的id
        /// </summary>
        public int NoteId { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        public Note Note { get; set; }
        /// <summary>
        /// 专辑id
        /// </summary>
        public int NoteBookId { get; set; }
        /// <summary>
        /// 专辑内容
        /// </summary>
        public NoteBook NoteBook { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public long? CreatorUserId { get; set; }
    }
}

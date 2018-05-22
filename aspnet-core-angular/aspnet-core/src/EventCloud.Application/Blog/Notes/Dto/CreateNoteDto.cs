using System;
using System.Collections.Generic;
using System.Text;
using Abp.Runtime.Validation;

namespace EventCloud.Blog.Notes.Dto
{
    /// 创建的时候不需要太多信息，内容更新主要依靠update
    /// 在用户点击创建的时候数据库便创建数据，在用户编辑过程中自动更新保存数据。
    /// </summary>
    public class CreateNoteDto:IShouldNormalize
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreationTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public long CreatorUserId { get; set; }
        /// <summary>
        /// 内容的数据类型 markdown内容，html内容，或者其他
        /// </summary>
        public int TextType { get; set; }

        public void Normalize()
        {
            if(!CreationTime.HasValue)CreationTime=DateTime.Now;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Runtime.Validation;

namespace EventCloud.Blog.Notes.Dto
{
    /// <summary>
    /// 发布更新时所用
    /// </summary>
    public class PublicNoteDto : UpdateNoteDto,ICustomValidate,IShouldNormalize
    {
        /// <summary>
        /// 简单描述，用于微信推送时的描述或者其他
        /// </summary>
        public string Des { get; set; }
        /// <summary>
        /// 封面图片，可用于微信推送时或者其他
        /// </summary>
        public string Img { get; set; }
        /// <summary>
        /// 关键字，可用于搜索，分类等
        /// </summary>
        public string Tags { get; set; }
        /// <summary>
        /// 是否发布
        /// </summary>
        public bool IsPublic { get; set; }

        public void Normalize()
        {
            base.Normalize();
            IsPublic = true;
        }

        public void AddValidationErrors(CustomValidationContext context)
        {
            if (string.IsNullOrEmpty(Des))
            {
                string error = "描述不能为空";
                context.Results.Add(new ValidationResult(error));
            }
            if (Des.Length < 10)
            {
                string error = "描述不能少于10个字";
                context.Results.Add(new ValidationResult(error));
            }

            if (Des.Length > 200)
            {
                string error = "描述不能大于200个字";
                context.Results.Add(new ValidationResult(error));
            }
        }
    }
}

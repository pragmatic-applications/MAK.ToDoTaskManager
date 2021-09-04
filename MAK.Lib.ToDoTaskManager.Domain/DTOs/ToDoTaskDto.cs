using System;
using System.ComponentModel.DataAnnotations;

using Constants;

using Domain;

namespace DTOs
{
    public class ToDoTaskDto
    {
        public int Id { get; set; }

        [Display(Name = "Title"), Required, MinLength(2)]
        public string Title { get; set; }

        private string detail;

        [Display(Name = "Detail"), MinLength(2)]
        public string Detail
        {
            get
            {
                if(string.IsNullOrWhiteSpace(this.detail))
                {
                    this.detail = this.Title;
                }

                return this.detail;
            }

            set
            {
                if(string.IsNullOrWhiteSpace(this.detail))
                {
                    this.detail = this.Title;
                }

                this.detail = value;
            }
        }

        [Display(Name = "Image")]
        public string Image { get; set; } = ApiUrl.DefaultImage;

        [Display(Name = "Complete")]
        public bool Complete { get; set; } = false;

        [Display(Name = "Created Date")]
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;

        [Display(Name = "Category")]
        public int ToDoTaskCategoryId { get; set; } = (int)ToDoTaskCategoryType.Unspecified;
        public ToDoTaskCategory ToDoTaskCategory { get; set; }

        [Display(Name = "Task Category")]
        public string TaskCategory { get; set; }
    }
}

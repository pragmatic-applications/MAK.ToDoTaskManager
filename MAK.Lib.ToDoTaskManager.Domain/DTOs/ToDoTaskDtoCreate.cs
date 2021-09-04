using System.ComponentModel.DataAnnotations;

using Constants;

using Domain;

namespace DTOs
{
    public class ToDoTaskDtoCreate
    {
        [Display(Name = "Title"), Required, MinLength(2)]
        public string Title { get; set; }

        [Display(Name = "Detail"), MinLength(2)]
        public string Detail { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; } = ApiUrl.DefaultImage;

        [Display(Name = "Complete")]
        public bool Complete { get; set; } = false;

        [Display(Name = "Category")]
        public int ToDoTaskCategoryId { get; set; } = (int)ToDoTaskCategoryType.Unspecified;
    }
}

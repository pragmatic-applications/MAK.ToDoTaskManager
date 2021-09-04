using System.ComponentModel.DataAnnotations;

using Constants;

namespace DTOs
{
    public class ToDoTaskDtoUpdate
    {
        [Display(Name = "Title"), MinLength(2)]
        public string Title { get; set; }

        [Display(Name = "Detail"), MinLength(2)]
        public string Detail { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; } = ApiUrl.DefaultImage;

        [Display(Name = "Complete")]
        public bool? Complete { get; set; }

        [Display(Name = "Category")]
        public int? ToDoTaskCategoryId { get; set; }
    }
}

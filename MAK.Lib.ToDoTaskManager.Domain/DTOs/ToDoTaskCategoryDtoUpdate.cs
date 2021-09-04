using System;
using System.ComponentModel.DataAnnotations;

using Domain;

namespace DTOs
{
    public class ToDoTaskCategoryDtoUpdate
    {
        [Display(Name = "Category"), MinLength(2, ErrorMessage = "Minimum length is 2")]
        public string Name { get; set; } = Enum.GetName(ToDoTaskCategoryType.Unspecified);
    }
}

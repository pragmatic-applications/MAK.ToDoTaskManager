using System;
using System.ComponentModel.DataAnnotations;

using Domain;

namespace DTOs
{
    public class ToDoTaskCategoryDtoCreate
    {
        [Display(Name = "Category"), Required, MinLength(2, ErrorMessage = "Minimum length is 2")]
        public string Name { get; set; } = Enum.GetName(ToDoTaskCategoryType.Unspecified);
    }
}

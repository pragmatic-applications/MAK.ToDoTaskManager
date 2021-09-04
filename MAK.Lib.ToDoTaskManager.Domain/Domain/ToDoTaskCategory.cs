using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class ToDoTaskCategory
    {
        public int Id { get; set; }

        [Display(Name = "Category"), Required, MinLength(2, ErrorMessage = "Minimum length is 2")]
        public string Name { get; set; } = Enum.GetName(ToDoTaskCategoryType.Unspecified);

        public ICollection<ToDoTask> ToDoTasks { get; set; }
    }
}

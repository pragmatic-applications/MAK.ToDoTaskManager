using System.Collections.Generic;

using Domain;

using DTOs;

namespace Extensions
{
    public static class ToDoTaskMapper
    {
        public static ToDoTask Map(this ToDoTaskDtoUpdate item, ToDoTask newItem)
        {
            newItem.Title = item.Title;
            newItem.Detail = item.Detail;
            newItem.Image = item.Image;
            newItem.Complete = item.Complete.Value;
            newItem.ToDoTaskCategoryId = item.ToDoTaskCategoryId.Value;

            return newItem;
        }

        public static ToDoTask Map(this ToDoTaskDtoCreate item)
        {
            return new ToDoTask
            {
                Title = item.Title,
                Detail = item.Detail,
                Image = item.Image,
                Complete = item.Complete,
                ToDoTaskCategoryId = item.ToDoTaskCategoryId
            };
        }

        public static ToDoTaskDto MapDefault(this ToDoTask item)
        {
            return new ToDoTaskDto
            {
                Title = item.Title,
                Detail = item.Detail,
                Image = item.Image,
                Complete = item.Complete,
                ToDoTaskCategoryId = item.ToDoTaskCategoryId
            };
        }
        public static ToDoTaskDto Map(this ToDoTask item)
        {
            var toDoTaskCategory = new ToDoTaskCategory
            {
                Id = item.ToDoTaskCategoryId,
                Name = item.ToDoTaskCategory.Name
            };

            return new ToDoTaskDto
            {
                Id = item.Id,
                Title = item.Title,
                Detail = item.Detail,
                Image = item.Image,
                Complete = item.Complete,
                CreatedDate = item.CreatedDate,
                ToDoTaskCategoryId = item.ToDoTaskCategoryId,
                ToDoTaskCategory = toDoTaskCategory,
                TaskCategory = item.ToDoTaskCategory.Name
            };
        }
        public static ToDoTask Map(this ToDoTaskDto item)
        {
            return new ToDoTask
            {
                Id = item.Id,
                Title = item.Title,
                Detail = item.Detail,
                Image = item.Image,
                Complete = item.Complete,
                CreatedDate = item.CreatedDate,
                ToDoTaskCategoryId = item.ToDoTaskCategoryId,
                ToDoTaskCategory = item.ToDoTaskCategory
            };
        }

        public static IEnumerable<ToDoTaskDto> Map(this IEnumerable<ToDoTask> models)
        {
            List<ToDoTaskDto> newItems = new();

            foreach(var item in models)
            {
                var newItem = new ToDoTaskDto
                {
                    Id = item.Id,
                    Title = item.Title,
                    Detail = item.Detail,
                    Image = item.Image,
                    Complete = item.Complete,
                    CreatedDate = item.CreatedDate,
                    ToDoTaskCategoryId = item.ToDoTaskCategoryId,
                    ToDoTaskCategory = item.ToDoTaskCategory
                };

                newItems.Add(newItem);
            }

            return newItems;
        }
        public static List<ToDoTask> Map(this List<ToDoTaskDto> models)
        {
            List<ToDoTask> newItems = new();

            foreach(var item in models)
            {
                var newItem = new ToDoTask
                {
                    Id = item.Id,
                    Title = item.Title,
                    Detail = item.Detail,
                    Image = item.Image,
                    Complete = item.Complete,
                    CreatedDate = item.CreatedDate,
                    ToDoTaskCategoryId = item.ToDoTaskCategoryId,
                    ToDoTaskCategory = item.ToDoTaskCategory
                };

                newItems.Add(newItem);
            }

            return newItems;
        }
    }
}

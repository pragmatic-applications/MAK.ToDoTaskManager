using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Domain;

using DTOs;

namespace Extensions
{
    public static class ToDoTaskCategoryMapper
    {
        public static ToDoTaskCategory Map(this ToDoTaskCategoryDtoUpdate item, ToDoTaskCategory newItem)
        {
            newItem.Name = item.Name;

            return newItem;
        }
        public static ToDoTaskCategory Map(this ToDoTaskCategoryDtoCreate item)
        {
            return new ToDoTaskCategory
            {
                Name = item.Name
            };
        }

        public static ToDoTaskCategoryDto Map(this ToDoTaskCategory item)
        {
            return new ToDoTaskCategoryDto
            {
                Id = item.Id,
                Name = item.Name
            };
        }
        public static ToDoTaskCategory Map(this ToDoTaskCategoryDto item)
        {
            return new ToDoTaskCategory
            {
                Id = item.Id,
                Name = item.Name
            };
        }

        public static IEnumerable<ToDoTaskCategoryDto> MapList(this IEnumerable<ToDoTaskCategory> models)
        {
            List<ToDoTaskCategoryDto> newItems = new();

            foreach(var item in models)
            {
                var newItem = new ToDoTaskCategoryDto
                {
                    Id = item.Id,
                    Name = item.Name
                };

                newItems.Add(newItem);
            }

            return newItems;
        }
        public static List<ToDoTaskCategory> MapList(this List<ToDoTaskCategoryDto> models)
        {
            List<ToDoTaskCategory> newItems = new();

            foreach(var item in models)
            {
                var newItem = new ToDoTaskCategory
                {
                    Id = item.Id,
                    Name = item.Name
                };

                newItems.Add(newItem);
            }

            return newItems;
        }

        public static ToDoTaskCategoryDto ToToDoTaskCategoryDto(this ToDoTaskCategory item)
        {
            return new ToDoTaskCategoryDto
            {
                Id = item.Id,
                Name = item.Name
            };
        }
        public static ToDoTaskCategory ToToDoTaskCategory(this ToDoTaskCategoryDto item)
        {
            return new ToDoTaskCategory
            {
                Id = item.Id,
                Name = item.Name
            };
        }
    }
}

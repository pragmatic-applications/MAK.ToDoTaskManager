using System.Collections.Generic;

using Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database
{
    public class ToDoTaskConfiguration : IEntityTypeConfiguration<ToDoTask>
    {
        public void Configure(EntityTypeBuilder<ToDoTask> builder)
        {
            builder.HasKey(item => item.Id);
            builder.Property(item => item.Title).IsRequired();
            builder.Property(item => item.Detail).IsRequired();

            builder.HasData(items);
        }

        private static int idCount = 0;
        private static int titleCount = 0;
        private static int detailCount = 0;

        private static readonly List<ToDoTask> items = new()
        {
            //--------------------------------------------------------------
            new ToDoTask
            {
                Id = ++idCount,
                Title = $"Title {++titleCount}",
                Detail = $"Detail {++detailCount}",
                ToDoTaskCategoryId = (int)ToDoTaskCategoryType.Unspecified
            },
            new ToDoTask
            {
                Id = ++idCount,
                Title = $"Title {++titleCount}",
                Detail = $"Detail {++detailCount}",
                ToDoTaskCategoryId = (int)ToDoTaskCategoryType.Important
            },
            new ToDoTask
            {
                Id = ++idCount,
                Title = $"Title {++titleCount}",
                Detail = $"Detail {++detailCount}",
                ToDoTaskCategoryId = (int)ToDoTaskCategoryType.Unspecified
            },
            new ToDoTask
            {
                Id = ++idCount,
                Title = $"Title {++titleCount}",
                Detail = $"Detail {++detailCount}",
                ToDoTaskCategoryId = (int)ToDoTaskCategoryType.Urgent
            },
            //--------------------------------------------------------------
            new ToDoTask
            {
                Id = ++idCount,
                Title = $"Title {++titleCount}",
                Detail = $"Detail {++detailCount}",
                ToDoTaskCategoryId = (int)ToDoTaskCategoryType.Unspecified
            },
            new ToDoTask
            {
                Id = ++idCount,
                Title = $"Title {++titleCount}",
                Detail = $"Detail {++detailCount}",
                ToDoTaskCategoryId = (int)ToDoTaskCategoryType.Urgent
            },
            new ToDoTask
            {
                Id = ++idCount,
                Title = $"Title {++titleCount}",
                Detail = $"Detail {++detailCount}",
                ToDoTaskCategoryId = (int)ToDoTaskCategoryType.Important
            },
            new ToDoTask
            {
                Id = ++idCount,
                Title = $"Title {++titleCount}",
                Detail = $"Detail {++detailCount}",
                ToDoTaskCategoryId = (int)ToDoTaskCategoryType.Unspecified
            },
            //--------------------------------------------------------------
            new ToDoTask
            {
                Id = ++idCount,
                Title = $"Title {++titleCount}",
                Detail = $"Detail {++detailCount}",
                ToDoTaskCategoryId = (int)ToDoTaskCategoryType.Urgent
            },
            new ToDoTask
            {
                Id = ++idCount,
                Title = $"Title {++titleCount}",
                Detail = $"Detail {++detailCount}",
                ToDoTaskCategoryId = (int)ToDoTaskCategoryType.Unspecified
            },
            new ToDoTask
            {
                Id = ++idCount,
                Title = $"Title {++titleCount}",
                Detail = $"Detail {++detailCount}",
                ToDoTaskCategoryId = (int)ToDoTaskCategoryType.Important
            },
            new ToDoTask
            {
                Id = ++idCount,
                Title = $"Title {++titleCount}",
                Detail = $"Detail {++detailCount}",
                ToDoTaskCategoryId = (int)ToDoTaskCategoryType.Important
            },
            //--------------------------------------------------------------
            new ToDoTask
            {
                Id = ++idCount,
                Title = $"Title {++titleCount}",
                Detail = $"Detail {++detailCount}",
                ToDoTaskCategoryId = (int)ToDoTaskCategoryType.Unspecified
            },
            new ToDoTask
            {
                Id = ++idCount,
                Title = $"Title {++titleCount}",
                Detail = $"Detail {++detailCount}",
                ToDoTaskCategoryId = (int)ToDoTaskCategoryType.Urgent
            },
            new ToDoTask
            {
                Id = ++idCount,
                Title = $"Title {++titleCount}",
                Detail = $"Detail {++detailCount}",
                ToDoTaskCategoryId = (int)ToDoTaskCategoryType.Unspecified
            },
            new ToDoTask
            {
                Id = ++idCount,
                Title = $"Title {++titleCount}",
                Detail = $"Detail {++detailCount}",
                ToDoTaskCategoryId = (int)ToDoTaskCategoryType.Important
            }
            //--------------------------------------------------------------
        };
    }
}

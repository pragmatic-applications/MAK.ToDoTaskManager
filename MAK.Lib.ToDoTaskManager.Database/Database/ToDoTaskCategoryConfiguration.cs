using System;
using System.Collections.Generic;

using Domain;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database
{
    public class ToDoTaskCategoryConfiguration : IEntityTypeConfiguration<ToDoTaskCategory>
    {
        public void Configure(EntityTypeBuilder<ToDoTaskCategory> builder)
        {
            builder.HasKey(item => item.Id);
            builder.Property(item => item.Name).IsRequired();

            builder.HasData(items);
        }

        private static int idCount = 0;

        private static List<ToDoTaskCategory> items
        {
            get => new()
            {
                new ToDoTaskCategory
                {
                    Id = ++idCount,
                    Name = Enum.GetName(ToDoTaskCategoryType.Unspecified)
                },
                new ToDoTaskCategory
                {
                    Id = ++idCount,
                    Name = Enum.GetName(ToDoTaskCategoryType.Important)
                },
                new ToDoTaskCategory
                {
                    Id = ++idCount,
                    Name = Enum.GetName(ToDoTaskCategoryType.Urgent)
                }
            };
        }
    }
}

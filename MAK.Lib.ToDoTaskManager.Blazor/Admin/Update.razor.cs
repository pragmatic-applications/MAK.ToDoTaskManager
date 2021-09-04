using System;
using System.Threading.Tasks;

using Domain;

namespace MAK.Lib.ToDoTaskManager.Blazor.Admin
{
    public partial class Update : ToDoTaskBase
    {
        protected override async Task OnInitializedAsync()
        {
            await this.GetEntityCategoryAsync();
            await this.GetAsync(id: this.Id);

            CoreComponent.EntityId = this.Id;

            this.FormTitle = "Update Item";
            this.FormMode = FormMode.Update;
            this.ButtonText = "Save";
            this.BannerTitleValue = "Update";

            this.CurrentCategoryId = this.ToDoTaskDto.ToDoTaskCategoryId;
            this.CategoryId = this.ToDoTaskDto.ToDoTaskCategoryId.ToString();
        }

        public CategoryFeedback GetCategoryFeedback()
        {
            CategoryFeedback data = new();

            if(this.CurrentCategoryId > 0 && this.CurrentCategoryId < 8)
            {
                switch(this.CurrentCategoryId)
                {
                    case ((int)ToDoTaskCategoryType.Unspecified):
                    data.Id = this.CurrentCategoryId;
                    data.Category = Enum.GetName(ToDoTaskCategoryType.Unspecified);
                    return data;

                    case ((int)ToDoTaskCategoryType.Important):
                    data.Id = this.CurrentCategoryId;
                    data.Category = Enum.GetName(ToDoTaskCategoryType.Important);
                    return data;

                    case ((int)ToDoTaskCategoryType.Urgent):
                    data.Id = this.CurrentCategoryId;
                    data.Category = Enum.GetName(ToDoTaskCategoryType.Urgent);
                    return data;
                }
            }

            return data;
        }

        protected override async Task UpdateAsync()
        {
            await this.HttpToDoTaskService.PutEntityAsync(this.ToDoTaskDto.Id, this.ToDoTaskDto);
            this.Reload();
        }
    }
}

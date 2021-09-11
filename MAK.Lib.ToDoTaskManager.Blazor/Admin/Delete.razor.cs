using System.Threading.Tasks;

using Domain;

namespace MAK.Lib.ToDoTaskManager.Blazor.Admin
{
    public partial class Delete : ToDoTaskBase
    {
        protected override async Task OnInitializedAsync()
        {
            await this.GetAsync(id: this.Id);

            this.FormTitle = "Delete Item";
            this.FormMode = FormMode.Delete;
            this.ButtonText = "Delete";

            this.AppNameValue = "MicroTech";
            this.BannerTitleValue = this.AppNameValue + " | " + "Delete";
            this.BrowserTitleValue = this.BannerTitleValue;
        }

        protected override async Task DeleteAsync()
        {
            await this.HttpToDoTaskService.DeleteEntityAsync(this.ToDoTaskDto.Id);
            this.Reload();
        }
    }
}

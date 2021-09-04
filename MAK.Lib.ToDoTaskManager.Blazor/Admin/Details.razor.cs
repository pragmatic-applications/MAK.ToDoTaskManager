using System.Threading.Tasks;

using Constants;

using Domain;

namespace MAK.Lib.ToDoTaskManager.Blazor.Admin
{
    public partial class Details : ToDoTaskBase
    {
        protected override async Task OnInitializedAsync()
        {
            await this.GetAsync(id: this.Id);

            this.UrlUpdate = $"{ToDoTaskManagerPageRoute.S_ToDoTaskManagerAdminUpdate_S}{this.ToDoTaskDto.Id}";
            this.UrlDelete = $"{ToDoTaskManagerPageRoute.S_ToDoTaskManagerAdminDelete_S}{this.ToDoTaskDto.Id}";

            this.BannerTitleValue = "Admin - Details";
        }
    }
}

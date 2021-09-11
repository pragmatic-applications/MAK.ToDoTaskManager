using System.Threading.Tasks;

using Domain;

namespace MAK.Lib.ToDoTaskManager.Blazor.Admin
{
    [PageTitle("Admin")]
    public partial class Index : ToDoTaskBase
    {
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            this.BannerTitleValue = this.AppNameValue + " | " + "Admin Home";
            this.BrowserTitleValue = this.BannerTitleValue;
        }
    }
}

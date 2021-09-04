using System.Threading.Tasks;

using Domain;

namespace MAK.Lib.ToDoTaskManager.Blazor.Admin
{
    [PageTitle("ToDoTask Admin")]
    public partial class Index : ToDoTaskBase
    {
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            this.BannerTitleValue = "ToDoTask Admin";
        }
    }
}

using System.Threading.Tasks;

using Domain;

namespace MAK.Lib.ToDoTaskManager.Blazor
{
    [PageTitle("ToDoTask", true, true)]
    public partial class Index : ToDoTaskBase
    {
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            this.BannerTitleValue = "ToDoTask";
        }
    }
}

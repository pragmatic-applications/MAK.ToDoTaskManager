using Domain;

using Microsoft.AspNetCore.Components;

namespace MAK.Lib.ToDoTaskManager.Blazor.Views
{
    public partial class PageNotFound : CoreComponent
    {
        [Parameter] public string NotFoundImageParameter { get; set; }

        public string NotFoundImage { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            this.BannerTitleValue = "Page Not Found";
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            this.NotFoundImage = this.NotFoundImageParameter;
        }
    }
}

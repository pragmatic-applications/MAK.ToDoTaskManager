using Domain;

using Microsoft.AspNetCore.Components;

namespace MAK.Lib.ToDoTaskManager.Blazor
{
    public partial class PageNotFound : CoreComponent
    {
        [Parameter] public string NotFoundImageParameter { get; set; }

        public string NotFoundImage { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            this.AppNameValue = "MicroTech";
            this.BannerTitleValue = this.AppNameValue + " | " + "Page Not Found";
            this.BrowserTitleValue = this.BannerTitleValue;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            this.NotFoundImage = this.NotFoundImageParameter;
        }
    }
}

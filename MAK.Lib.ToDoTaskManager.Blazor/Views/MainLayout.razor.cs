using System;

using Constants;

using Domain;

using Microsoft.AspNetCore.Components;

namespace MAK.Lib.ToDoTaskManager.Blazor.Views
{
    public partial class MainLayout : LayoutComponentBase, IDisposable
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();

            this.MainCascadingValue = new MainCascadingValue(new ToDoTaskSelect(), "banner_background_image", "sort_container", SharedData.Spread);
        }

        public MainCascadingValue MainCascadingValue { get; set; }

        public void Dispose()
        {
            this.MainCascadingValue.ItemSelect = null;
            this.MainCascadingValue.BannerBackgroundImageCssClass = null;
            this.MainCascadingValue.PositionCssClass = null;
        }
    }
}

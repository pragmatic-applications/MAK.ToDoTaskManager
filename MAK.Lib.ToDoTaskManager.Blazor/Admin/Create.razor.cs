using System.Threading.Tasks;

using Domain;

namespace MAK.Lib.ToDoTaskManager.Blazor.Admin
{
    public partial class Create : ToDoTaskBase
    {
        protected override void OnInitialized()
        {
            this.FormTitle = "Add Entry";
            this.FormMode = FormMode.Create;
            this.ButtonText = "Save";
            this.BannerTitleValue = "Create";
        }

        public bool TitleState { get; set; }
        protected void FormFieldActionOnTitle() => this.TitleState = string.IsNullOrWhiteSpace(this.ToDoTaskDto.Title);

        public bool DetailState { get; set; }
        protected void FormFieldActionOnDetail() => this.DetailState = string.IsNullOrWhiteSpace(this.ToDoTaskDto.Detail);

        protected bool CanSave => this.TaskService.CanSave;
        protected override async Task InsertAsync()
        {
            foreach(var item in this.TaskService.Items)
            {
                await this.HttpToDoTaskService.PostEntityAsync(item);
            }

            this.TaskService.Clear();
            this.Reload();
        }

        protected bool CanAdd => string.IsNullOrWhiteSpace(this.ToDoTaskDto.Title) || string.IsNullOrWhiteSpace(this.ToDoTaskDto.Detail) || this.TitleState || this.DetailState || this.IsDisabled;

        protected void AddItem()
        {
            this.TaskService.AddItem(this.ToDoTaskDto);
            this.ToDoTaskDto = new();
        }        
    }
}

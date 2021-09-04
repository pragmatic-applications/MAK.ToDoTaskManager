using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Constants;

using DTOs;

using HttpServices;

using Interfaces;

using Microsoft.AspNetCore.Components;

using PageFeatures;

namespace Domain
{
    public class ToDoTaskBase : AppComponent<ToDoTaskDto, ToDoTaskCategory>, IDisposable
    {
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            this.AppNameValue = "MicroTech";
            this.ToDoTaskDto = new();

            await this.GetEntityCategoryAsync();
            await this.GetAsync();
        }

        [Inject] public ITaskService<ToDoTaskDto> TaskService { get; set; }
        [Inject] public HttpToDoTaskCategoryService HttpToDoTaskCategoryService { get; set; }

        [Inject] public ToDoTaskDto ToDoTaskDto { get; set; }
        [Inject] public List<ToDoTaskDto> ToDoTaskDtos { get; set; }
        [Inject] public HttpToDoTaskService HttpToDoTaskService { get; set; }

        [Inject] public List<ToDoTaskCategory> Categories { get; set; }

        public PagingResponse<ToDoTaskDto> PagingResponse { get; set; }

        protected override string IsDone => this.ToDoTaskDto.Complete ? "Yes" : "No";
        protected override string IsComplete => this.ToDoTaskDto.Complete ? "Yes" : "No";
        protected override string EntryId => this.ToDoTaskDto.Id < 10 ? $"0{this.ToDoTaskDto.Id}" : $"{this.ToDoTaskDto.Id}";

        protected override List<string> Images { get; } = new();
        protected override void AssignImageUrl(List<string> images)
        {
            foreach(var item in images)
            {
                this.Images.Add(item);
            }

            this.ToDoTaskDto.Image = this.Images.ElementAt(0);
        }
        protected override void AssignImageUrl(string imgUrl) => this.ToDoTaskDto.Image = imgUrl;

        protected override void ClearFields()
        {
            this.ToDoTaskDto.Id = 0;
            this.ToDoTaskDto.ToDoTaskCategoryId = 0;
            this.ToDoTaskDto.Title = string.Empty;
            this.ToDoTaskDto.Detail = string.Empty;
            this.ToDoTaskDto.Image = string.Empty;
            this.ToDoTaskDto.Complete = false;

            this.StateHasChanged();
        }

        protected override void Reload() => this.GoToPage(ToDoTaskManagerPageRoute.ToDoTaskManagerAdmin);

        protected override void LoadDataSuccess(PagingResponse<ToDoTaskDto> data)
        {
            this.ToDoTaskDtos = data.Items;
            this.PagerData = data.PagerData;
            this.IsLoading = false;
            this.IsError = false;

            this.StateHasChanged();
        }
        protected override void LoadDataFail(Exception exception)
        {
            this.ToDoTaskDtos = null;
            this.IsError = true;
        }
        protected override async Task TryLoadAsync(Action<PagingResponse<ToDoTaskDto>> success, Action<Exception> fail)
        {
            try
            {
                this.PagingResponse = await this.HttpToDoTaskService.GetEntitiesAsync(this.PagingEntity);
                success(this.PagingResponse);
            }
            catch(Exception ex)
            {

                fail(ex);
            }
            finally
            {
                this.IsLoading = false;
            }
        }
        protected override async Task GetAsync() => await this.TryLoadAsync(this.LoadDataSuccess, this.LoadDataFail);

        protected override void LoadEntityCategoryDataSuccess(List<ToDoTaskCategory> data)
        {
            this.Categories = data;
            this.IsLoading = false;
            this.IsError = false;

            this.StateHasChanged();
        }
        protected override void LoadDataCategoryFail(Exception exception)
        {
            this.Categories = null;
            this.IsError = true;
        }
        protected override async Task TryLoadAsync(Action<List<ToDoTaskCategory>> success, Action<Exception> fail)
        {
            List<ToDoTaskCategory> data;

            try
            {
                data = await this.HttpToDoTaskCategoryService.GetEntitiesAsync();
                success(data);
            }
            catch(Exception ex)
            {

                fail(ex);
            }
            finally
            {
                this.IsLoading = false;
            }
        }
        protected override async Task GetEntityCategoryAsync() => await this.TryLoadAsync(this.LoadEntityCategoryDataSuccess, this.LoadDataCategoryFail);

        protected override async Task GetAsync(int id) => this.ToDoTaskDto = await this.HttpToDoTaskService.GetEntityByIdAsync(id: id);

        protected override string BackUrl => $"{ToDoTaskManagerPageRoute.S_ToDoTaskManagerAdminDetails}/{this.Id}";
        protected override void GoBack() => this.NavigationManager.NavigateTo(this.BackUrl);

        public void Dispose()
        {
            this.TaskService = null;
            this.HttpToDoTaskService = null;
            this.ToDoTaskDto = null;
            this.ToDoTaskDtos = null;
            this.HttpToDoTaskCategoryService = null;
            this.Categories = null;
            this.PagingResponse = null;
        }
    }
}

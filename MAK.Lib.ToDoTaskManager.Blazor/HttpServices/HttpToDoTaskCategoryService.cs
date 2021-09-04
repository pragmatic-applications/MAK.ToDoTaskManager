using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Constants;

using Domain;

namespace HttpServices
{
    public class HttpToDoTaskCategoryService : HttpEntityService<ToDoTaskCategory>
    {
        public HttpToDoTaskCategoryService(HttpClient httpClient) : base(httpClient)
        {
            httpClient.BaseAddress = DeployedState.IsDeployed ? new Uri(ApiUrl.ServerApiImageUrlDeployed) : new Uri(ApiUrl.ServerApiBase);

            this.HttpClient = httpClient;
            this.Url = ToDoTaskConstant.Url_S_Api_ToDoTaskCategories_S;
            this.UrlApiUploader = HttpConstant.Url_S_Api_Upload;
        }

        public async Task<List<ToDoTaskCategory>> GetEntitiesAsync() => await base.GetAsync();
        public async Task<ToDoTaskCategory> GetEntityByIdAsync(int id) => await this.GetAsync(id);
        public async Task AddEntityAsync(ToDoTaskCategory model) => await this.PostAsync(model);
        public async Task EditEntityAsync(int id, ToDoTaskCategory model) => await this.PutAsync(id, model);
        public async Task DeleteEntityAsync(int id) => await this.DeleteAsync(id);
    }
}

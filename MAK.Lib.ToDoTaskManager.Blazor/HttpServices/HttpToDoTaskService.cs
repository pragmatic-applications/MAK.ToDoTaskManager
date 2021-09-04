using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Constants;

using Domain;

using DTOs;

using PageFeatures;

namespace HttpServices
{
    public class HttpToDoTaskService : HttpEntityService<ToDoTaskDto>
    {
        public HttpToDoTaskService(HttpClient httpClient) : base(httpClient)
        {
            httpClient.BaseAddress = DeployedState.IsDeployed ? new Uri(ApiUrl.ServerApiImageUrlDeployed) : new Uri(ApiUrl.ServerApiBase);

            this.HttpClient = httpClient;
            this.Url = ToDoTaskConstant.Url_S_Api_ToDoTasks_S;
            this.UrlApiUploader = HttpConstant.Url_S_Api_Upload;
        }

        public async Task<PagingResponse<ToDoTaskDto>> GetEntitiesAsync(PagingEntity entityParameter) => await this.GetAsync(entityParameter: entityParameter);
        public async Task<List<ToDoTaskDto>> GetEntitiesAsync() => await this.GetAsync();
        public async Task<ToDoTaskDto> GetEntityByIdAsync(int id) => await this.GetAsync(id);
        public async Task PutEntityAsync(int id, ToDoTaskDto model) => await this.PutAsync(id, model);
        public async Task PostEntityAsync(ToDoTaskDto model) => await this.PostAsync(model);
        public async Task DeleteEntityAsync(int id) => await this.DeleteAsync(id);
    }
}

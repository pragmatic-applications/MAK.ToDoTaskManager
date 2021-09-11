using System.Collections.Generic;
using System.Threading.Tasks;

using DTOs;

using PageFeatures;

namespace Interfaces
{
    public interface IHttpToDoTaskService
    {
        Task DeleteEntityAsync(int id);
        Task<List<ToDoTaskDto>> GetEntitiesAsync();
        Task<PagingResponse<ToDoTaskDto>> GetEntitiesAsync(PagingEntity entityParameter);
        Task<ToDoTaskDto> GetEntityByIdAsync(int id);
        Task PostEntityAsync(ToDoTaskDto model);
        Task PutEntityAsync(int id, ToDoTaskDto model);
    }
}

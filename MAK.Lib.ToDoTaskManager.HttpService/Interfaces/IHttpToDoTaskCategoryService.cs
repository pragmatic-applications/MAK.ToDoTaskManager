using System.Collections.Generic;
using System.Threading.Tasks;

using Domain;

namespace Interfaces
{
    public interface IHttpToDoTaskCategoryService
    {
        Task AddEntityAsync(ToDoTaskCategory model);
        Task DeleteEntityAsync(int id);
        Task EditEntityAsync(int id, ToDoTaskCategory model);
        Task<List<ToDoTaskCategory>> GetEntitiesAsync();
        Task<ToDoTaskCategory> GetEntityByIdAsync(int id);
    }
}

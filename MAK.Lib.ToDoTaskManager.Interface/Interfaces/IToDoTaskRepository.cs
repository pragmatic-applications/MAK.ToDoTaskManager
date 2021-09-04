using System.Threading.Tasks;

using Domain;

namespace Interfaces
{
    public interface IToDoTaskRepository : IRepository<ToDoTask, int>, IPagedList<ToDoTask>
    {
        Task<ToDoTask> GetAsync(int id);
    }
}

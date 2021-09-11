using System.Threading.Tasks;

namespace Interfaces
{
    public interface IUnitOfWork
    {
        IToDoTaskRepository ToDoTaskRepository { get; }
        IToDoTaskCategoryRepository ToDoTaskCategoryRepository { get; }

        Task SaveChangesAsync();
    }
}

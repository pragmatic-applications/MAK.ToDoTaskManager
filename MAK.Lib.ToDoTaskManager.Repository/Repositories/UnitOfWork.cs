using System.Threading.Tasks;

using Database;

using Interfaces;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationDbContext applicationDbContext, IToDoTaskRepository toDoTaskRepository, IToDoTaskCategoryRepository toDoTaskCategoryRepository)
        {
            this.applicationDbContext = applicationDbContext;

            this.ToDoTaskRepository = toDoTaskRepository;
            this.ToDoTaskCategoryRepository = toDoTaskCategoryRepository;
        }

        private readonly ApplicationDbContext applicationDbContext;

        public IToDoTaskRepository ToDoTaskRepository { get; }
        public IToDoTaskCategoryRepository ToDoTaskCategoryRepository { get; }

        public async Task SaveChangesAsync() => await this.applicationDbContext.SaveChangesAsync();
    }
}

using Database;

using Domain;

using Interfaces;

namespace Repositories
{
    public class ToDoTaskCategoryRepository : Repository<ToDoTaskCategory, int>, IToDoTaskCategoryRepository
    {
        public ToDoTaskCategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}

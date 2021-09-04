using System;
using System.Threading.Tasks;

using Database;

using Domain;

using Extensions;

using Interfaces;

using Microsoft.EntityFrameworkCore;

using PageFeatures;

namespace Repositories
{
    public class ToDoTaskRepository : Repository<ToDoTask, int>, IToDoTaskRepository
    {
        public ToDoTaskRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<PagedList<ToDoTask>> GetPagedList(PagingEntity entityParameter)
        {
            var items = await this.ApplicationDbContext.ToDoTasks
            .Search(entityParameter.SearchTerm)
            .Sort(entityParameter.OrderBy)
            .ToListAsync();

            return PagedList<ToDoTask>.ToPagedList(items, entityParameter.PageNumber, entityParameter.PageSize);
        }

        public async Task<ToDoTask> GetAsync(int id) => await this.Get().Include(item => item.ToDoTaskCategory).FirstOrDefaultAsync(item => item.Id == id);
    }
}

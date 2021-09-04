using System.Linq;
using System.Linq.Dynamic.Core;

using Domain;

namespace Extensions
{
    public static class ToDoTaskSearcher
    {
        public static IQueryable<ToDoTask> Search(this IQueryable<ToDoTask> models, string searchTearm)
        {
            if(string.IsNullOrWhiteSpace(searchTearm))
            {
                return models;
            }

            var searchTermLowerCase = searchTearm.Trim().ToLower();

            return models.Where(e => e.Title.ToLower().Contains(searchTermLowerCase));
        }
    }
}

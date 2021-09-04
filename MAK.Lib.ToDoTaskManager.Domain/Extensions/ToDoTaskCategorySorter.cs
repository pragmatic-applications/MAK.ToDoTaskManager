using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

using Constants;

using Domain;

namespace Extensions
{
    public static class ToDoTaskCategorySorter
    {
        public static IQueryable<ToDoTaskCategory> Search(this IQueryable<ToDoTaskCategory> models, string searchTearm)
        {
            if(string.IsNullOrWhiteSpace(searchTearm))
            {
                return models;
            }

            var searchTermLowerCase = searchTearm.Trim().ToLower();

            return models.Where(m => m.Name.ToLower().Contains(searchTermLowerCase));
        }

        public static IQueryable<ToDoTaskCategory> Sort(this IQueryable<ToDoTaskCategory> models, string orderByQueryString)
        {
            if(string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return models.OrderBy(m => m.Name);
            }

            orderByQueryString = orderByQueryString.ToLower();

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(ToDoTaskCategory).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            var direction = string.Empty;
            var searchText = string.Empty;

            foreach(var param in orderParams)
            {
                if(string.IsNullOrWhiteSpace(param))
                {
                    continue;
                }

                searchText = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(searchText, StringComparison.InvariantCultureIgnoreCase));

                if(objectProperty == null)
                {
                    continue;
                }

                direction = param.EndsWith(StringData.Space_Desc) ? StringData.Descending : StringData.Ascending;

                orderQueryBuilder.Append($"{objectProperty.Name} {direction}, ");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            if(string.IsNullOrWhiteSpace(orderQuery))
            {
                return models.OrderBy(m => m.Name);
            }
            else if(direction == StringData.Descending)
            {
                return models.OrderByDescending(m => m.Name);
            }
            else
            {
                return models.OrderBy(m => m.Name);
            }
        }
    }
}

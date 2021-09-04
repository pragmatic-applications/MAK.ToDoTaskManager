using System.Collections.Generic;

using Interfaces;

namespace Domain
{
    public class ToDoTaskSelect : ISelect
    {
        public List<string> Options => new List<string>
        {
          { "Id" },
          { "Id DESC" },
          { "Title" },
          { "Title DESC" },
          { "Detail" },
          { "Detail DESC" },
          { "Complete" },
          { "Complete DESC" }
        };
        public List<string> OptionsDisplay => new List<string>
        {
          { "Id" },
          { "Id DESC" },
          { "Title" },
          { "Title DESC" },
          { "Detail" },
          { "Detail DESC" },
          { "Complete" },
          { "Complete DESC" }
        };
    }
}

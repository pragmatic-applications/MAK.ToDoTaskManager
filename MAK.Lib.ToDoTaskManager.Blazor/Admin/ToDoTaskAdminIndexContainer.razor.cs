using System.Collections.Generic;

using Constants;

using Domain;

using DTOs;

using Microsoft.AspNetCore.Components;

namespace MAK.Lib.ToDoTaskManager.Blazor.Admin
{
    public partial class ToDoTaskAdminIndexContainer : Component
    {
        [CascadingParameter(Name = nameof(CascadingData.ToDoTaskEntitiesParameterValue))]
        public List<ToDoTaskDto> EntitiesCascadingParameter { get; set; }

        private string GetState(ToDoTaskDto item) => item.Complete ? "Yes" : "No";
        private string GetId(ToDoTaskDto item) => item.Id < 10 ? $"0{item.Id}" : $"{item.Id}";
        private string GetLink(ToDoTaskDto item) => $"{ToDoTaskManagerPageRoute.S_ToDoTaskManagerAdminDetails}/{item.Id}";
    }
}

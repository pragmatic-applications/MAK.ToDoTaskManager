using System.Collections.Generic;

using Constants;

using Domain;

using DTOs;

using Microsoft.AspNetCore.Components;

namespace MAK.Lib.ToDoTaskManager.Blazor
{
    public partial class ToDoTaskIndexContainer : Component
    {
        [CascadingParameter(Name = nameof(CascadingDataValue.ToDoTaskEntitiesParameterValue))]
        public List<ToDoTaskDto> EntitiesCascadingParameter { get; set; }
        private string GetState(ToDoTaskDto item) => item.Complete ? "Yes" : "No";
        private string GetId(ToDoTaskDto item) => item.Id < 10 ? $"0{item.Id}" : $"{item.Id}";
        private string GetLink(ToDoTaskDto item) => $"{ToDoTaskManagerPageRoute.S_ToDoTaskManagerDetails}/{item.Id}";
    }
}

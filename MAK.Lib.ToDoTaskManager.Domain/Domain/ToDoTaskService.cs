using System.Collections.Generic;
using System.Linq;

using DTOs;

using Interfaces;

namespace Domain
{
    public class ToDoTaskService : ITaskService<ToDoTaskDto>
    {
        private readonly Stack<List<ToDoTaskDto>> undoStack = new();
        private readonly Stack<List<ToDoTaskDto>> redoStack = new();

        public List<ToDoTaskDto> Items => this.undoStack.Any() ? this.undoStack.Peek() : new();

        public void AddItem(ToDoTaskDto item)
        {
            var items = new List<ToDoTaskDto>(this.Items);
            items.Add(item);
            this.undoStack.Push(items);
        }
        public bool CanSave => !this.Items.Any();

        public bool CanRemove => this.Items.Any(item => item.Complete);
        public void RemoveDone()
        {
            if(this.CanRemove)
            {
                this.undoStack.Push(this.Items.Where(item => !item.Complete).ToList());
            }
        }
        public void Clear()
        {
            this.undoStack.Clear();
            this.redoStack.Clear();
        }

        public bool CanUndo => this.undoStack.Any();
        public void Undo()
        {
            if(this.CanUndo)
            {
                var item = this.undoStack.Pop();
                this.redoStack.Push(item);
            }
        }

        public bool CanRedo => this.redoStack.Any();
        public void Redo()
        {
            if(this.CanRedo)
            {
                var item = this.redoStack.Pop();
                this.undoStack.Push(item);
            }
        }
    }
}

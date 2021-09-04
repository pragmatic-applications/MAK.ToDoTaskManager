using System;
using System.Threading.Tasks;

using AppConfigSettings;

using Constants;

using DTOs;

using Extensions;

using Interfaces;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using PageFeatures;

namespace Controllers
{
    public class ToDoTasksController : ApiBaseController
    {
        public ToDoTasksController(AppSettings options, IUnitOfWork unitOfWork) : base(options, unitOfWork)
        {
        }

        // POST: api/ToDoTasks
        [HttpPost(Name = nameof(PostToDoTask))]
        public async Task<ActionResult<ToDoTaskDto>> PostToDoTask([FromBody] ToDoTaskDtoCreate model)
        {
            try
            {
                if(model == null)
                {
                    return this.BadRequest("Model is null");
                }

                var modelToCreate = model.Map();
                await this.UnitOfWork.ToDoTaskRepository.PostRangeAsync(modelToCreate);
                await this.UnitOfWork.SaveChangesAsync();

                var createdModel = modelToCreate.MapDefault();

                return this.CreatedAtAction(nameof(GetToDoTaskDetail), new { id = createdModel.Id }, createdModel);
            }
            catch(Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }

        // GET: api/ToDoTasks
        [HttpGet(Name = nameof(GetToDoTask))]
        public async Task<ActionResult<PagedList<ToDoTaskDto>>> GetToDoTask([FromQuery] PagingEntity entityParameter)
        {
            try
            {
                var items = await this.UnitOfWork.ToDoTaskRepository.GetPagedList(entityParameter);

                if(items is null)
                {
                    return this.NotFound();
                }

                this.Response.Headers.Add(HttpConstant.X_Pagination, JsonConvert.SerializeObject(items.PagerData));

                return this.Ok(items.Map());
            }
            catch(Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }

        // GET: api/ToDoTasks/{id}
        [HttpGet("{id}", Name = nameof(GetToDoTaskDetail))]
        public async Task<ActionResult<ToDoTaskDto>> GetToDoTaskDetail(int id)
        {
            try
            {
                var model = await this.UnitOfWork.ToDoTaskRepository.GetAsync(id);

                return model is null ? this.NotFound() : this.Ok(model.Map());
            }
            catch(Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/ToDoTasks/{id}
        [HttpPut("{id}", Name = nameof(PutToDoTask))]
        public async Task<ActionResult> PutToDoTask(int id, [FromBody] ToDoTaskDtoUpdate model)
        {
            try
            {
                if(model == null)
                {
                    return this.BadRequest("Model is null");
                }

                var modelToUpdate = await this.UnitOfWork.ToDoTaskRepository.FindAsync(id);

                if(modelToUpdate is null)
                {
                    return this.NotFound();
                }

                if(string.IsNullOrWhiteSpace(model.Title))
                {
                    model.Title = modelToUpdate.Title;
                }
                if(string.IsNullOrWhiteSpace(model.Detail))
                {
                    model.Detail = modelToUpdate.Detail;
                }
                if(string.IsNullOrWhiteSpace(model.Image))
                {
                    model.Image = modelToUpdate.Image;
                }
                if(model.Complete is null)
                {
                    model.Complete = modelToUpdate.Complete;
                }
                if(model.ToDoTaskCategoryId is null)
                {
                    model.ToDoTaskCategoryId = modelToUpdate.ToDoTaskCategoryId;
                }

                await this.UnitOfWork.ToDoTaskRepository.PutRangeAsync(model.Map(modelToUpdate));
                await this.UnitOfWork.SaveChangesAsync();

                return this.NoContent();
            }
            catch(Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/ToDoTasks/{id}
        [HttpDelete("{id}", Name = nameof(DeleteToDoTask))]
        public async Task<ActionResult> DeleteToDoTask(int id)
        {
            try
            {
                var modelToDelete = await this.UnitOfWork.ToDoTaskRepository.FindAsync(id);

                if(modelToDelete == null)
                {
                    return this.NotFound();
                }

                await this.UnitOfWork.ToDoTaskRepository.DeleteRangeAsync(modelToDelete);
                await this.UnitOfWork.SaveChangesAsync();

                return this.NoContent();
            }
            catch(Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }
    }
}

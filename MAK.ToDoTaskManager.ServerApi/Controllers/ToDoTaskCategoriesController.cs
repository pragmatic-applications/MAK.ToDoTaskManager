using System.Collections.Generic;
using System.Threading.Tasks;
using System;

using DTOs;

using Extensions;

using Interfaces;

using Microsoft.AspNetCore.Mvc;
using AppConfigSettings;

namespace Controllers
{
    public class ToDoTaskCategoriesController : ApiBaseController
    {
        public ToDoTaskCategoriesController(AppSettings options, IUnitOfWork unitOfWork) : base(options, unitOfWork)
        {
        }

        // POST: api/ToDoTaskCategories
        [HttpPost]
        public async Task<ActionResult<ToDoTaskCategoryDto>> Post([FromBody] ToDoTaskCategoryDtoCreate model)
        {
            try
            {
                if(model == null)
                {
                    return this.BadRequest("Model is null");
                }

                if(!this.ModelState.IsValid)
                {
                    return this.BadRequest("Invalid Model");
                }

                var modelToCreate = model.Map();
                await this.UnitOfWork.ToDoTaskCategoryRepository.PutRangeAsync(modelToCreate);
                await this.UnitOfWork.SaveChangesAsync();

                var createdModel = modelToCreate.Map();

                return this.CreatedAtAction(nameof(Get), new { id = createdModel.Id }, createdModel);
            }
            catch(Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }

        // GET: api/ToDoTaskCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoTaskCategoryDto>>> Get()
        {
            try
            {
                var models = await this.UnitOfWork.ToDoTaskCategoryRepository.GetAsync();

                return models is null ? this.NotFound() : this.Ok(models.MapList());

            }
            catch(Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }

        // GET: api/ToDoTaskCategories/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoTaskCategoryDto>> Get(int id)
        {
            try
            {
                var model = await this.UnitOfWork.ToDoTaskCategoryRepository.FindAsync(id);

                return model is null ? this.NotFound() : this.Ok(model.Map());
            }
            catch(Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/ToDoTaskCategories/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ToDoTaskCategoryDtoUpdate model)
        {
            try
            {
                if(model == null)
                {
                    return this.BadRequest("Model is null");
                }

                if(!this.ModelState.IsValid)
                {
                    return this.BadRequest("Invalid Model");
                }

                var modelToUpdate = await this.UnitOfWork.ToDoTaskCategoryRepository.FindAsync(id);

                if(modelToUpdate is null)
                {
                    return this.NotFound();
                }

                if(string.IsNullOrWhiteSpace(model.Name))
                {
                    model.Name = modelToUpdate.Name;
                }

                await this.UnitOfWork.ToDoTaskCategoryRepository.PutRangeAsync(model.Map(modelToUpdate));
                await this.UnitOfWork.SaveChangesAsync();

                return this.NoContent();
            }
            catch(Exception)
            {
                return this.StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/ToDoTaskCategories/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var modelToDelete = await this.UnitOfWork.ToDoTaskCategoryRepository.FindAsync(id);

                if(modelToDelete == null)
                {
                    return this.NotFound();
                }

                await this.UnitOfWork.ToDoTaskCategoryRepository.DeleteRangeAsync(modelToDelete);
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

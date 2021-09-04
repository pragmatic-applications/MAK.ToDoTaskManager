using System.Threading.Tasks;

using AppConfigSettings;

using Interfaces;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public class ItemUploaderController : UploadBaseController
    {
        public ItemUploaderController(IWebHostEnvironment webHostEnvironment, AppSettings options, IUnitOfWork unitOfWork) : base(webHostEnvironment, options, unitOfWork)
        {
        }

        // PUT: api/Items/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id)
        {
            var Image = await this.UploadFile(id: id);

            return this.NoContent();
        }
    }
}

using System;
using System.IO;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        public UploadController(IWebHostEnvironment webHostEnvironment) => this.WebHostEnvironment = webHostEnvironment;

        protected IWebHostEnvironment WebHostEnvironment { get; }

        [HttpPost]
        public IActionResult Upload()
        {
            try
            {
                var file = this.Request.Form.Files[0];
                var folderName = Path.Combine("Images", "UploadFiles");
                var pathToSave = Path.Combine(this.WebHostEnvironment.WebRootPath, folderName);

                if(file.Length > 0)
                {
                    var fileName = $"Img_{Guid.NewGuid()}_" + file.FileName;

                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using(var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    return this.Ok(dbPath);
                }
                else
                {
                    return this.BadRequest();
                }
            }
            catch(Exception ex)
            {
                return this.StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }

}

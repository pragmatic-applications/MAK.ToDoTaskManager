using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using AppConfigSettings;

using Constants;

using Domain;

using Interfaces;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    public abstract class UploadBaseController : ApiBaseController
    {
        protected UploadBaseController(IWebHostEnvironment webHostEnvironment, AppSettings options, IUnitOfWork unitOfWork) : base(options, unitOfWork) => this.WebHostEnvironment = webHostEnvironment;

        protected IWebHostEnvironment WebHostEnvironment { get; }

        protected async Task<string> UploadFile(int id)
        {
            var image = "Default.png";

            if(this.HttpContext.Request.Form.Files.Any())
            {
                foreach(var file in this.HttpContext.Request.Form.Files)
                {
                    var uploadsDir = Path.Combine(this.WebHostEnvironment.WebRootPath, HttpConstant.Url_Images_UploadFiles);
                    image = id.ToString() + "_" + file.FileName + DateTime.UtcNow.ToString();
                    var filePath = Path.Combine(uploadsDir, image);

                    using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                    await file.CopyToAsync(fileStream);
                    fileStream.Close();
                }
            }

            return image;
        }

        protected async Task PostEntity([FromBody] ImageFile[] files, string fileNameStart)
        {
            var imageName = HttpConstant.DefaultImage;

            foreach(var file in files)
            {
                var buf = Convert.FromBase64String(file.Base64Data);
                var uploadsDir = Path.Combine(this.WebHostEnvironment.WebRootPath, HttpConstant.Url_Images_UploadFiles);
                imageName = fileNameStart + file.FileName;
                var filePath = Path.Combine(uploadsDir, imageName);
                await System.IO.File.WriteAllBytesAsync(filePath, buf);
            }
        }
    }
}

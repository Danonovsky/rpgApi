using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg.Common.Services
{
    public interface IFileService
    {
        public Task<string> Upload();
    }
    public class FileService : IFileService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FileService(
            IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> Upload()
        {
            try
            {
                var file = _httpContextAccessor.HttpContext.Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = Guid.NewGuid() + "." + file.FileName.Split(".").Last();
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var fs = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fs);
                    }
                    return dbPath;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

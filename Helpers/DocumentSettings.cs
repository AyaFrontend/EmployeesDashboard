using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesDashboard.Helpers
{
    public static class DocumentSettings
    {
        public static string SettingUploadFiles(IFormFile file, string FolderName)
        {
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files" , FolderName);
            var fileName = $"{Guid.NewGuid()}{Path.GetFileName(file.FileName)}";

            var filePath = Path.Combine(folderPath, fileName);
            using var fileStream = new FileStream(filePath , FileMode.Create);
            file.CopyTo(fileStream);
         
            return fileName;
   
        }

        public static void DeleteFile(string fileName , string FolderName)
        {

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files", FolderName);
            var filePath = Path.Combine(folderPath, fileName);

              if(File.Exists(filePath))
              {
                File.Delete(filePath);
              }

        }

      
    }
}

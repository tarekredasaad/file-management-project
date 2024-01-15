using Microsoft.AspNetCore.Http;

namespace Modules.ECommerce.Application.Helper
{
    public static class FileHelper
    {
         public static  string fileName;

        public static string UploadImg(IFormFile file,string FolderName)
        {
            string FolderPathe = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", FolderName);

            string FileName = $"{Guid.NewGuid()}{Path.GetFileName(file.FileName)}";

            string FilePath=Path.Combine(FolderPathe,FileName);

            fileName = FileName;
            using FileStream FS = new FileStream(FilePath,FileMode.Create);
            
            file.CopyTo(FS);

            return FolderPathe;

        }

        //public static string fileName()
        //{

        //}
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Domain.Interfaces
{
    public interface IFileService
    {
        Task<string> SaveFileAsync (Stream fileStream, string fileName, string folderName);
        void DeleteFile (string path);
    }
}

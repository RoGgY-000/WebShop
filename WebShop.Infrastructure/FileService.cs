using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using WebShop.Domain.Interfaces;

namespace WebShop.Infrastructure
{
    public class FileService (IWebHostEnvironment env) : IFileService
    {
        public async Task<string> SaveFileAsync (Stream fileStream, string fileName, string folderName)
        {
            // Создаем уникальное имя: Guid + расширение
            string uniqueName = $"{Guid.NewGuid()}{Path.GetExtension(fileName)}";
            string relativePath = Path.Combine("uploads", folderName, uniqueName);
            string fullPath = Path.Combine(env.WebRootPath, relativePath);

            // Создаем папку, если её нет
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);

            using FileStream targetStream = new(fullPath, FileMode.Create);
            await fileStream.CopyToAsync(targetStream);

            return relativePath.Replace("\\", "/"); // Для URL всегда используем "/"
        }

        public void DeleteFile (string path)
        {
            string fullPath = Path.Combine(env.WebRootPath, path);
            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }
    }
}
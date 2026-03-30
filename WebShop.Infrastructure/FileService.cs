using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using WebShop.Application.Services;
using WebShop.Domain.Entities;

namespace WebShop.Infrastructure
{
    public class FileService (IWebHostEnvironment env) : IFileService
    {
        public async Task<string> SaveFileAsync (IFormFile file, ProductImage productImage)
        {
            string fileName = $"{productImage.Id}{Path.GetExtension(file.FileName)}";
            string folderPath = Path.Combine(env.WebRootPath, $"products/{productImage.ProductId}/images");

            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, fileName);
            using FileStream stream = new(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            stream.Close();

            return fileName.Replace("\\", "/");
        }

        public void DeleteFile (string path)
        {
            string fullPath = Path.Combine(env.WebRootPath, path);
            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }
    }
}
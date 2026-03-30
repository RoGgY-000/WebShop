using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using WebShop.Domain.Entities;

namespace WebShop.Application.Services
{
    public interface IFileService
    {
        Task<string> SaveFileAsync (IFormFile file, ProductImage productImage);
        void DeleteFile (string path);
    }
}

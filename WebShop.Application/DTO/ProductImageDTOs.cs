using System;
using System.Collections.Generic;
using System.Text;

namespace WebShop.Application.DTO
{
    public record CreateProductImageRequest (Guid ProductId, string FilePath, int SortingIndex);
    public record GetProductImageRequest (int Id);
    public record ProductImageResponse (int Id, Guid ProductId, string FilePath, int SortingIndex);
}

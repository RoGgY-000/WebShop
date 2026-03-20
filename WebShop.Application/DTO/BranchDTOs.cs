namespace WebShop.Application.DTO
{
    public record CreateBranchRequest (string Name, string Address);
    public record BranchResponse (int Id, string Name, string Address);
}
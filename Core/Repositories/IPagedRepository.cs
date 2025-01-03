namespace JobBank.Core.Repositories;

public interface IPagedRespository<Model>
{
    PagedResult<Model> FindAll(PaginationOptions options);
}
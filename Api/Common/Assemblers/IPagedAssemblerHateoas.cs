using JobBank.Api.Jobs.Common;
using JobBank.Api.Jobs.Dtos;

namespace JobBank.Api.Common.Assemblers;

public interface IPagedAssemblerHateoas<R> where R : ResourceResponseHateoas
{
    PagedResponse<R> ToPagedResource(PagedResponse<R> pagedResource, HttpContext context);
}
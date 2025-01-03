using JobBank.Api.Jobs.Common;

namespace JobBank.Api.Common.Assemblers;

public interface IAssemblerHateoas<T> where T : ResourceResponseHateoas
{
    T ToResourceResponseHetoas(T resource, HttpContext context);

    ICollection<T> ToResourceCollection(ICollection<T> resources, HttpContext context)
    {
        return resources.Select(r => ToResourceResponseHetoas(r, context)).ToList();
    }
}
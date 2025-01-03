using JobBank.Api.Common.Assemblers;
using JobBank.Api.Jobs.Common;
using JobBank.Api.Jobs.Dtos;

namespace JobBank.Api.Jobs.Assemblers;

public class JobSummaryPagedAssemblerHeteoas : IPagedAssemblerHateoas<JobSummaryResponse>
{

    private readonly LinkGenerator _linkGenerator;
    private readonly IAssemblerHetoas<JobSummaryResponse> _jobSummaryAssemblerHetoas;

    public JobSummaryPagedAssemblerHeteoas(LinkGenerator linkGenerator, IAssemblerHetoas<JobSummaryResponse> jobSummaryAssemblerHetoas)
    {
        _linkGenerator = linkGenerator;
        _jobSummaryAssemblerHetoas = jobSummaryAssemblerHetoas;
    }


    public PagedResponse<JobSummaryResponse> ToPagedResource(PagedResponse<JobSummaryResponse> pagedResource, HttpContext context)
    {
        // Montando os links internos
        pagedResource.Items = _jobSummaryAssemblerHetoas.ToResourceCollection(pagedResource.Items, context);
        
        // Montando os links da própria paginação
        var firstPageLink = new LinkResponseHetoas(
            _linkGenerator.GetUriByName(context, "FindAllJobs", new { page = pagedResource.FirstPage, size = pagedResource.PageSize }),
            "GET",
            "firstPage"
        );
        var lastPageLink = new LinkResponseHetoas(
            _linkGenerator.GetUriByName(context, "FindAllJobs", new { page = pagedResource.LastPage, size = pagedResource.PageSize }),
            "GET",
            "lastPage"
        );
        var nextPageLink = new LinkResponseHetoas(
            _linkGenerator.GetUriByName(context, "FindAllJobs", new { page = pagedResource.PageNumber + 1, size = pagedResource.PageSize }),
            "GET",
            "nextPage"
        );
        var previousPageLink = new LinkResponseHetoas(
            _linkGenerator.GetUriByName(context, "FindAllJobs", new { page = pagedResource.PageNumber - 1, size = pagedResource.PageSize }),
            "GET",
            "previousPage"
        );

        pagedResource.AddLinks(firstPageLink, lastPageLink);
        // Adicionando os links de next e previous apenas se existirem
        pagedResource.AddLinkIf(pagedResource.HasNextPage, nextPageLink);
        pagedResource.AddLinkIf(pagedResource.HasPreviousPage, previousPageLink);
        return pagedResource;
    }
}
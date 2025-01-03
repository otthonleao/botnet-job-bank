using JobBank.Api.Common.Assemblers;
using JobBank.Api.Jobs.Common;
using JobBank.Api.Jobs.Dtos;

namespace JobBank.Api.Jobs.Assemblers;

public class JobSummaryAssemblerHateoas : IAssemblerHateoas<JobSummaryResponse>
{
    private readonly LinkGenerator _linkGenerator;

    public JobSummaryAssemblerHateoas(LinkGenerator linkGenerator)
    {
        _linkGenerator = linkGenerator;
    }

    public JobSummaryResponse ToResourceResponseHetoas(JobSummaryResponse resource, HttpContext context)
    {
        var selfLink = new LinkResponseHateoas(
            _linkGenerator.GetUriByName(context, "FindJobById", new { Id = resource.Id }),
            "GET", 
            "self"
        );
        var updateLink = new LinkResponseHateoas(
            _linkGenerator.GetUriByName(context, "UpdateJob", new { Id = resource.Id }),
            "PUT",
            "update");
        var deleteLink = new LinkResponseHateoas(
            _linkGenerator.GetUriByName(context, "DeleteJob", new { Id = resource.Id }),
            "DELETE", 
            "delete");
        resource.AddLinks(selfLink, updateLink, deleteLink);
        return resource;
    }
}
using JobBank.Api.Jobs.Common;
using JobBank.Api.Jobs.Dtos;
using JobBank.Api.Jobs.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobBank.Api.Jobs.Controllers;

[ApiController]
[Route("api/jobs")]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;
    private readonly LinkGenerator _linkGenerator;

    public JobController(IJobService jobService, LinkGenerator linkGenerator)
    {
        _jobService = jobService;
        _linkGenerator = linkGenerator;
    }
    
    [HttpGet(Name = "FindAllJobs")]
    public IActionResult FindAll()
    {
        // return Ok(_jobService.FindAll());
        var body = _jobService.FindAll();
        foreach (var resource in body)
        {
            var selfLink = new LinkResponseHetoas(
                _linkGenerator.GetUriByName(HttpContext, "FindJobById", new { Id = resource.Id }),
                "GET", 
                "self"
                );
            var updateLink = new LinkResponseHetoas(
                _linkGenerator.GetUriByName(HttpContext, "UpdateJob", new { Id = resource.Id }),
                "PUT",
                "update");
            var deleteLink = new LinkResponseHetoas(
                _linkGenerator.GetUriByName(HttpContext, "DeleteJob", new { Id = resource.Id }),
                "DELETE", 
                "delete");
            resource.AddLinks(selfLink, updateLink, deleteLink);
        }
        return Ok(body);
    }
    
    [HttpGet("{id}", Name = "FindJobById")]
    public IActionResult FindById([FromRoute] int id)
    {
        // return Ok(_jobService.FindById(id));
        var body = _jobService.FindById(id);
        body.AddLink(new LinkResponseHetoas($"/api/jobs/{body.Id}", "GET", "self"));
        body.AddLink(new LinkResponseHetoas($"/api/jobs/{body.Id}", "PUT", "update"));
        body.AddLink(new LinkResponseHetoas($"/api/jobs/{body.Id}", "DELETE", "delete"));
        return Ok(body);
    }
    
    [HttpPost(Name = "CreateJob")]
    public IActionResult Create([FromBody] JobRequest jobRequest)
    {
        // return Created($"/api/jobs/{body.Id}", _jobService.Create(jobRequest));
        var body = _jobService.Create(jobRequest);
        body.AddLink(new LinkResponseHetoas($"/api/jobs/{body.Id}", "GET", "self"));
        body.AddLink(new LinkResponseHetoas($"/api/jobs/{body.Id}", "PUT", "update"));
        body.AddLink(new LinkResponseHetoas($"/api/jobs/{body.Id}", "DELETE", "delete"));
        return CreatedAtAction(nameof(FindById), new { id = body.Id }, body);
    }
    
    [HttpPut("{id}", Name = "UpdateJob")]
    public IActionResult Update([FromRoute] int id, [FromBody] JobRequest jobRequest)
    {
        // return Ok(_jobService.Update(id, jobRequest));
        var body = _jobService.Update(id, jobRequest);
        body.AddLink(new LinkResponseHetoas($"/api/jobs/{body.Id}", "GET", "self"));
        body.AddLink(new LinkResponseHetoas($"/api/jobs/{body.Id}", "PUT", "update"));
        body.AddLink(new LinkResponseHetoas($"/api/jobs/{body.Id}", "DELETE", "delete"));
        return Ok(body);
    }
    
    [HttpDelete("{id}", Name = "DeleteJob")]
    public IActionResult Delete([FromRoute] int id)
    {
        _jobService.Delete(id);
        return NoContent();
    }
}
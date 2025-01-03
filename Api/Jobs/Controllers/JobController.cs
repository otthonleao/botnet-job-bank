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

    public JobController(IJobService jobService)
    {
        _jobService = jobService;
    }
    
    [HttpGet]
    public IActionResult FindAll()
    {
        // return Ok(_jobService.FindAll());
        var body = _jobService.FindAll();
        foreach (var resource in body)
        {
            var selfLink = new LinkResponseHetoas($"/api/jobs/{resource.Id}", "GET", "self");
            var updateLink = new LinkResponseHetoas($"/api/jobs/{resource.Id}", "PUT", "update");
            var deleteLink = new LinkResponseHetoas($"/api/jobs/{resource.Id}", "DELETE", "delete");
            resource.AddLinks(selfLink, updateLink, deleteLink);
        }
        return Ok(body);
    }
    
    [HttpGet("{id}")]
    public IActionResult FindById([FromRoute] int id)
    {
        // return Ok(_jobService.FindById(id));
        var body = _jobService.FindById(id);
        body.AddLink(new LinkResponseHetoas($"/api/jobs/{body.Id}", "GET", "self"));
        body.AddLink(new LinkResponseHetoas($"/api/jobs/{body.Id}", "PUT", "update"));
        body.AddLink(new LinkResponseHetoas($"/api/jobs/{body.Id}", "DELETE", "delete"));
        return Ok(body);
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] JobRequest jobRequest)
    {
        // return Created($"/api/jobs/{body.Id}", _jobService.Create(jobRequest));
        var body = _jobService.Create(jobRequest);
        body.AddLink(new LinkResponseHetoas($"/api/jobs/{body.Id}", "GET", "self"));
        body.AddLink(new LinkResponseHetoas($"/api/jobs/{body.Id}", "PUT", "update"));
        body.AddLink(new LinkResponseHetoas($"/api/jobs/{body.Id}", "DELETE", "delete"));
        return CreatedAtAction(nameof(FindById), new { id = body.Id }, body);
    }
    
    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] JobRequest jobRequest)
    {
        // return Ok(_jobService.Update(id, jobRequest));
        var body = _jobService.Update(id, jobRequest);
        body.AddLink(new LinkResponseHetoas($"/api/jobs/{body.Id}", "GET", "self"));
        body.AddLink(new LinkResponseHetoas($"/api/jobs/{body.Id}", "PUT", "update"));
        body.AddLink(new LinkResponseHetoas($"/api/jobs/{body.Id}", "DELETE", "delete"));
        return Ok(body);
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        _jobService.Delete(id);
        return NoContent();
    }
}
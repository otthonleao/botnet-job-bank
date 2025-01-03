using JobBank.Api.Jobs.Services;
using JobBank.Core.Models;
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
        return Ok(_jobService.FindAll());
    }
    
    [HttpGet("{id}")]
    public IActionResult FindById([FromRoute] int id)
    {
        return Ok(_jobService.FindById(id));
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] Job job)
    {
        var body = _jobService.Create(job);
        // return Created($"/api/jobs/{body.Id}", _jobService.Create(job));
        return CreatedAtAction(nameof(FindById), new { id = body.Id }, body);
    }
    
    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Job job)
    {
        return Ok(_jobService.Update(id, job));
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        _jobService.Delete(id);
        return NoContent();
    }
}
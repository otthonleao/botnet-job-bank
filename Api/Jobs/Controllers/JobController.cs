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
        return Ok(_jobService.FindAll());
    }
    
    [HttpGet("{id}")]
    public IActionResult FindById([FromRoute] int id)
    {
        return Ok(_jobService.FindById(id));
    }
    
    [HttpPost]
    public IActionResult Create([FromBody] JobRequest jobRequest)
    {
        var body = _jobService.Create(jobRequest);
        // return Created($"/api/jobs/{body.Id}", _jobService.Create(jobRequest));
        return CreatedAtAction(nameof(FindById), new { id = body.Id }, body);
    }
    
    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] JobRequest jobRequest)
    {
        return Ok(_jobService.Update(id, jobRequest));
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        _jobService.Delete(id);
        return NoContent();
    }
}
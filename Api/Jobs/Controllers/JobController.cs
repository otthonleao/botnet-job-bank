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
}
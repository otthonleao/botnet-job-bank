using JobBank.Api.Common.Assemblers;
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
    private readonly IAssemblerHateoas<JobSummaryResponse> _jobSummaryAssemblerHateoas;
    private readonly IAssemblerHateoas<JobDetailResponse> _jobDetailAssemblerHateoas;

    public JobController(IJobService jobService, IAssemblerHateoas<JobSummaryResponse> jobSummaryAssemblerHateoas, IAssemblerHateoas<JobDetailResponse> jobDetailAssemblerHateoas)
    {
        _jobService = jobService;
        _jobSummaryAssemblerHateoas = jobSummaryAssemblerHateoas;
        _jobDetailAssemblerHateoas = jobDetailAssemblerHateoas;
    }
    
    [HttpGet(Name = "FindAllJobs")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<JobSummaryResponse>))]
    public IActionResult FindAll([FromQuery] int page, [FromQuery] int size)
    {
        // return Ok(_jobService.FindAll());
        var body = _jobService.FindAll(page, size);
        body.Items = _jobSummaryAssemblerHateoas.ToResourceCollection(body.Items, HttpContext);
        return Ok(body);
    }
    
    [HttpGet("{id}", Name = "FindJobById")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JobDetailResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
    public IActionResult FindById([FromRoute] int id)
    {
        // return Ok(_jobService.FindById(id));
        var body = _jobService.FindById(id);
        return Ok(_jobDetailAssemblerHateoas.ToResourceResponseHetoas(body, HttpContext));
    }
    
    [HttpPost(Name = "CreateJob")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(JobDetailResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationErrorResponse))]
    public IActionResult Create([FromBody] JobRequest jobRequest)
    {
        // return Created($"/api/jobs/{body.Id}", _jobService.Create(jobRequest));
        var body = _jobService.Create(jobRequest);
        return CreatedAtAction(
            nameof(FindById),
            new { id = body.Id },
            _jobDetailAssemblerHateoas.ToResourceResponseHetoas(body, HttpContext)
        );
    }
    
    [HttpPut("{id}", Name = "UpdateJob")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JobDetailResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationErrorResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
    public IActionResult Update([FromRoute] int id, [FromBody] JobRequest jobRequest)
    {
        // return Ok(_jobService.Update(id, jobRequest));
        var body = _jobService.Update(id, jobRequest);
        return Ok(_jobDetailAssemblerHateoas.ToResourceResponseHetoas(body, HttpContext));
    }
    
    [HttpDelete("{id}", Name = "DeleteJob")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorResponse))]
    public IActionResult Delete([FromRoute] int id)
    {
        _jobService.Delete(id);
        return NoContent();
    }
}
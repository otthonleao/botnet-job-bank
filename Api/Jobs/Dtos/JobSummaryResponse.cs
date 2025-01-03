using JobBank.Api.Jobs.Common;

namespace JobBank.Api.Jobs.Dtos;

public class JobSummaryResponse : ResourceResponseHetoas
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
}
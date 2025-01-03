using JobBank.Api.Jobs.Common;

namespace JobBank.Api.Jobs.Dtos;

public class JobDetailResponse : ResourceResponseHetoas
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public ICollection<string> Requirements { get; set; } = new List<string>();
    // public ICollection<LinkResponseHetoas> Links { get; set; } = new List<LinkResponseHetoas>();
}
namespace JobBank.Api.Jobs.Dtos;

public class JobDetailResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public ICollection<string> Requirements { get; set; } = new List<string>();
}
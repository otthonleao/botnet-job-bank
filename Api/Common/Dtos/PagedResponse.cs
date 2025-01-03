using System.Text.Json.Serialization;
using JobBank.Api.Jobs.Common;

namespace JobBank.Api.Jobs.Dtos;

public class PagedResponse<R> : ResourceResponseHetoas
{
    public ICollection<R> Items { get; set; } = new List<R>();
    [JsonIgnore]
    public int PageNumber { get; set; }
    [JsonIgnore]
    public int PageSize { get; set; }
    [JsonIgnore]
    public int FirstPage { get; set; }
    [JsonIgnore]
    public int LastPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalElements { get; set; }
    [JsonIgnore]
    public bool HasPreviousPage { get; set; }
    [JsonIgnore]
    public bool HasNextPage { get; set; }
}
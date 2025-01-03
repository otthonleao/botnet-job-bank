namespace JobBank.Api.Jobs.Common;

public class LinkResponseHetoas
{
    public string? Href { get; set; }
    public string Type { get; set; }
    public string Rel { get; set; }
    
    public LinkResponseHetoas(string href, string type, string rel)
    {
        Href = href;
        Type = type;
        Rel = rel;
    }
}
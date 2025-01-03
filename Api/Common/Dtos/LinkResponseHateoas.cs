namespace JobBank.Api.Jobs.Common;

public class LinkResponseHateoas
{
    public string? Href { get; set; }
    public string Type { get; set; }
    public string Rel { get; set; }
    
    public LinkResponseHateoas(string? href, string type, string rel)
    {
        Href = href;
        Type = type;
        Rel = rel;
    }
}
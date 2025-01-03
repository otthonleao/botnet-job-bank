namespace JobBank.Api.Jobs.Common;

public class ResourceResponseHateoas
{
    public ICollection<LinkResponseHateoas> Links { get; set; } = new List<LinkResponseHateoas>();

    public void AddLink(LinkResponseHateoas link)
    {
        Links.Add(link);
    }
    
    public void AddLinks(params LinkResponseHateoas[] links)
    {
        foreach (var link in links)
        {
            Links.Add(link);
        }
    }
    
    public void AddLinkIf(bool condition, LinkResponseHateoas link)
    {
        if (condition)
        {
            Links.Add(link);
        }
    }
}
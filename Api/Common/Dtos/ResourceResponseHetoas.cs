namespace JobBank.Api.Jobs.Common;

public class ResourceResponseHetoas
{
    public ICollection<LinkResponseHetoas> Links { get; set; } = new List<LinkResponseHetoas>();

    public void AddLink(LinkResponseHetoas link)
    {
        Links.Add(link);
    }
    
    public void AddLinks(params LinkResponseHetoas[] links)
    {
        foreach (var link in links)
        {
            Links.Add(link);
        }
    }
}
public class MediumPost
{
    public string Id { set; get; }
    public DateTime LastUpdatedTimeUtc { set; get; }
    public IEnumerable<string> Categories { set; get; }
    public string Uri { set; get; }
    public DateTime PublishDateUtc { set; get; }
    public string Summary { set; get; }
    public string Title { set; get; }
}
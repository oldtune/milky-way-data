using System.ServiceModel.Syndication;

public static class MediumSyndicationPostMapping
{
    public static MediumPost Map(SyndicationItem item)
    {
        return new MediumPost
        {
            Categories = item.Categories.Select(x => x.Name),
            Id = item.Id,
            LastUpdatedTimeUtc = item.LastUpdatedTime.UtcDateTime,
            PublishDateUtc = item.PublishDate.UtcDateTime,
            Summary = item.Summary.Text,
            Title = item.Title.Text,
            Uri = item.Links.FirstOrDefault()?.Uri.ToString(),
        };
    }
}
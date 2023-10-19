using System.ServiceModel.Syndication;
using System.Xml;
using Microsoft.Extensions.Logging;

public interface IMediumFetcher
{
    Task<IEnumerable<SyndicationItem>> FetchPosts(string username);
}

public class MediumFetcher
{
    private readonly ILogger _logger;

    public MediumFetcher(ILogger logger)
    {
        _logger = logger;
    }

    public async Task<List<MediumPost>> FetchPosts(string username)
    {
        try
        {
            var url = $"https://medium.com/feed/@{username}";
            using var reader = XmlReader.Create(url);
            var feed = SyndicationFeed.Load(reader);
            var items = feed.Items;
            return items.Select(x => MediumSyndicationPostMapping.Map(x)).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error fetching medium feed: {ex.Message}");
            throw;
        }
    }
}
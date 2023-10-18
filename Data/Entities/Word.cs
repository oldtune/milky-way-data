using Data.Repositories;

namespace Data.Entities;
public class WordRecord : IDatabaseObject
{
    public string Word { set; get; }
    //Should be crawled from Dictionary.cabridge
    public string EnUkPronounce { set; get; }
    //Should be crawled from Dictionary.cabridge
    public string EnUsPronounce { set; get; }
    //Should be crawled from tratu.coviet
    public string ViPronounce { set; get; }
    public ICollection<WordTypeLink> WordTypeLinks { set; get; }

    public string TableName => "Word";
}
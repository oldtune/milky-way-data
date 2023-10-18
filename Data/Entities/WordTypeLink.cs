namespace Data.Entities;
public class WordTypeLink
{
    public int Id { set; get; }
    public string Word { set; get; }
    public int WordTypeId { set; get; }
    public WordRecord WordRecord { set; get; }
    public WordType WordType { set; get; }

    public ICollection<WordMeaning> WordMeanings { set; get; }
}
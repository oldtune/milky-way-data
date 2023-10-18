namespace Data.Entities;
public class WordMeaning
{
    public int Id { set; get; }
    public int WordTypeLinkId { set; get; }
    //vi meaning
    public string ViMeaning { set; get; }
    //en meaning
    public string EnMeaning { set; get; }

    public WordTypeLink WordTypeLink { set; get; }
    public ICollection<Example> Examples { set; get; }
}
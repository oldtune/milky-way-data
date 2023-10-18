namespace Data.Entities;
public class WordType
{
    public int Id { set; get; }
    //word type in Vi, for example: Tinh tu
    public string Vi { set; get; }
    //word type in En, for example: Verb
    public string En { set; get; }
    public ICollection<WordTypeLink> WordTypeLinks { set; get; }
}
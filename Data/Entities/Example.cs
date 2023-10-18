namespace Data.Entities;
public class Example
{
    public int Id { set; get; }
    public int WordMeaningId { set; get; }
    //example
    public string EnExample { set; get; }
    //meaning
    public string ViMeaning { set; get; }

    public WordMeaning WordMeaning { set; get; }
}
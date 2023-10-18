namespace QuackQuack;
public class WordResponse
{
    public string Word { set; get; }
    public string PronounceEn { set; get; }
    public string PronounceUk { set; get; }
    public string PronounceVi { set; get; }
    public string AudioEnUrl { set; get; }
    public string AudioUkUrl { set; get; }
    public string AudioVi { set; get; }

    public IEnumerable<WordTypeResponse> WordTypes { set; get; }
}

public class WordTypeResponse
{
    public string WordTypeVi { set; get; }
    public string WordTypeEn { set; get; }
    public IEnumerable<WordMeaningResponse> Meanings { set; get; }
}

public class WordMeaningResponse
{
    public string MeaningEn { set; get; }
    public string? MeaningVi { set; get; }
    public IEnumerable<ExampleResponse> Examples { set; get; }
}

public class ExampleResponse
{
    public string Example { set; get; }
    public string EnMeaning { set; get; }
    public string ViMeaning { set; get; }
}
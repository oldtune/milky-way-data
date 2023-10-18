using Newtonsoft.Json;

public class CustomJsonConvert
{
    public static string Serialize<T>(T obj)
    {
        return JsonConvert.SerializeObject(obj);
    }

    public static T Deserialize<T>(string jsonString)
    {
        return JsonConvert.DeserializeObject<T>(jsonString);
    }
}
using Newtonsoft.Json;

class Exibitions{

    public static Dictionary<string, List<Exibition>> ToObject(){
        string text = File.ReadAllText(@"./exibitions.json");
        var exibition = JsonConvert.DeserializeObject<Dictionary<string, List<Exibition>>>(text);
        return exibition; 
    }
    
}
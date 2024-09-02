using Newtonsoft.Json;

class Groups{

    public static Dictionary<string, List<Group>> ToObject(){
        string text = File.ReadAllText(@"./groups.json");
        var group = JsonConvert.DeserializeObject<Dictionary<string, List<Group>>>(text);
        return group;
    }
}
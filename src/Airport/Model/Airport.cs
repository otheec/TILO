using Newtonsoft.Json;

namespace Airport.Model;
public class Airport
{
    [JsonProperty("code")]
    public string Name { get; set; }

    [JsonProperty("name")]
    public string Code { get; set; }

    [JsonProperty("connections")]
    public List<Connection> Connections { get; set; }
}

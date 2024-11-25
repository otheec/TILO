using Newtonsoft.Json;

namespace Airport.Model;
public class Distance
{
    [JsonProperty("value")]
    public double Value { get; set; }

    [JsonProperty("unit")]
    public string Unit { get; set; }
}

using Newtonsoft.Json;

namespace Airport.Model;
public class Connection
{
    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("distance")]
    public Distance Distance { get; set; }
}


using System.Text.Json.Serialization;

namespace CountriesMemoryCacheApi.Models;

public class Countrie
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("topLevelDomain")]
    public string[] TopLevelDomain { get; set; }

    [JsonPropertyName("alpha2Code")]
    public string Alpha2Code { get; set; }

    [JsonPropertyName("alpha3Code")]
    public string Alpha3Code { get; set; }

    [JsonPropertyName("callingCodes")]
    public string[] CallingCodes { get; set; }

    [JsonPropertyName("capital")]
    public string Capital { get; set; }

    [JsonPropertyName("altSpellings")]
    public string[] AltSpellings { get; set; }

    [JsonPropertyName("region")]
    public string Region { get; set; }
}
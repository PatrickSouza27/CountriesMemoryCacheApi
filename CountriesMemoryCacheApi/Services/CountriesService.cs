using System.Text.Json;
using CountriesMemoryCacheApi.Models;
using Microsoft.Extensions.Caching.Memory;
using RestSharp;

namespace CountriesMemoryCacheApi.Services;

public class CountriesService(IMemoryCache memoryCache, IConfiguration config) : ICountriesService
{
    private readonly IMemoryCache _memoryCache = memoryCache;
    private const string CacheKey = "countries";
    private static readonly JsonSerializerOptions JsonOptions = new() { PropertyNameCaseInsensitive = true };
 
    private const string Url = "https://api.countrylayer.com/v2";
    
    private readonly string? _apiKey = Environment.GetEnvironmentVariable("API_KEY");
    public List<Countrie>? GetCountriesHttpClient()
    {
        
        var countriesCache = GetCountriesFromCache();
        if(countriesCache is not null) return countriesCache;
        
        using HttpClient client = new();

        //para pegar a chave de acesso da variável de ambiente, precisa estar no appsettings.Development.json, ou rebuildar a aplicação para product e colocar no appsettings.json a API_KEY, no caso, suar a interface IConfiguration nesses casos
        var response = client.GetAsync(Url + $"/all?access_key={config["API_KEY"]}").Result;

        if (!response.IsSuccessStatusCode) return null;
        
        var json = response.Content.ReadAsStringAsync().Result;
        
        var countries = JsonSerializer.Deserialize<List<Countrie>>(json, JsonOptions);
        
        _memoryCache.Set(CacheKey, countries, TimeSpan.FromMinutes(5));
            
        return countries;

    }
    public List<Countrie>? GetCountriesRestSharp()
    {
        var countriesCache = GetCountriesFromCache();
        
        if(countriesCache is not null) return countriesCache;
        
        var client = new RestClient(Url);
        var request = new RestRequest("all", Method.Get);

        //para pegar a chave de acesso da variável de ambiente, precisa estar no appsettings.Development.json, ou rebuildar a aplicação para product e colocar no appsettings.json a API_KEY, no caso, suar a interface IConfiguration nesses casos, isso é interessante em caso que você precisa ter algo somente para modo de desenvolvimento
        request.AddParameter("access_key", _apiKey);

        var response = client.Execute(request);

        if (!response.IsSuccessful || response.Content is null) return null;
        
        var countries = JsonSerializer.Deserialize<List<Countrie>>(response.Content);
        
        _memoryCache.Set(CacheKey, countries, TimeSpan.FromMinutes(5));

        return countries;

    }
    private List<Countrie>? GetCountriesFromCache()
       => !_memoryCache.TryGetValue(CacheKey, out List<Countrie>? countries) ? null : countries;
}
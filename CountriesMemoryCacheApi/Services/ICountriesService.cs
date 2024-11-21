using CountriesMemoryCacheApi.Models;

namespace CountriesMemoryCacheApi.Services;

public interface ICountriesService
{
    List<Countrie>? GetCountriesHttpClient();
    List<Countrie>? GetCountriesRestSharp();
}
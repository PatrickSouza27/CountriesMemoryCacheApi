using CountriesMemoryCacheApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CountriesMemoryCacheApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountriesController(ICountriesService countriesService) : ControllerBase
{
    [HttpGet("httpclient")]
    public IActionResult GetWithHttpClient()
    {
        return Ok(countriesService.GetCountriesHttpClient());
    }
    
    [HttpGet("restSharp")]
    public IActionResult GetWithRestSharp()
    {
        return Ok(countriesService.GetCountriesRestSharp());
    }
}
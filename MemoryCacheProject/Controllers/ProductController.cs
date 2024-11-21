using MemoryCache.Data;
using MemoryCache.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MemoryCache.Controllers;

[ApiController]
//[Version("1.0")]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{   
    private readonly IMemoryCache _memoryCache;

    public ProductController(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    [HttpGet]
    public IActionResult Get()
    {
        const string cacheKey = "products";

        if (!_memoryCache.TryGetValue(cacheKey, out List<Product>? products))
        {
            products = AppData.Estoque();
            
            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(3)); // Expira em 3 segundos
            
            //SetSlidingExpiration(TimeSpan.FromMinutes(3)) - Expira em 3 minutos
            
            //o cache expira em 3 minutos a partir do momento que foi criado o cache e não a partir do último acesso ao cache como é feito no SetSlidingExpiration
            // O MemoryCache é útil quando você precisa armazenar dados temporários na memória para melhorar o desempenho e reduzir a carga em recursos mais lentos, como bancos de dados ou serviços externos
            _memoryCache.Set(cacheKey, products, cacheEntryOptions);
        }
        
        return Ok(products);
    }
}
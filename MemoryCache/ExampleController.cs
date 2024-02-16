using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MemoryCache;

[Controller]
[Route("api/[controller]")]
public class ExampleController : Controller
{
    private readonly IMemoryCache _cache;

    public ExampleController(IMemoryCache cache)
    {
        _cache = cache;
    }

    // GET
    [HttpGet("{key}")]
    public IActionResult Index(string key)
    {
        return Json(_cache.Get(key));
    }
    [HttpPost]
    public IActionResult Create(string key, string value)
    {
        _cache.Set(key, value, new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10000)
        });
        return Ok();
    }
}
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add memory cache
builder.Services.AddMemoryCache();
var app = builder.Build();

// Get memory cache instance
var cache = app.Services.GetRequiredService<IMemoryCache>();

//Set a value in cache
cache.Set("key", "value", new MemoryCacheEntryOptions
{
    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10000)
});
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();


app.UseRouting();
app.MapControllers();
app.UseHttpsRedirection();
app.Run();
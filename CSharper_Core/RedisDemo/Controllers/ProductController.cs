using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedisDemo.Models;
using StackExchange.Redis.Extensions.Core.Abstractions;

namespace RedisDemo.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IRedisCacheClient m_redisCacheClient;
    private const string m_key = "Product";

    public ProductController(IRedisCacheClient redisCacheClient)
    {
        m_redisCacheClient = redisCacheClient;
    }

    /// <summary>
    /// Get product by key
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    [HttpGet("{key}")]
    public async Task<Product> Get(string key = m_key)
    {
        var product = await m_redisCacheClient.Db0.GetAsync<Product>(m_key);
        return product;
    }

    /// <summary>
    /// Get all product by keys
    /// </summary>
    /// <param name="keys"></param>
    /// <returns></returns>
    [HttpGet("Products")]
    public async Task<IDictionary<string, Product>> GetByKeys([FromQuery]List<string> keys)
    {
        return await m_redisCacheClient.Db0.GetAllAsync<Product>(keys);
    }

    /// <summary>
    /// Get products which the key start with product
    /// </summary>
    /// <returns></returns>
    [HttpGet("Search/Start/Product")]
    public async Task<List<string>> GetKeysWhichStartWithProduct()
    {
        return (await m_redisCacheClient.Db0.SearchKeysAsync("Product*")).ToList();

    }

    /// <summary>
    /// Get product which the key contain product
    /// </summary>
    /// <returns></returns>
    [HttpGet("Search/Contain/Product")]
    public async Task<List<string>> GetKeysContainProduct()
    {
        return (await m_redisCacheClient.Db0.SearchKeysAsync("*Product*")).ToList();
    }

    /// <summary>
    /// Get product which the key end with product
    /// </summary>
    /// <returns></returns>
    [HttpGet("Search/End/Product")]
    public async Task<List<string>> GetKeysWhicEndWithProduct()
    {
        return (await m_redisCacheClient.Db0.SearchKeysAsync("*Product")).ToList();
    }

    /// <summary>
    /// Create a product
    /// </summary>
    /// <param name="product"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [HttpPost("{key}")]
    public async Task<IActionResult> Create(Product product, string key = m_key)
    {
        bool isAdded = await m_redisCacheClient.Db0.AddAsync(key, product, DateTimeOffset.Now.AddMinutes(10));

        if (!isAdded)
        {
            return BadRequest("Create error");
        }

        return CreatedAtAction(nameof(Get), new { key = m_key }, null);
    }

    /// <summary>
    /// Create products
    /// </summary>
    /// <param name="products"></param>
    /// <returns></returns>
    [HttpPost("products")]
    public async Task<IActionResult> CreateProducts(List<Tuple<string, Product>> products)
    {
        var isAdded = await m_redisCacheClient.Db0.AddAllAsync(products, DateTimeOffset.Now.AddMinutes(10));
        if (!isAdded)
        {
            return BadRequest();
        }

        return CreatedAtAction(nameof(Get), new { key = m_key }, null);
    }

    /// <summary>
    /// Delete product by key
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    [HttpDelete("{key}")]
    public async Task<IActionResult> Delete(string key = m_key)
    {
        await m_redisCacheClient.Db0.RemoveAsync(key);
        return NoContent();
    }
}
}
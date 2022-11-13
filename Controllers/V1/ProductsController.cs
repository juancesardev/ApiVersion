using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Version.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private const string ProductApiUrl = "https://fakestoreapi.com/products";
        private readonly HttpClient _httpClient;

        public ProductsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [MapToApiVersion("1.0")]
        [HttpGet(Name = "GetProductData")]
        public async Task<IActionResult> Get()
        {
            //_httpClient.DefaultRequestHeaders.Clear();
            var response = await _httpClient.GetStreamAsync(ProductApiUrl);
            //var producData = await JsonSerializer.DeserializeAsync< 
            return Ok(response);
        }
    }
}

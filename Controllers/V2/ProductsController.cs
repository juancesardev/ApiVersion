using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Version.DTO;

namespace Version.Controllers.V2
{
    [ApiVersion("2.0")]
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

        [MapToApiVersion("2.0")]
        [HttpGet(Name = "GetProductData2")]
        public async Task<IActionResult> Get()
        {
            //_httpClient.DefaultRequestHeaders.Clear();
            var response = await _httpClient.GetStreamAsync(ProductApiUrl);
            //var producData = await JsonSerializer.DeserializeAsync<AddGuid>(response);
            //var newData = producData?.InternalId;

            return Ok(response);
        }
    }
}

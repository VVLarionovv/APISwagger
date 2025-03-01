using System.Web;
using Microsoft.AspNetCore.Mvc;
using TestApi.Models;

namespace TestApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PaytureController : ControllerBase
{
    private static readonly HttpClient client = new HttpClient();

    // {
    //   "key": "Merchant",
    //   "amount": 12700,
    //   "payInfo": "PAN=4011111111111112;EMonth=12;EYear=22;CardHolder=Ivan Ivanov;SecureCode=123;",
    //   "customFields": "IP=110.1.193.127;Product=Ticket"
    // }
    [HttpPost("pay")]
    public async Task<IActionResult> Pay([FromBody] PayRequest payData)
    {
        var url = "https://sandbox3.payture.com/api/Pay";

        using (var client = new HttpClient())
        {
            var parameters = payData.ToFormData();

            var content = new FormUrlEncodedContent(parameters);

            var response = await client.PostAsync(url, content);

            var responseString = await response.Content.ReadAsStringAsync();
            return Ok(responseString);
        }
    }

    // key = Merchant
    [HttpPost("getState")]
    public async Task<IActionResult> GetState(string key, string orderId)
    {
        var url = "https://sandbox3.payture.com/api/GetState";

        using var client = new HttpClient();
        
        var parameters = new Dictionary<string, string>
        {
            { "Key", key },
            { "OrderId", orderId }
        };

        var content = new FormUrlEncodedContent(parameters);

        var response = await client.PostAsync(url, content);

        var responseString = await response.Content.ReadAsStringAsync();
        
        return Ok(responseString);
    }
}


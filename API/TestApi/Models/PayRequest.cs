using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;

namespace TestApi.Models;

public class PayRequest
{
    public string Key { get; set; }
    public int Amount { get; set; }
    public string PayInfo { get; set; }
    public string CustomFields { get; set; }

    public Dictionary<string, string> ToFormData()
    {
        return new Dictionary<string, string>
        {
            { "Key", Key },
            { "Amount", Amount.ToString() },
            { "OrderId", Guid.NewGuid().ToString() },
            { "PayInfo", HttpUtility.UrlEncode(PayInfo) },
            { "CustomFields", HttpUtility.UrlEncode(CustomFields) }
        };
    }
}

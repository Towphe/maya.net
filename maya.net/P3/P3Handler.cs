using System.Runtime.InteropServices;
using maya.net.Common;
using Newtonsoft.Json;

namespace maya.net.P3;

public class P3Handler : IP3Handler{
    private static readonly string _webhookURL = "https://pg-sandbox.paymaya.com/p3/";
    private readonly string _secretKey;
    private readonly HttpClient _httpClient;
    public P3Handler(string sKey){
        this._secretKey = sKey;
        this._httpClient = new HttpClient();
        this._httpClient.DefaultRequestHeaders.Clear();
        this._httpClient.BaseAddress = new Uri(_webhookURL);
    }
    public async Task<dynamic> Pay(Merchant merchant, Payer payer, ThreeDSecure threeDSecure, Transaction transaction, Trace trace, P3Header p3Header){
        var body = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new {
            // add here
        }));
        this._httpClient.BaseAddress = new Uri(_webhookURL + "pay");
        HttpRequestMessage req = new HttpRequestMessage(){
            Method = HttpMethod.Post,
            Content = body,
            Headers = {
                // add headers here
                Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", StringParser.toBase64(this._secretKey))
            }
        };

        var response = await _httpClient.SendAsync(req);
        string responseBody = await response.Content.ReadAsStringAsync();

        if (response.StatusCode != System.Net.HttpStatusCode.OK || response.StatusCode != System.Net.HttpStatusCode.Accepted){
            LogHelper.logError(response, responseBody);
            return null;
        }
        return JsonConvert.DeserializeObject(responseBody);
    }
    public async Task<dynamic> Pay(Merchant merchant, Payer payer, Transaction transaction, P3Header p3Header, Trace? trace = null){
        this._httpClient.BaseAddress = new Uri(_webhookURL + "pay");
        var body = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new {
            // add here
            merchant,
            payer,
            transaction,
            trace,
            p3Header
        }));

        var bodyStr = await body.ReadAsStringAsync();
        Console.WriteLine(bodyStr);

        HttpRequestMessage req = new HttpRequestMessage(){
            Method = HttpMethod.Post,
            Content = body,
            Headers = {
                // add headers here
                Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", StringParser.toBase64(this._secretKey))
            }
        };
        
        // add headers
        _httpClient.DefaultRequestHeaders.Add("Request-Reference-No", p3Header.requestReferenceNo);
        // _httpClient.DefaultRequestHeaders.Add("X-Idempotency-Key", p3Header.XIdempotencyKey);
        // _httpClient.DefaultRequestHeaders.Add("Longitude", p3Header.Longitude.ToString());
        // _httpClient.DefaultRequestHeaders.Add("Latitude", p3Header.Latitude.ToString());

        var response = await _httpClient.SendAsync(req);
        string responseBody = await response.Content.ReadAsStringAsync();

        Console.WriteLine(responseBody);

        if (response.StatusCode != System.Net.HttpStatusCode.OK || response.StatusCode != System.Net.HttpStatusCode.Accepted){
            //LogHelper.logError(response, responseBody);
            return responseBody;
        }

        // remove
        _httpClient.DefaultRequestHeaders.Clear();

        return JsonConvert.DeserializeObject(responseBody);
    }
}
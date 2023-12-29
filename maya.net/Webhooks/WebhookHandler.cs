namespace maya.net.Webhooks;

using maya.net;
using maya.net.Common;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

public class WebhookHandler : IWebhookHandler{
    private static readonly string _webhookURL = "https://pg-sandbox.paymaya.com/payments/v1/webhooks/";
    private readonly string _publicKey;
    private readonly string _secretKey;
    private readonly HttpClient _httpClient;
    private readonly UriBuilder _uriBuilder;
    public WebhookHandler(string pKey, string sKey){
        this._publicKey = pKey;
        this._secretKey = sKey;
        this._httpClient = new HttpClient();
        this._uriBuilder = new UriBuilder(_webhookURL);
        this._httpClient.DefaultRequestHeaders.Clear();
        this._httpClient.BaseAddress = new Uri(_webhookURL);
    }
    public async Task<Webhook?> CreateWebhook(string name, string callback){
        var body = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new {
            name = name,
            callbackUrl = callback
        }));

        HttpRequestMessage req = new HttpRequestMessage(){
            Method = HttpMethod.Post,
            Content = body,
            Headers = {
                Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", StringParser.toBase64(this._secretKey))
            }
        };

        var response = await _httpClient.SendAsync(req);
        string responseBody = await response.Content.ReadAsStringAsync();
        
        if (response.StatusCode != System.Net.HttpStatusCode.OK){
            LogHelper.logError(response, responseBody);
            return null;
        }
        return JsonConvert.DeserializeObject<Webhook>(responseBody);
    }

    public async Task<IReadOnlyCollection<Webhook>?> GetWebhooks(){
        HttpRequestMessage req = new HttpRequestMessage(){
            Method = HttpMethod.Get,
            Headers = {
                Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", StringParser.toBase64(this._secretKey))
            }
        };

        var response = await _httpClient.SendAsync(req);
        string responseBody = await response.Content.ReadAsStringAsync();
        
        if (response.StatusCode != System.Net.HttpStatusCode.OK){
            LogHelper.logError(response, responseBody);
            return null;
        }
        return JsonConvert.DeserializeObject<IReadOnlyCollection<Webhook>>(responseBody);
    }

    public async Task<Webhook?> GetWebhook(string webhookId){
        HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, webhookId){
            Headers = {
                Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", StringParser.toBase64(this._secretKey))
            }
        };

        var response = await _httpClient.SendAsync(req);
        string responseBody = await response.Content.ReadAsStringAsync();

        if (response.StatusCode != System.Net.HttpStatusCode.OK){
            LogHelper.logError(response, responseBody);
            return null;
        }
        return JsonConvert.DeserializeObject<Webhook>(responseBody);
    }

    public async Task<Webhook?> UpdateWebhook(string webhookId, string callbackUrl){
        var body = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new{
            callbackUrl = callbackUrl
        }));

        HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Put, webhookId){
            Content = body,
            Headers = {
                Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", StringParser.toBase64(this._secretKey))
            }
        };

        var response = await _httpClient.SendAsync(req);
        string responseBody = await response.Content.ReadAsStringAsync();

        if (response.StatusCode != System.Net.HttpStatusCode.OK){
            LogHelper.logError(response, responseBody);
            return null;
        }
        return JsonConvert.DeserializeObject<Webhook>(responseBody);
    }

    public async Task<Webhook?> DeleteWebhook(string webhookId){
        HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Delete, webhookId){
            Headers = {
                Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", StringParser.toBase64(this._secretKey))
            }
        };

        var response = await _httpClient.SendAsync(req);
        string responseBody = await response.Content.ReadAsStringAsync();
        
        if (response.StatusCode != System.Net.HttpStatusCode.OK){
            LogHelper.logError(response, responseBody);
            return null;
        }
        return JsonConvert.DeserializeObject<Webhook>(responseBody);
    }
}
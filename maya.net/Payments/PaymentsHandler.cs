namespace maya.net.Payments;

using System.Runtime.CompilerServices;
using maya.net.Common;
using Newtonsoft.Json;

public class PaymentsHandler : IPaymentsHandler{
    private readonly string _webhookURL = "https://pg-sandbox.paymaya.com/payments/v1/";
    private readonly string _publicKey;
    private readonly string _secretKey;
    private readonly HttpClient _httpClient;
    public PaymentsHandler(string pKey, string sKey, bool isSandbox = true){
        this._publicKey = pKey;
        this._secretKey = sKey;
        this._httpClient = new HttpClient();
        this._httpClient.DefaultRequestHeaders.Clear();
        // when in production
        if (!isSandbox) this._webhookURL = "https://pg.paymaya.com/payments/v1/";
    }
    public async Task<dynamic> RetrievePaymentById(string paymentId){

        this._httpClient.BaseAddress = new Uri(_webhookURL + "payments/" + paymentId + "/");
        
        HttpRequestMessage req = new HttpRequestMessage(){
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
        
        return JsonConvert.DeserializeObject(responseBody);
    }
    public async Task<dynamic> RetrievePaymentviaRRN(string rrn){
        this._httpClient.BaseAddress = new Uri(_webhookURL + "payment-rrns/" + rrn + "/");

        HttpRequestMessage req = new HttpRequestMessage(){
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
        
        return JsonConvert.DeserializeObject(responseBody);
    }
    public async Task<dynamic> RetrievePaymentStatus(string paymentId){

        this._httpClient.BaseAddress = new Uri(_webhookURL + "payments/" + paymentId + "/status/");

        HttpRequestMessage req = new HttpRequestMessage(){
            Headers = {
                Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", StringParser.toBase64(this._publicKey))
            }
        };

        var response = await _httpClient.SendAsync(req);
        string responseBody = await response.Content.ReadAsStringAsync();

        if (response.StatusCode != System.Net.HttpStatusCode.OK){
            LogHelper.logError(response, responseBody);
            return null;
        }
        
        return JsonConvert.DeserializeObject(responseBody);
    }
    public async Task<dynamic> CancelPaymentViaID(string paymentId){
        this._httpClient.BaseAddress = new Uri(_webhookURL + "payments/" + paymentId + "/cancel/");

        HttpRequestMessage req = new HttpRequestMessage(){
            Method = HttpMethod.Post,
            Headers = {
                Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", StringParser.toBase64(this._publicKey))
            }
        };

        var response = await _httpClient.SendAsync(req);
        string responseBody = await response.Content.ReadAsStringAsync();

        if (response.StatusCode != System.Net.HttpStatusCode.OK){
            LogHelper.logError(response, responseBody);
            return null;
        }
        
        return JsonConvert.DeserializeObject(responseBody);
    }
    public async Task<dynamic> CapturePayment(string paymentId, CapturePaymentBody captureBody){

        this._httpClient.BaseAddress = new Uri(_webhookURL + "payments/" + paymentId + "/capture/");

        var body = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(captureBody));

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
        
        return JsonConvert.DeserializeObject(responseBody);
    }
}
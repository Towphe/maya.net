namespace maya.net.Checkout;

using maya.net.Common;
using Newtonsoft.Json;

public class CheckoutHandler : ICheckoutHandler{
    private readonly string _webhookURL = "https://pg-sandbox.paymaya.com/checkout/v1/checkouts/";
    private readonly string _publicKey;
    private readonly HttpClient _httpClient;
    // refer to https://stackoverflow.com/questions/53884417/net-core-di-ways-of-passing-parameters-to-constructor
    // when applying dependency injection to this service (and other services here)
    public CheckoutHandler(string pKey, bool isSandbox = true){
        this._publicKey = pKey;
        this._httpClient = new HttpClient();
        this._httpClient.DefaultRequestHeaders.Clear();
        if (!isSandbox) _webhookURL = "https://pg.paymaya.com/checkout/v1/checkouts/";
        this._httpClient.BaseAddress = new Uri(_webhookURL);
    }
    public async Task<CheckoutResponse?> CreateCheckout(CheckoutBody checkout){
        var body = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(checkout));

        HttpRequestMessage req = new HttpRequestMessage(){
            Method = HttpMethod.Post,
            Content = body,
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

        return JsonConvert.DeserializeObject<CheckoutResponse>(responseBody);
    }
}
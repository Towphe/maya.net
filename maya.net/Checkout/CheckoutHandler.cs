namespace maya.net.Checkout;

using Newtonsoft.Json;

public class CheckoutHandler : ICheckoutHandler{
    private static readonly string _webhookURL = "https://pg-sandbox.paymaya.com/checkout/v1/checkouts/";
    private readonly string _publicKey;
    private readonly string _secretKey;
    private readonly HttpClient _httpClient;
    public CheckoutHandler(string pKey, string sKey){
        this._publicKey = pKey;
        this._secretKey = sKey;
        this._httpClient = new HttpClient();
        this._httpClient.DefaultRequestHeaders.Clear();
        this._httpClient.BaseAddress = new Uri(_webhookURL);
    }
    public async Task<CheckoutResponse?> CreateCheckout(CheckoutBody checkout){
        var body = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(checkout));

        HttpRequestMessage req = new HttpRequestMessage(){
            Method = HttpMethod.Post,
            Content = body,
            Headers = {
                Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", toBase64(this._publicKey))
            }
        };

        var response = await _httpClient.SendAsync(req);
        string responseBody = await response.Content.ReadAsStringAsync();
        
        if (response.StatusCode != System.Net.HttpStatusCode.OK){
            logError(response, responseBody);
            return null;
        }

        return JsonConvert.DeserializeObject<CheckoutResponse>(responseBody);
    }

    private string toBase64(string str) => Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(str));
    private void logError(HttpResponseMessage response, string responseBody){
        ErrorResponse err = JsonConvert.DeserializeObject<ErrorResponse>(responseBody);
        Console.WriteLine($"{response.StatusCode} : {err.Error}.\nCode: {err.Code}.\nReference: {err.Reference}");
    }
}
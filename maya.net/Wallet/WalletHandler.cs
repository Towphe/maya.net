namespace maya.net.Wallet;

using System.Net.Http;
using Newtonsoft.Json;

public class WalletHandler : IWalletHandler{
    private static readonly string _webhookURL = "https://pg-sandbox.paymaya.com/payby/v2/paymaya/payments/";
    private readonly string _publicKey;
    private readonly string _secretKey;
    private readonly HttpClient _httpClient;
    public WalletHandler(string pKey, string sKey){
        this._publicKey = pKey;
        this._secretKey = sKey;
        this._httpClient = new HttpClient();
        this._httpClient.DefaultRequestHeaders.Clear();
        this._httpClient.BaseAddress = new Uri(_webhookURL);
    }
    public async Task<WalletResponse?> CreateSinglePayment(WalletBody wallet){
        var body = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(wallet));

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
        return JsonConvert.DeserializeObject<WalletResponse>(responseBody);
    }

    private string toBase64(string str) => Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(str));
    private void logError(HttpResponseMessage response, string responseBody){
        ErrorResponse err = JsonConvert.DeserializeObject<ErrorResponse>(responseBody);
        Console.WriteLine($"{response.StatusCode} : {err.Error}.\nCode: {err.Code}.\nReference: {err.Reference}");
    }
}
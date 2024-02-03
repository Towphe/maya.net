using maya.net.Common;
using Newtonsoft.Json;

namespace maya.net.QR;

public class QRHandler : IQRHandler{
    private readonly string _webhookURL = "https://pg-sandbox.paymaya.com/payments/v1/qr/payments/";
    private readonly string _publicKey;
    private readonly HttpClient _httpClient;
    // refer to https://stackoverflow.com/questions/53884417/net-core-di-ways-of-passing-parameters-to-constructor
    // when applying dependency injection to this service (and other services here)
    public QRHandler(string pKey, bool isSandbox = true){
        this._publicKey = pKey;
        this._httpClient = new HttpClient();
        this._httpClient.DefaultRequestHeaders.Clear();
        this._webhookURL = "https://pg.paymaya.com/payments/v1/qr/payments/";
        this._httpClient.BaseAddress = new Uri(_webhookURL);
    }

    public async Task<QR> CreateDynamicQR(QRBody qrBody){
        var body = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(qrBody));

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

        return JsonConvert.DeserializeObject<QR>(responseBody);
    }
}
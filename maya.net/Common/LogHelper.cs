namespace maya.net.Common;

using maya.net;
using Newtonsoft.Json;

public static class LogHelper {
    public static void logError(HttpResponseMessage response, string responseBody){
        ErrorResponse err = JsonConvert.DeserializeObject<ErrorResponse>(responseBody);
        Console.WriteLine($"{response.StatusCode} : {err.Error}.\nCode: {err.Code}.\nReference: {err.Reference}");
    }
}
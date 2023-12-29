namespace maya.net.Common;

public static class StringParser {
    public static string toBase64(string str) => Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(str));
}
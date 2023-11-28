using System.Collections;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BayatGames.Serialization.Formatters.Json;
using UnityEngine;
using UnityEngine.Networking;

public class RequestHandler
{
    private static UnityWebRequest request;

    /// <summary>
    /// Send web request with provided params to selected URL.
    /// </summary>
    /// <param name="requestString"></param>
    public static IEnumerator SendRequest(string requestString)
    {
        request = new UnityWebRequest(Constants.GOOGLE_URL + Constants.API_KEY, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(requestString);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();
    }

    /// <summary>
    /// Check if response exists.
    /// </summary>
    /// <returns></returns>
    public static bool CheckResult()
    {
        if (request.isNetworkError || request.isHttpError)
            return false;

        return true;
    }

    /// <summary>
    /// Get response data.
    /// </summary>
    /// <returns></returns>
    public static string GetResult()
    {
        return request.downloadHandler.text;
    }

    /// <summary>
    /// Get response error text.
    /// </summary>
    /// <returns></returns>
    public static string GetError()
    {
        return request.error;
    }
}

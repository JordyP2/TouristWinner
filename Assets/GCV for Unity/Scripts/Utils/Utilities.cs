using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class Utilities
{
    /// <summary>
	/// Load image from storage using path.
	/// </summary>
	/// <param name="path"></param>
	/// <returns></returns>
    public static Texture2D OpenImage(string path)
    {
        if (File.Exists(path))
        {
            byte[] fileData = File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(fileData);

            return texture;
        }
        else
            return null;
    }

    /// <summary>
	/// Convert image to base64 representation.
	/// </summary>
	/// <param name="path"></param>
	/// <returns></returns>
    public static string ConvertToBase64(string path)
    {
        byte[] imageArray = File.ReadAllBytes(path);
        string base64Image = System.Convert.ToBase64String(imageArray);

        return base64Image;
    }

    /// <summary>
	/// Download image from the Internet using provided URL.
	/// </summary>
	/// <param name="onSuccess"></param>
	/// <param name="onFailure"></param>
	/// <param name="image_url"></param>
	/// <returns></returns>
    public static IEnumerator DownloadImage(Action<Texture2D, bool> onSuccess, Action<string> onFailure, string image_url)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(image_url);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
            onFailure(www.error);
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            onSuccess(texture, true);
        }
    }

    /// <summary>
	/// Get request body from file and fill it with required parameters.
	/// </summary>
	/// <param name="request_path"></param>
	/// <param name="image_path"></param>
	/// <param name="isUrl"></param>
	/// <returns></returns>
    public static string GenerateRequest(string request_path, string image_path, bool isUrl)
	{
        string request = "";

        if (isUrl)
        {
            request_path += "request_url";
            TextAsset reader = Resources.Load<TextAsset>(request_path);
            request = reader.text;
            request = request.Replace("URL", image_path);
        }
        else
        {
            request_path += "request_file";
            string base64Image = ConvertToBase64(image_path);
			TextAsset reader = Resources.Load<TextAsset>(request_path);
			request = reader.text;
			request = request.Replace("BASE64", base64Image);
        }

        return request;
	}

    /// <summary>
	/// Check if Internet connection is available.
	/// </summary>
	/// <returns></returns>
    public static bool CheckInternetConnection()
    {
        return Application.internetReachability != NetworkReachability.NotReachable;
    }

    /// <summary>
	/// Check if API key is set.
	/// </summary>
	/// <returns></returns>
    public static bool IsApiKeySet()
    {
        return !Constants.API_KEY.Equals("");
    }
}

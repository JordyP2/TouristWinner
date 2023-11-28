using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants
{
    public static string API_KEY = "";

    public const string GOOGLE_URL = "https://vision.googleapis.com/v1/images:annotate?key=";

    public const string GOOGLE_CLOUD_CONSOLE_URL = "https://cloud.google.com/compute/docs/console";

    public const string DETECTION_ERROR = "Detection error: probably wrong type is selected";
    public const string INTERNET_CONNECTION_ERROR = "No Internet connection";
    public const string NO_IMAGE_SELECTED = "Open an image or download from URL first";
    public const string EMPTY_URL = "Enter a valid url";
    public const string EMPTY_API_KEY = "API key is not set";
    public const string RESPONSE_LENGTH_ERROR = "Raw response is too large to be shown";
}

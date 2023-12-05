using System;
using System.Collections;
using System.Collections.Generic;
using BayatGames.Serialization.Formatters.Json;
using UnityEngine;
using static Borders;

public class ExplicitContentDetectionHandler
{
    private const string REQUEST_PATH = "Requests/Explicit Content/";

    /// <summary>
    /// Generate request body according to selected detection type model and send it to Google Cloud server.
    /// Receive response and parse it into coordinates and text information.
    /// </summary>
    /// <param name="onSuccess"></param>
    /// <param name="onFailure"></param>
    /// <param name="image_path"></param>
    /// <param name="isUrl"></param>
    /// <returns></returns>
    public static IEnumerator Run(Action<List<Vertices[]>, List<string[]>, string> onSuccess, Action<string> onFailure, string image_path, bool isUrl)
    {
        string request = Utilities.GenerateRequest(REQUEST_PATH, image_path, isUrl);

        yield return RequestHandler.SendRequest(request);

        if (RequestHandler.CheckResult())
        {
            try
            {
                ExplicitContentDetection res = (ExplicitContentDetection)JsonFormatter.DeserializeObject(RequestHandler.GetResult(), typeof(ExplicitContentDetection));

                List<string[]> values = new List<string[]>();

                if (res.responses[0].safeSearchAnnotation.adult != null)
                    values.Add(new string[] { "ADULT", res.responses[0].safeSearchAnnotation.adult });

                if (res.responses[0].safeSearchAnnotation.spoof != null)
                    values.Add(new string[] { "SPOOF", res.responses[0].safeSearchAnnotation.spoof });

                if (res.responses[0].safeSearchAnnotation.medical != null)
                    values.Add(new string[] { "MEDICAL", res.responses[0].safeSearchAnnotation.medical });

                if (res.responses[0].safeSearchAnnotation.violence != null)
                    values.Add(new string[] { "VIOLENCE", res.responses[0].safeSearchAnnotation.violence });

                if (res.responses[0].safeSearchAnnotation.racy != null)
                    values.Add(new string[] { "RACY", res.responses[0].safeSearchAnnotation.racy });
    
                onSuccess(null, values, RequestHandler.GetResult());
            }
            catch (ArgumentNullException error)
            {
                onFailure(Constants.DETECTION_ERROR);
            }
        }
        else
            onFailure(RequestHandler.GetError());
    }
}

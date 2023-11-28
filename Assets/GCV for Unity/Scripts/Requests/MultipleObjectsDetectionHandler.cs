using System;
using System.Collections;
using System.Collections.Generic;
using BayatGames.Serialization.Formatters.Json;
using UnityEngine;
using static Borders;

public class MultipleObjectsDetectionHandler
{
    private const string REQUEST_PATH = "Requests/Multiple Objects/";

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
                MultipleObjectsDetection res = (MultipleObjectsDetection)JsonFormatter.DeserializeObject(RequestHandler.GetResult(), typeof(MultipleObjectsDetection));

                List<Vertices[]> borders = new List<Vertices[]>();

                foreach (var localized in res.responses[0].localizedObjectAnnotations)
                {
                    // For some reasons for multiple object detection Google API returns coordinates in range from 0 to 1 
                    foreach (var v in localized.boundingPoly.normalizedVertices)
                    {
                        v.x *= ImageProcessing.ORIGINAL_IMAGE_WIDTH;
                        v.y *= ImageProcessing.ORIGINAL_IMAGE_HEIGHT;
                    }

                    borders.Add(localized.boundingPoly.normalizedVertices);
                }

                List<string[]> values = new List<string[]>();

                foreach (var v in res.responses[0].localizedObjectAnnotations)
                {
                    if (v.name != null && v.score.ToString() != "")
                    {
                        values.Add(new string[] { "NAME", v.name });
                        values.Add(new string[] { "SCORE", v.score.ToString() });
                    }
                }

                onSuccess(borders, values, RequestHandler.GetResult());
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

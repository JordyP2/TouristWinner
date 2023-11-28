using System;
using System.Collections;
using System.Collections.Generic;
using BayatGames.Serialization.Formatters.Json;
using UnityEngine;
using static Borders;

public class CropHintsDetectionHandler
{
    private const string REQUEST_PATH = "Requests/Crop Hints/";

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
                CropHintsDetection res = (CropHintsDetection)JsonFormatter.DeserializeObject(RequestHandler.GetResult(), typeof(CropHintsDetection));

                List<Vertices[]> borders = new List<Vertices[]>();

                foreach (var border in res.responses[0].cropHintsAnnotation.cropHints)
                    borders.Add(border.boundingPoly.vertices);

                List<string[]> values = new List<string[]>();

                foreach (var v in res.responses[0].cropHintsAnnotation.cropHints)
                {
                    if (v.confidence.ToString() != "" && v.importanceFraction.ToString() != "")
                    {
                        values.Add(new string[] { "CONFIDENCE", v.confidence.ToString() });
                        values.Add(new string[] { "IMPORTANCE FRACTION", v.importanceFraction.ToString() });
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

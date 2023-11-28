using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using BayatGames.Serialization.Formatters.Json;
using UnityEngine;
using static Borders;

public class LogosDetectionHandler
{
    private const string REQUEST_PATH = "Requests/Logos/";

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
                LogosDetection res = (LogosDetection)JsonFormatter.DeserializeObject(RequestHandler.GetResult(), typeof(LogosDetection));

                List<Vertices[]> borders = new List<Vertices[]>();

                foreach (var border in res.responses[0].logoAnnotations)
                    borders.Add(border.boundingPoly.vertices);

                List<string[]> values = new List<string[]>();

                foreach (var v in res.responses[0].logoAnnotations)
                {
                    if (v.description != null && v.score.ToString() != "")
                    {
                        values.Add(new string[] { "DESCRIPTION", v.description });
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

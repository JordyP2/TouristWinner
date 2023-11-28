using System;
using System.Collections;
using System.Collections.Generic;
using BayatGames.Serialization.Formatters.Json;
using UnityEngine;
using static Borders;

public class LabelsDetectionHandler
{
    private const string REQUEST_PATH = "Requests/Labels/";

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
                LabelsDetection res = (LabelsDetection)JsonFormatter.DeserializeObject(RequestHandler.GetResult(), typeof(LabelsDetection));

                List<string[]> values = new List<string[]>();

                foreach (var v in res.responses[0].labelAnnotations)
                {
                    if (v.description != null && v.score.ToString() != "" && v.topicality.ToString() != "")
                    {
                        values.Add(new string[] { "DESCRIPTION", v.description });
                        values.Add(new string[] { "SCORE", v.score.ToString() });
                        values.Add(new string[] { "TOPICALITY", v.topicality.ToString() });
                    }
                }

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

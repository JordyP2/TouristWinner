using System;
using System.Collections;
using System.Collections.Generic;
using BayatGames.Serialization.Formatters.Json;
using UnityEngine;
using static Borders;

public class ImagePropertiesDetectionHandler
{
    private const string REQUEST_PATH = "Requests/Image Properties/";

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
                ImagePropertiesDetection res = (ImagePropertiesDetection)JsonFormatter.DeserializeObject(RequestHandler.GetResult(), typeof(ImagePropertiesDetection));

                List<string[]> values = new List<string[]>();

                foreach (var v in res.responses[0].imagePropertiesAnnotation.dominantColors.colors)
                {
                    if (v.score.ToString() != "" && v.pixelFraction.ToString() != "" && v.color.red.ToString() != "" && v.color.green.ToString() != "" && v.color.blue.ToString() != "")
                    {
                        values.Add(new string[] { "SCORE", v.score.ToString() });
                        values.Add(new string[] { "PIXEL FRACTION", v.pixelFraction.ToString() });
                        values.Add(new string[] { "RGB", v.color.red + " " + v.color.green + " " + v.color.blue });
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

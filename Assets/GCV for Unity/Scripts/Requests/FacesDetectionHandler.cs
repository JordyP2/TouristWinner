using System;
using System.Collections;
using System.Collections.Generic;
using BayatGames.Serialization.Formatters.Json;
using UnityEngine;
using static Borders;

public class FacesDetectionHandler
{
    private const string REQUEST_PATH = "Requests/Faces/";

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
                FacesDetection res = (FacesDetection)JsonFormatter.DeserializeObject(RequestHandler.GetResult(), typeof(FacesDetection));

                List<Vertices[]> borders = new List<Vertices[]>();

                foreach (var border in res.responses[0].faceAnnotations)
                    borders.Add(border.boundingPoly.vertices);

                onSuccess(borders, null, RequestHandler.GetResult());
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

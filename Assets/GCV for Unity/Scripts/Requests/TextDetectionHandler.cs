using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BayatGames.Serialization.Formatters.Json;
using UnityEngine;
using UnityEngine.Networking;
using static Borders;

public class TextDetectionHandler
{
    private const string REQUEST_PATH = "Requests/Text/";

	/// <summary>
	/// Generate request body according to selected detection type model and send it to Google Cloud server.
	/// Receive response and parse it into coordinates and text information.
	/// Text detection takes one more extra parameter to define if it's base text recognition or handwriting.
	/// </summary>
	/// <param name="onSuccess"></param>
	/// <param name="onFailure"></param>
	/// <param name="image_path"></param>
	/// <param name="isUrl"></param>
	/// <param name="type"></param>
	/// <returns></returns>
	public static IEnumerator Run(Action<List<Vertices[]>, List<string[]>, string> onSuccess, Action<string> onFailure, string image_path, bool isUrl, string type)
    {
		string request = Utilities.GenerateRequest(REQUEST_PATH, image_path, isUrl);

		switch (type)
        {
            case TextDetection.TAG1: request = request.Replace("TYPE", "TEXT_DETECTION"); break;
            case TextDetection.TAG2: request = request.Replace("TYPE", "DOCUMENT_TEXT_DETECTION"); break;
        }

        yield return RequestHandler.SendRequest(request);

        if (RequestHandler.CheckResult())
        {
            try
            {
                TextDetection res = (TextDetection)JsonFormatter.DeserializeObject(RequestHandler.GetResult(), typeof(TextDetection));

                List<Vertices[]> borders = new List<Vertices[]>();

                foreach (var border in res.responses[0].textAnnotations)
                    borders.Add(border.boundingPoly.vertices);

                List<string[]> values = new List<string[]>();

                foreach (var v in res.responses[0].textAnnotations)
                {
                    if (v.locale != null)
                        values.Add(new string[] { "LOCALE", v.locale });

                    if (v.description != null)
                        values.Add(new string[] { "DESCRIPTION", v.description });
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

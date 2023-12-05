using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

using SimpleFileBrowser;

using static Borders;
using System;

public class Main : MonoBehaviour
{
    private string IMAGE_PATH = "";
    private string IMAGE_URL = "";

    private string RAW_DATA;
    private string FORMATTED_DATA;

    [Header("Preview Image")]
    public Image image;

    [Header("Dropdown with detecton options")]
    public Dropdown detectionTypes;

    [Header("Image container")]
    public GameObject container;

    [Header("Prefab used to draw lines")]
    public UILineRenderer rectPrefab;

    [Header("Final result shows here")]
    public Text resultText;

    [Header("Placeholder for final result")]
    public GameObject responsePlaceholder;

    [Header("URL input field")]
    public InputField imageUrlInput;

    [Header("Switcher for url analyze")]
    public Toggle urlToggle;

    [Header("Loading spinner container")]
    public GameObject loadingCover;

    [Header("Loading spinner sprite")]
    public GameObject loadingIndicator;

    [Header("Text hint for selected image path")]
    public Text imagePath;

    [Header("Text hint for all errors")]
    public Text networkError;

    private bool isImageDownloaded;

    /// <summary>
    /// Populate dropdown with detection options. This values are based on TAGs variables from each detection model.
    /// </summary>
    void Start()
    {
        FileBrowser.RequestPermission();
        FileBrowser.SetFilters(false, new FileBrowser.Filter("Images", ".jpg", ".jpeg", ".png"));

        List<Dropdown.OptionData> od = new List<Dropdown.OptionData>
        {
            new Dropdown.OptionData() { text = LandmarksDetection.TAG },
        };

        detectionTypes.options = od;

        imagePath.text = "";
        networkError.text = "";
    }

    /// <summary>
    /// Update loading spinner and result text placeholder.
    /// </summary>
    void Update()
    {
        loadingIndicator.transform.Rotate(new Vector3(0, 0, -1), 2f);
        if (resultText.text.Length > 0)
            responsePlaceholder.SetActive(false);
        else
            responsePlaceholder.SetActive(true);
    }

    /// <summary>
    /// Open file browse window. Returns path if image is selected and sends it further.
    /// </summary>
    public void BrowseFiles()
    {
        FileBrowser.ShowLoadDialog((path) =>
        {
            ShowLoading(true);

            RemoveRectangles();

            imagePath.text = path[0];
            IMAGE_PATH = path[0];
            OpenImage(path[0]);
        }, () => { }, FileBrowser.PickMode.Files);
    }

    /// <summary>
    /// Delete rectangles from the screen.
    /// </summary>
    private void RemoveRectangles()
    {
        UILineRenderer[] rects = FindObjectsOfType<UILineRenderer>();
        foreach (var r in rects)
            Destroy(r.gameObject);
    }

    /// <summary>
    /// This function starts selected detection type process. It uses detection TAG and value from dropdown to determine which one is selected.
    /// </summary>
    public void Analyze()
    {
        if (Utilities.IsApiKeySet())
        {
            if (Utilities.CheckInternetConnection())
            {
                if (CheckImageSource())
                {
                    networkError.text = "";
                    RemoveRectangles();
                    ShowLoading(true);

                    string final_path = "";
                    bool isUrl = urlToggle.isOn;

                    if (isUrl)
                        final_path = IMAGE_URL;
                    else
                        final_path = IMAGE_PATH;

                    switch (detectionTypes.captionText.text)
                    {
                        case LandmarksDetection.TAG:
                            StartCoroutine(LandmarksDetectionHandler.Run(ShowResult, NetworkError, final_path, isUrl));
                            break;
                    }
                }
            }
            else
                NetworkError(Constants.INTERNET_CONNECTION_ERROR);
        }
        else
            NetworkError(Constants.EMPTY_API_KEY);
    }

    /// <summary>
    /// Simple function to print different errors.
    /// </summary>
    /// <param name="error"></param>
    private void NetworkError(string error)
    {
        networkError.text = error;
        ShowLoading(false);
    }

    /// <summary>
    /// Check if image is loaded and ready to be analyzed.
    /// </summary>
    /// <returns></returns>
    private bool CheckImageSource()
    {
        if (!IMAGE_PATH.Equals(""))
            return true;

        if (isImageDownloaded && urlToggle.isOn)
            return true;

        NetworkError(Constants.NO_IMAGE_SELECTED);

        return false;
    }

    /// <summary>
    /// Bridge function. Receives parsed server response and sends it further.
    /// </summary>
    /// <param name="vertices"></param>
    /// <param name="values"></param>
    /// <param name="rawData"></param>
    private void ShowResult(List<Vertices[]> vertices, List<string[]> values, string rawData)
    {
        RAW_DATA = rawData;

        if (vertices != null)
            ImageProcessing.DrawRectangles(vertices, rectPrefab, container, image);

        if (values != null)
            DisplayText(values);

        ShowLoading(false);
    }

    /// <summary>
    /// Display parsed respone data with text component.
    /// </summary>
    /// <param name="values"></param>
    private void DisplayText(List<string[]> values)
    {
        string result_text = "";

        foreach (var v in values)
            result_text += "<b>" + v[0] + "</b>" + Environment.NewLine + v[1].Replace("\\n", Environment.NewLine) + Environment.NewLine + Environment.NewLine;

        resultText.text = result_text;

        FORMATTED_DATA = result_text;
    }

    /// <summary>
    /// Load image from storage using path.
    /// </summary>
    /// <param name="path"></param>
    public void OpenImage(string path)
    {
        Texture2D texture = Utilities.OpenImage(path);
        ShowImage(texture, false);
    }

    /// <summary>
    /// Start async process to download image from web.
    /// </summary>
    public void DownloadImage()
    {
        if (Utilities.CheckInternetConnection())
        {
            if (!imageUrlInput.text.Equals(""))
                StartCoroutine(Utilities.DownloadImage(ShowImage, NetworkError, imageUrlInput.text));
            else
                NetworkError(Constants.EMPTY_URL);
        }
        else
            NetworkError(Constants.INTERNET_CONNECTION_ERROR);
    }

    /// <summary>
    /// Bridge function. Receives opened image and sends it further.
    /// </summary>
    /// <param name="texture"></param>
    /// <param name="isDownload"></param>
    public void ShowImage(Texture2D texture, bool isDownload)
    {
        if (isDownload)
        {
            isImageDownloaded = isDownload;
            IMAGE_URL = imageUrlInput.text;
        }
        else
            IMAGE_URL = "";

        ImageProcessing.ShowImage(texture, image, container);
        ShowLoading(false);
    }

    /// <summary>
    /// Turn on/off loading spinner.
    /// </summary>
    /// <param name="show"></param>
    private void ShowLoading(bool show)
    {
        if (show)
            loadingCover.SetActive(true);
        else
            loadingCover.SetActive(false);
    }

    /// <summary>
    /// Copy result text to clipboard.
    /// </summary>
    public void CopyResult()
    {
        TextEditor te = new TextEditor();
        te.text = resultText.text;
        te.SelectAll();
        te.Copy();
    }

    /// <summary>
    /// Clear text from result container.
    /// </summary>
    public void ClearResult()
    {
        resultText.text = "";
    }

    /// <summary>
    /// Display text result as original json response.
    /// </summary>
    /// <param name="toggle"></param>
    public void ShowRawResult(Toggle toggle)
    {
        if (toggle.isOn)
            if (RAW_DATA.Length >= 16000)
                resultText.text = RAW_DATA.Substring(0, 16000);
            else
                resultText.text = RAW_DATA;
        else
            resultText.text = FORMATTED_DATA;
    }
}




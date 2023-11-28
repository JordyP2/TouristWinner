using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApiKey : MonoBehaviour
{
    [Header("API key container")]
    public GameObject editControls;

    [Header("API key input field")]
    public InputField keyInput;

    [Header("Button with warning message")]
    public Button keyWarning;

    [Header("Text area used to show help")]
    public Text helpField;

    [Header("Text on button that open edit menu")]
    public Text openKeyText;

    /// <summary>
    /// Load API key from storage.
    /// </summary>
    void Start()
    {
        Constants.API_KEY = Storage.LoadKey();
        CheckKey();
    }

    /// <summary>
    /// Reveal or close API key input field.
    /// </summary>
    public void OpenEditKey()
    {
        if (!editControls.activeSelf)
        {
            openKeyText.text = "Cancel";
            editControls.SetActive(true);
            keyInput.text = Constants.API_KEY;
            keyWarning.gameObject.SetActive(false);
        }
        else
        {
            openKeyText.text = "Edit Key";
            editControls.SetActive(false);
            CheckKey();
        }
    }

    /// <summary>
    /// Save API key to storage.
    /// </summary>
    public void SaveKey()
    {
        Constants.API_KEY = keyInput.text;
        Storage.SaveKey(keyInput.text);
        OpenEditKey();
    }

    /// <summary>
    /// Check if API key is set.
    /// </summary>
    private void CheckKey()
    {
        if (Constants.API_KEY == "")
            keyWarning.gameObject.SetActive(true);
        else
            keyWarning.gameObject.SetActive(false);
    }

    /// <summary>
    /// Open Google Cloud webpage in browser.
    /// </summary>
    public void OpenCloudConsole()
    {
        Application.OpenURL(Constants.GOOGLE_CLOUD_CONSOLE_URL);
    }

    /// <summary>
    /// Show text hints about program.
    /// </summary>
    public void ShowHelp()
    {
        helpField.text =
            "How to use" + System.Environment.NewLine +
            "0. Enter your own valid Google Cloud api key" + System.Environment.NewLine +
            "1. Select required detection type" + System.Environment.NewLine +
            "2. Browse an image from your device" + System.Environment.NewLine +
            "3. Or add URL and download it from web (make sure URL checkbox is selected)" + System.Environment.NewLine +
            "4. Press analyze button and wait until it's ready" + System.Environment.NewLine +
            "5. Select Raw checkbox to view unformatted response (up to 16k characters due to Text component limits)" + System.Environment.NewLine +
            "Internet connection is required";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage
{
    /// <summary>
    /// Load saved API key from PlayerPrefs.
    /// </summary>
    /// <returns></returns>
    public static string LoadKey()
    {
        return PlayerPrefs.GetString("API_KEY");
    }

    /// <summary>
    /// Save API key to PlayerPrefs.
    /// </summary>
    /// <param name="key"></param>
    public static void SaveKey(string key)
    {
        PlayerPrefs.SetString("API_KEY", key);
    }
}

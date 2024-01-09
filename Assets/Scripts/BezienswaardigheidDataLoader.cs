using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using SQLite4Unity3d;
using UnityEngine;
using UnityEngine.UI;
using System.Data.Common;
using System.Data;

public class Bezienswaardigheid
{
    [PrimaryKey, AutoIncrement]
    public int id { get; set; }
    public string name { get; set; }
    public string artist { get; set; }
    public string creation_date { get; set; }
    public string description { get; set; }
    public string info_link { get; set; } // This is a string to store a URL.
    public double? latitude { get; set; } // Nullable double to handle NULL values for latitude.
    public double? longtitude { get; set; } // Nullable double to handle NULL values for longitude.
}

public class BezienswaardigheidDataLoader : MonoBehaviour
{
    //private SQLiteConnection _connection;

public GameObject bezienswaardighedenPrefab; // Set this to your prefab in the inspector.
    public Transform contentPanel; // Set this to the part of the UI where you want to add the destinations.

    private List<Bezienswaardigheid> bezienswaardighedenList = new List<Bezienswaardigheid>();
    private DataService dataService;


    void Start()
    {

        dataService = new DataService("BezienswaardighedenDatabase.db");
        LoadDataFromDatabase();
        PopulatePanel();
    }

    void LoadDataFromDatabase()
    {
        var query = "SELECT * FROM bezienswaardigheden";
        bezienswaardighedenList = dataService.Connection.Query<Bezienswaardigheid>(query);
    }

    void PopulatePanel()
    {
        if (bezienswaardighedenPrefab == null || contentPanel == null)
        {
            Debug.LogError("Prefab or Content Panel is not assigned!");
            return;
        }

        foreach (var item in bezienswaardighedenList)
        {
            GameObject newItem = Instantiate(bezienswaardighedenPrefab, contentPanel);

            UpdateTextComponent(newItem, "name", item.name);
            UpdateTextComponent(newItem, "artist", item.artist);
            UpdateTextComponent(newItem, "creation_date", item.creation_date);
            UpdateTextComponent(newItem, "description", item.description);
            UpdateTextComponent(newItem, "info_link", item.info_link);
            UpdateTextComponent(newItem, "latitude", item.latitude.ToString());
            UpdateTextComponent(newItem, "longtitude", item.longtitude.ToString());
        }
    }

    void UpdateTextComponent(GameObject parentObject, string childName, string textValue)
    {
        var textComponent = parentObject.transform.Find(childName)?.GetComponent<TextMeshProUGUI>();
        if (textComponent != null)
        {
            textComponent.text = textValue;
        }
        else
        {
            Debug.LogError(childName + " Text component or object not found in prefab.");
        }
    }



}

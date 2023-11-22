using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BezienswaardigheidDataLoader : MonoBehaviour
{
    public GameObject bezienswaardighedenPrefab; // Set this to your prefab in the inspector.
    public Transform contentPanel; // Set this to the part of the UI where you want to add the destinations.

    private List<DummyBezienswaardigheden> bezienswaardighedenList = new List<DummyBezienswaardigheden>();

    void Start()
    {
        // Here you would load from the database, but for now we'll just use dummy data.
        LoadDummyData();
        PopulatePanel();
    }

    void LoadDummyData()
    {
        // Add some dummy destinations
        bezienswaardighedenList.Add(new DummyBezienswaardigheden { name = "Eiffel Tower", description = "Iconic tower in Paris", locationX = 777, locationY = 198 });
        bezienswaardighedenList.Add(new DummyBezienswaardigheden { name = "Great Wall", description = "Historic wall in China", locationX = 100, locationY = 125 });
        bezienswaardighedenList.Add(new DummyBezienswaardigheden { name = "Tower of Pisa", description = "Iconic tower in Italy", locationX = 230, locationY = 200 });
        bezienswaardighedenList.Add(new DummyBezienswaardigheden { name = "Great Pyramid of Giza", description = "Large pyramid in Egypt", locationX = 2300, locationY = 2000 });
        bezienswaardighedenList.Add(new DummyBezienswaardigheden { name = "Lighthouse of Alexandria", description = "One of the 6 wonders of the world", locationX = 6600, locationY = 2000 });
        bezienswaardighedenList.Add(new DummyBezienswaardigheden { name = "Library of Alexandria", description = "Burned down library", locationX = 900, locationY = 554 });
        // Add more dummy data as needed.
    }

    void PopulatePanel()
    {
        if (bezienswaardighedenPrefab == null)
        {
            Debug.LogError("Prefab is not assigned!");
            return;
        }

        if (contentPanel == null)
        {
            Debug.LogError("Content panel is not assigned!");
            return;
        }

        foreach (var DummyBezienswaardigheden in bezienswaardighedenList)
        {
            GameObject newDummyBezienswaardigheden = Instantiate(bezienswaardighedenPrefab, contentPanel);

            /*
            var nameText = newDummyBezienswaardigheden.transform.Find("Name")?.GetComponent<TextMeshProUGUI>();
            if (nameText != null)
            {
                nameText.text = DummyBezienswaardigheden.name;
            }
            else
            {
                Debug.LogError("Name Text component or object not found in prefab.");
            }

            // Check and set "Description"
            var descriptionText = newDummyBezienswaardigheden.transform.Find("Description")?.GetComponent<TextMeshProUGUI>();
            if (descriptionText != null)
            {
                descriptionText.text = DummyBezienswaardigheden.description;
            }
            else
            {
                Debug.LogError("Description Text component or object not found in prefab.");
            }

            // Check and set "LocationX"
            var locationXText = newDummyBezienswaardigheden.transform.Find("LocationX")?.GetComponent<TextMeshProUGUI>();
            if (locationXText != null)
            {
                locationXText.text = DummyBezienswaardigheden.locationX.ToString();
            }
            else
            {
                Debug.LogError("LocationX Text component or object not found in prefab.");
            }

            // Check and set "LocationY"
            var locationYText = newDummyBezienswaardigheden.transform.Find("LocationY")?.GetComponent<TextMeshProUGUI>();
            if (locationYText != null)
            {
                locationYText.text = DummyBezienswaardigheden.locationY.ToString();
            }
            else
            {
                Debug.LogError("LocationY Text component or object not found in prefab.");
            }

            */

            // Here you would set the data for the newDestination based on the destination object.
            // For example:
            newDummyBezienswaardigheden.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = DummyBezienswaardigheden.name;
            newDummyBezienswaardigheden.transform.Find("Description").GetComponent<TextMeshProUGUI>().text = DummyBezienswaardigheden.description;
            newDummyBezienswaardigheden.transform.Find("LocationX").GetComponent<TextMeshProUGUI>().text = DummyBezienswaardigheden.locationX.ToString();
            newDummyBezienswaardigheden.transform.Find("LocationY").GetComponent<TextMeshProUGUI>().text = DummyBezienswaardigheden.locationY.ToString();
        }
    }
}

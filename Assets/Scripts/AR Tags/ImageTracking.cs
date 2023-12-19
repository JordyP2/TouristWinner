using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]

public class ImageTracking : MonoBehaviour
{

    [SerializeField]
    private GameObject[] placeablePrefabs;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    private ARTrackedImageManager trackedImageManager;
    private string _previousTrackedImageName;
    private void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        foreach(GameObject prefab in placeablePrefabs)
        {
            GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newPrefab.name = prefab.name;
            spawnedPrefabs.Add(prefab.name, newPrefab);
            newPrefab.SetActive(false);
        }
    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        
        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
      

            UpdateImage(trackedImage);
        }
        
    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        string currentTrackedImageName = trackedImage.referenceImage.name;
        Vector3 position = trackedImage.transform.position; //bepaald positie 3D model
        TrackingState trackedImageState = trackedImage.trackingState; //word de image nog getracked?

        GameObject prefab = spawnedPrefabs[name];
        prefab.transform.position = position;

        if (trackedImageState == TrackingState.Tracking && _previousTrackedImageName != currentTrackedImageName)
        {
            /*
                If _previousTrackedImageName is null, we have to set _previousTrackedImageName to the current tracked image name

                This check is necessary. When the application is loaded, _previousTrackedImageName state is null.
                Without this check, a no reference error will occur
            */
            if (_previousTrackedImageName == null)
            {
                _previousTrackedImageName = currentTrackedImageName;
            }

            /*
                When scanning a tag, only 1 object should be visible on the screen, to prevent multiple objects from being seen, we have to disable the previous object.
                By setting the _previousTrackedImageName to false, the previous object will be disabled.
            */
            if (spawnedPrefabs[_previousTrackedImageName] != null)
            {
                spawnedPrefabs[_previousTrackedImageName].SetActive(false);
            }

            /*
                When you scan a new tag, you want to show the new object instead of the old one. We do this by setting the SetActive of currentTrackedImageName to true.
            */
            if (spawnedPrefabs[currentTrackedImageName] != null)
            {
                spawnedPrefabs[currentTrackedImageName].SetActive(true);
            }

            /*
                When a new tag is scanned, we need to override the _previousTrackedImageName to the current tracking image name.
            */
            _previousTrackedImageName = currentTrackedImageName;
            return;
        }

        if (trackedImageState == TrackingState.Tracking && _previousTrackedImageName == currentTrackedImageName)
        {
            spawnedPrefabs[currentTrackedImageName].SetActive(true);
            return;
        }

        if (!spawnedPrefabs[_previousTrackedImageName])
        {
            return;
        }
        /*foreach (GameObject go in spawnedPrefabs.Values)
        {
            if(go.name != name)
            {
                go.SetActive(false);
            }
        }*/
    }
}


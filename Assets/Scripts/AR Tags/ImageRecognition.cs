using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageRecognition : MonoBehaviour
{
    [SerializeField]
    private Panel _panel;
    [SerializeField]
    private GameObject[] _placeablePrefabs;
    [SerializeField]
    private ARTrackedImageManager _arTrackedImageManager;
    [SerializeField]
    private TagManagerScript _tagManager;
    private Dictionary<string, GameObject> _spawnedPrefabs = new Dictionary<string, GameObject>();

    private string _previousTrackedImageName;

    private void Awake()
    {
        _arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();

        // Loop through the AR Session Origin placeable prefabs and create the game objects
        foreach (GameObject prefab in _placeablePrefabs)
        {
            GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newPrefab.name = prefab.name;
            _spawnedPrefabs.Add(prefab.name, newPrefab);
            newPrefab.SetActive(false);
        }
    }

    // This function is called when the user scans the AR tag and the object becomes enabled and active.
    private void OnEnable()
    {
        _arTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }
    /*
        This function is called when the user stops scanning the tags.
        This is also called when the object is destroyed and can be used for any cleanup code.
    */
    private void OnDisable()
    {
        _arTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    /*
        This function handles the responding to detected images.
        And notify events whenever an image is added, updated or removed.
    */
    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        bool isTracked = false;

        //foreach (ARTrackedImage trackedImage in args.added)
        //{
        //    //UpdateImage(trackedImage);
        //}

        foreach (ARTrackedImage trackedImage in args.updated)
        {
            // Check if one of the images is being tracked
            // Todo add time or something so the text does not disapear when a tag is not reconized for 1 frame
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                isTracked = true;
            }
            //_tagManager.CheckCurrentTag(trackedImage);
            UpdateImage(trackedImage);
        }

        //foreach (ARTrackedImage trackedImage in args.removed)
        //{
        //    //UpdateImage(trackedImage);
        //}

        /*
            Hide or show the story panel based on the image is detected or not.
            if isTracked == true show the story panel
            if isTracked == false hide the sotry panel 
        */
        _panel.ShowHidePanel(isTracked);

    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        string currentTrackedImageName = trackedImage.referenceImage.name;

        Vector3 trackedImagePosition = trackedImage.transform.position;

        TrackingState trackedImageState = trackedImage.trackingState;

        GameObject prefab = _spawnedPrefabs[currentTrackedImageName];
        prefab.transform.position = trackedImagePosition;

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
            if (_spawnedPrefabs[_previousTrackedImageName] != null)
            {
                _spawnedPrefabs[_previousTrackedImageName].SetActive(false);
            }

            /*
                When you scan a new tag, you want to show the new object instead of the old one. We do this by setting the SetActive of currentTrackedImageName to true.
            */
            if (_spawnedPrefabs[currentTrackedImageName] != null)
            {
                _spawnedPrefabs[currentTrackedImageName].SetActive(true);
            }

            /*
                When a new tag is scanned, we need to override the _previousTrackedImageName to the current tracking image name.
            */
            _previousTrackedImageName = currentTrackedImageName;
            return;
        }

        /*
            If _previousTrackedImageName is the same as currentTrackedImageName, this means that you are still scanning the current tag. So we need to return
        */
        if (trackedImageState == TrackingState.Tracking && _previousTrackedImageName == currentTrackedImageName)
        {
            _spawnedPrefabs[currentTrackedImageName].SetActive(true);
            _tagManager.CheckCurrentTag(trackedImage);
            return;
        }

        if (!_spawnedPrefabs[_previousTrackedImageName])
        {
            return;
        }

        _panel.ShowHidePanel(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TagManagerScript : MonoBehaviour
{
    [SerializeField]
    private ARTrackedImageManager _ARTrackedManager;
    [SerializeField]
    public ARTag[] _ARTags;
    [SerializeField]
    private Panel _panel;

    private int _currentTagID = 0;
    private string _frameChecker;

    [SerializeField]
    private string[] tagTexts;

    private void Awake()
    {
        tagTexts = new string[5]
        {
            "Don't wait for me in a borrowed home",
            "Zonder Titel",
            "Zuil",
            "Voortvarend",
            "Kempenaar Monument"
        };
        _panel = GameObject.Find("Scanner Canvas").GetComponent<Panel>();
        Debug.Log(_ARTrackedManager.referenceLibrary.count);
        _ARTags = new ARTag[_ARTrackedManager.referenceLibrary.count];
        for (int i = 0; i < _ARTrackedManager.referenceLibrary.count; i++)
        {
            var tag = _ARTags[i] = new ARTag(i, _ARTrackedManager.referenceLibrary[i].name);
        }
    }

    public void CheckCurrentTag(ARTrackedImage arTag)
    {
        if (_frameChecker != arTag.referenceImage.name)
        { 
            _frameChecker = arTag.referenceImage.name;
            Debug.Log("FrameChecker: " + _frameChecker);
            Debug.Log("ReferenceImageName: " + arTag.referenceImage.name);
            for (int i = 0; i < _ARTags.Length; i++)
            {
                if (arTag.referenceImage.name == _ARTags[i].tagName)
                {
                        _currentTagID++;
                        _panel.ChangePanelText(tagTexts[i]);
                }
            }
        }
    }
}
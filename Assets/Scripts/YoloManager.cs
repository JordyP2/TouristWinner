using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Sentis;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class YoloManager : MonoBehaviour
{
    public ModelAsset modelAsset;
    Model runtimeModel;

    Camera cameraScreenshot;
    public RawImage rawImage;
    AspectRatioFitter fitter;
    bool ratioSet;

    // Start is called before the first frame update
    void Start()
    {
        fitter = GetComponent<AspectRatioFitter>();
        runtimeModel = ModelLoader.Load(modelAsset);
        rawImage = GetComponent<RawImage>();

        List<Model.Input> inputs = runtimeModel.inputs;

        foreach (var input in inputs)
        {
            Debug.Log(input.name);
            Debug.Log(input.shape);
        }

        List<string> outputs = runtimeModel.outputs;

        foreach (var output in outputs)
        {
            Debug.Log(output);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TakeScreenshot();
    }

    private void TakeScreenshot()
    {

    }
}
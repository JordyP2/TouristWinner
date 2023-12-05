using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePropertiesDetection
{
    public const string TAG = "Image Properties Detection";

    public ImagePropertiesResponses[] responses;

    public class ImagePropertiesResponses
    {
        public ImagePropertiesAnnotation imagePropertiesAnnotation;
    }

    public class ImagePropertiesAnnotation
    {
        public DominantColors dominantColors;
    }

    public class DominantColors
    {
        public Colors[] colors;
    }

    public class Colors
    {
        public Color color;
        public float score;
        public float pixelFraction;
    }

    public class Color
    {
        public int red;
        public int green;
        public int blue;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CutoutUIMask : Image 
{ 
    public override Material materialForRendering
    {
        get
        {
            // idk just copyed it from the internet
            // If I remember correctly it inverts the cutout
            Material material = new Material(base.materialForRendering);
            material.SetInt("_StencilComp", (int)CompareFunction.NotEqual);
            return material;
        }
    }
}

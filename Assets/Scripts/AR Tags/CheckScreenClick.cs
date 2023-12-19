using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScreenClick : MonoBehaviour
{
    public bool IsClicked()
    {
        //Check if a mouse clicked
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }

        //Check if its the first touch on mobile
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            return true;
        }

        //If none of the above
        return false;
    }

}

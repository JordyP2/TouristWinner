using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public GameObject panel;
    public Text panelText;

    public AudioSource[] _audioSources;

    void Awake()
    {
        // hide panel
        panel.SetActive(false);
    }

    public void ShowHidePanel(bool isHidden)
    {
        // hide and show panel
        panel.SetActive(isHidden);
    }

    public void ChangePanelText(string text)
    {
        // change panel text
        panelText.text = text;
       
    }
}

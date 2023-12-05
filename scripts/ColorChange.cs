using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ColorChange : MonoBehaviour
{
    public Slider redSlider;
    public Slider greenSlider;
    public Slider blueSlider;
    public Material cubeMaterial;

    public Color targetColor = new Color(18f / 255f, 105f / 255f, 154f / 255f);
    public float colorgap = 5f ;
    

    private void Start()
    {
        cubeMaterial.color = new Color(1,1,1);
        redSlider.onValueChanged.AddListener(ChangeColor);
        greenSlider.onValueChanged.AddListener(ChangeColor);
        blueSlider.onValueChanged.AddListener(ChangeColor);
    }

    private void ChangeColor(float value)
    {
        float r = redSlider.value / 255f;
        float g = greenSlider.value / 255f;
        float b = blueSlider.value / 255f;

        cubeMaterial.color = new Color(r, g, b);
        //Debug.Log("  "+ redSlider.value+"  "+ greenSlider.value+"  "+ blueSlider.value);
        if (IsColorWithinThreshold(r, g, b))
        {
            Debug.Log("lol");
            

            LoadNewScene();
        }

    }
   
    private bool IsColorWithinThreshold(float r, float g, float b)
    {
        float colorThreshold = colorgap / 255f;
        float deltaR = Mathf.Abs(r - targetColor.r);
        float deltaG = Mathf.Abs(g - targetColor.g);
        float deltaB = Mathf.Abs(b - targetColor.b);

        return deltaR <= colorThreshold && deltaG <= colorThreshold && deltaB <= colorThreshold;
    }

    private void LoadNewScene()
    {
        // Load your new scene here, for example:
        SceneManager.LoadScene("Image-2",LoadSceneMode.Single);
        LoaderUtility.Deinitialize();
    }
}
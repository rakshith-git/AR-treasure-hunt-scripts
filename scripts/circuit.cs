using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using TMPro;
using UnityEngine.XR.ARFoundation;

public class circuit : MonoBehaviour
{
    public Slider inductanceSlider;
    public Slider resistanceSlider;
    public Slider capacitanceSlider;
    public GameObject prefab;
    private TextMeshPro inductanceText;
    private TextMeshPro resistanceText;
    private TextMeshPro capacitanceText;
    public Material materialToChange;

    private float angularFrequency = 2 * Mathf.PI * 50; // 50Hz in rad/s

    void Start()
    {
        inductanceSlider.onValueChanged.AddListener(OnValueChanged);
        resistanceSlider.onValueChanged.AddListener(OnValueChanged);
        capacitanceSlider.onValueChanged.AddListener(OnValueChanged);

        // Assuming the text objects are direct children of the prefab
        inductanceText = prefab.transform.Find("L").GetComponent<TextMeshPro>();
        resistanceText = prefab.transform.Find("R").GetComponent<TextMeshPro>();
        capacitanceText = prefab.transform.Find("C").GetComponent<TextMeshPro>();
    }
    private void Update()
    {

        // Update text elements
        //inductanceText.text = " = " + inductanceSlider.value.ToString();
       // resistanceText.text = " = " + resistanceSlider.value.ToString();
        //capacitanceText.text = " = " + capacitanceSlider.value.ToString();
    }
    void OnValueChanged(float value)
    {


        // Check resonance condition
        float resonanceFrequency = 1 / Mathf.Sqrt(inductanceSlider.value*1f * capacitanceSlider.value*0.0000001f);
        float difference = Mathf.Abs(angularFrequency - resonanceFrequency);
        //Debug.Log(difference);
        // If the difference is small enough, load the next scene
        if (difference <= 2 && resistanceSlider.value<=5) // Adjust this value as needed
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
            LoaderUtility.Deinitialize();
        }
        else
        {
            // Change the color of the material based on the difference
            float colorValue = 1 - ((difference/255f)+ resistanceSlider.value) ; // Adjust this calculation as needed
            materialToChange.color = new Color(colorValue, colorValue, colorValue);
        }
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 30;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI bottomText;
    public bool started=false;
    public string curtext = "";
    void Update()
    {
        
        if (timeRemaining > 0 && started==true)
        {
            
            bottomText.text = PlayerPrefs.GetString("yurNum");
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else if (timeRemaining <= 0 && started == true)
        {
            
            Debug.Log("Time has run out!");
            timeRemaining = 0;
            PlayerPrefs.SetString("yurNum", "type 0 on it");
            bottomText.text = PlayerPrefs.GetString("yurNum");
            int currentSceneName = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneName, LoadSceneMode.Single);
        }
        else
        {
            timeText.text = "count from 0 to 9 in the right order";

            bottomText.text= PlayerPrefs.GetString("yurNum", "type 0 on it");
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
   
    }
}

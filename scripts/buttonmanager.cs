using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonmanager : MonoBehaviour
{
    // Assume that the buttons are assigned in the order of a, b, c, d, e, f, g
    public ButtonController[] buttons;
    public Timer timer;
    public int curnum = 0;
    private AudioSource audioSource;
    public AudioClip[] audioClips;
    void Start()
    {
        // Assume that the game starts with the display showing 0
        //StartCountdown();
        PlayerPrefs.GetString("yurNum", "type 0 on it");
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = true;


    }
    private void Update()
    {
        for(int i=0; i <10;i++)
        {
            if (CheckNumber(i) == true)
            {
                if (i == curnum)
                {
                    if (curnum == 0)
                    {
                        timer.started = true;
                       
                    }
                    curnum++;
                    Debug.Log("ok");
                    PlayerPrefs.SetString("yurNum", "good now type "+curnum);
                    timer.bottomText.color = Color.green;
                    timer.bottomText.text = PlayerPrefs.GetString("yurNum");
                    PlayAudioClip(1);
                }
                else
                {
                    curnum = 0;
                    Debug.Log("lmao");
                    PlayerPrefs.SetString("yurNum","you typed: "+i+" restart with 0");
                    timer.bottomText.color = Color.red;
                    timer.bottomText.text = PlayerPrefs.GetString("yurNum");
                    PlayAudioClip(0);
                    int currentSceneName = SceneManager.GetActiveScene().buildIndex;
                    SceneManager.LoadScene(currentSceneName, LoadSceneMode.Single);
                }
                if (curnum >=10)
                {
                    Debug.Log("w");
                    int currentSceneName = SceneManager.GetActiveScene().buildIndex;
                    SceneManager.LoadScene(currentSceneName+1, LoadSceneMode.Single);
                }
                Debug.Log("curnum=" + i);
                ResetButtons();
            }
        }
    }


    void StartCountdown()
    {
        timer.started = true; // set the countdown time

    }

    void ResetButtons()
    {
        foreach (var button in buttons)
        {
            button.ResetColor();
        }
    }

    bool CheckNumber(int number)
    {
        switch (number)
        {
            case 0:
                return buttons[0].IsActivated() && buttons[1].IsActivated() && buttons[2].IsActivated() &&
                       buttons[3].IsActivated() && buttons[4].IsActivated() && buttons[5].IsActivated() &&
                       !buttons[6].IsActivated();
            case 1:
                return !buttons[0].IsActivated() && buttons[1].IsActivated() && buttons[2].IsActivated() &&
                       !buttons[3].IsActivated() && !buttons[4].IsActivated() && !buttons[5].IsActivated() &&
                       !buttons[6].IsActivated();
            case 2:
                return buttons[0].IsActivated() && buttons[1].IsActivated() && !buttons[2].IsActivated() &&
                       buttons[3].IsActivated() && buttons[4].IsActivated() && !buttons[5].IsActivated() &&
                       buttons[6].IsActivated();
            case 3:
                return buttons[0].IsActivated() && buttons[1].IsActivated() && buttons[2].IsActivated() &&
                       buttons[3].IsActivated() && !buttons[4].IsActivated() && !buttons[5].IsActivated() &&
                       buttons[6].IsActivated();
            case 4:
                return !buttons[0].IsActivated() && buttons[1].IsActivated() && buttons[2].IsActivated() &&
                       !buttons[3].IsActivated() && !buttons[4].IsActivated() && buttons[5].IsActivated() &&
                       buttons[6].IsActivated();
            case 5:
                return buttons[0].IsActivated() && !buttons[1].IsActivated() && buttons[2].IsActivated() &&
                       buttons[3].IsActivated() && !buttons[4].IsActivated() && buttons[5].IsActivated() &&
                       buttons[6].IsActivated();
            case 6:
                return buttons[0].IsActivated() && !buttons[1].IsActivated() && buttons[2].IsActivated() &&
                       buttons[3].IsActivated() && buttons[4].IsActivated() && buttons[5].IsActivated() &&
                       buttons[6].IsActivated();
            case 7:
                return buttons[0].IsActivated() && buttons[1].IsActivated() && buttons[2].IsActivated() &&
                       !buttons[3].IsActivated() && !buttons[4].IsActivated() && !buttons[5].IsActivated() &&
                       !buttons[6].IsActivated();
            case 8:
                return buttons[0].IsActivated() && buttons[1].IsActivated() && buttons[2].IsActivated() &&
                       buttons[3].IsActivated() && buttons[4].IsActivated() && buttons[5].IsActivated() &&
                       buttons[6].IsActivated();
            case 9:
                return buttons[0].IsActivated() && buttons[1].IsActivated() && buttons[2].IsActivated() &&
                       buttons[3].IsActivated() && !buttons[4].IsActivated() && buttons[5].IsActivated() &&
                       buttons[6].IsActivated();
            default:
                return false;
        }
    }
    public void PlayAudioClip(int clipIndex)
    {
        // Check if the index is valid
        if (clipIndex >= 0 && clipIndex < audioClips.Length)
        {
            // Assign the chosen audio clip to the AudioSource component
            
            audioSource.clip = audioClips[clipIndex];

            // Play the audio clip
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Invalid audio clip index.");
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class nextLoadar : MonoBehaviour
{
    
    public void Start()
    {
        // Use Invoke to load the next scene after 2 seconds.
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void LoadSceneAfterDelay()
    {
        // Load the next scene by name.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1,LoadSceneMode.Single);
        LoaderUtility.Initialize();

    }
}


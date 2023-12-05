using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class back : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Handle back button press on Android
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1, LoadSceneMode.Single);
            LoaderUtility.Deinitialize();
            // Add your custom logic here
        }
    }
}
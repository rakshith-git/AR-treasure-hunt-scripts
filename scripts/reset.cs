using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
public class reset : MonoBehaviour
{
    public ARSession arSession;
    
    private void Start()
    {
        
        
    }
    public void ResetScene()
    {
        // Get the name of the current scene and reload it.
       
       string currentSceneName = SceneManager.GetActiveScene().name;
       SceneManager.LoadScene(currentSceneName);
       // arSession.Reset();
    }
}
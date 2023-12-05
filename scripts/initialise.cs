using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class initialise : MonoBehaviour
{
    public ARSession arSession;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hii");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetScene()
    {
        // Get the name of the current scene and reload it.
        arSession.Reset();
        // string currentSceneName = SceneManager.GetActiveScene().name;
        // SceneManager.LoadScene(currentSceneName);
    }
}

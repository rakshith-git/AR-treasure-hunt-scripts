using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class SunGravity : MonoBehaviour
{
    public Transform sun;  // Reference to the sun GameObject
    public float gravitationalConstant = 10f;  // Adjust the gravitational force as needed

    private Rigidbody2D rb;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        rb = GetComponent<Rigidbody2D>();
        Application.targetFrameRate = 120;
    }

    private void Update()
    {
        if (sun != null)
        {
            Vector2 directionToSun = sun.position - transform.position;
            float distanceToSun = directionToSun.magnitude;
            if(distanceToSun < 2.5f || distanceToSun > 100f)
            {
                int currentSceneName = SceneManager.GetActiveScene().buildIndex;
                SceneManager.LoadScene(currentSceneName,LoadSceneMode.Single);
            }
            if (distanceToSun > 0f)
            {
                // Calculate the gravitational force using Newton's law of universal gravitation
                float gravitationalForce = gravitationalConstant * (rb.mass * sun.GetComponent<Rigidbody2D>().mass) / (distanceToSun * distanceToSun);

                // Apply the gravitational force to the spaceship
                Vector2 gravitationalAcceleration = directionToSun.normalized * gravitationalForce;
                rb.AddForce(gravitationalAcceleration);
            }
        }
    }
}

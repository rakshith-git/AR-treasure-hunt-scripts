using UnityEngine;
using UnityEngine.UI;

public class SineScale : MonoBehaviour
{
    public float scaleAmount = 0.5f; // Adjust this value to control the scale range
    public float speed = 2f; // Adjust this value to control the speed of the scaling

    private void Update()
    {
        float scaleFactor = 1f + Mathf.Sin(Time.time * speed) * scaleAmount;

        if (gameObject.GetComponent<RectTransform>() != null)
        {
            // For UI elements (RectTransform)
            RectTransform rectTransform = GetComponent<RectTransform>();
            rectTransform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);
        }
        else
        {
            // For regular GameObjects
            transform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button button;
    public Color defaultColor = Color.white;
    public Color clickedColor = Color.red;
    private bool isActive = false;
    void Start()
    {
        button.onClick.AddListener(ChangeColor);
    }

    void ChangeColor()
    {
        var colors = button.colors;
        colors.normalColor = clickedColor;
        button.colors = colors;
        isActive = true;
    }   

    public void ResetColor()
    {
        var colors = button.colors;
        colors.normalColor = defaultColor;
        button.colors = colors;
        isActive = false;
    }
    public bool IsActivated()
    {
        return isActive;
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class lapCount : MonoBehaviour
{
    public int s1=0, s2=0;
   
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("siiii");
        text.text ="Make 5 Orbits each \n" +s1.ToString()+" - "+s2.ToString();
        if (other.gameObject.tag == "ship1") // replace "Checkpoint" with the tag of your checkpoint GameObject
        {
            s1+=1;

        }
        else if(other.gameObject.tag == "ship2")
        {
            s2 += 1;
        }
        if (s1 >= 5 && s2 >=5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

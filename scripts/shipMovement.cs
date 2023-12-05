using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shipMovement : MonoBehaviour
{
    
    public Joystick joystick;
    public Rigidbody2D rb;
    public float speed;
    public ParticleSystem particle;
    private AudioSource audioSource;
    public AudioClip audioClips;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClips;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);
        
        if (moveDirection != Vector2.zero)
        {   if(!audioSource.isPlaying)
            audioSource.Play();
            particle.Emit(5);
            float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        rb.AddForce(moveDirection * speed);
        if (moveDirection == Vector2.zero)
            audioSource.Pause();


    }

}

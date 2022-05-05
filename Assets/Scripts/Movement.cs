using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float pushForce = 1;
    [SerializeField] float rotationForce = 1;
    audioPlayer audioPlayer;
    AudioSource AudioSource;
    bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioPlayer = FindObjectOfType<audioPlayer>();
        AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (isAlive)
        {
            push();
            rotate();
        }
        
    }
    private void push()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * pushForce * Time.deltaTime);
            if (!AudioSource.isPlaying)
            {
                audioPlayer.playSound(0);
            }
        }
        else
        {
            AudioSource.Stop();
        }
    }
    private void rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.freezeRotation = true;
            transform.Rotate(Vector3.forward  * rotationForce * Time.deltaTime);
            rb.freezeRotation = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.freezeRotation = true;
            transform.Rotate(Vector3.back * rotationForce * Time.deltaTime);
            rb.freezeRotation = false;
        }
    }
    public void dies()
    {
        isAlive = false;
    }
}

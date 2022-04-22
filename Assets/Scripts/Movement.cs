using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float pushForce = 1;
    [SerializeField] float rotationForce = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        push();
        rotate();
    }
    private void push()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * pushForce * Time.deltaTime);
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

}

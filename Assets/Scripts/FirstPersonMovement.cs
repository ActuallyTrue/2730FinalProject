using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    Rigidbody rigidbody;
    private float horizontalInput;
    private float forwardInput;
    void Start()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        if (Input.GetKeyDown(KeyCode.R)){
            SceneManager.LoadScene("AwakeNew");
        }
    }
}
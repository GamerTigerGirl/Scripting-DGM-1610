using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // movement speed in units per seconds
    public float moveSpeed;
    // force applied upwards
    public float jumpForce;

    // Mouse look sensitivity
    public float lookSensitivity;
    // lowest down we can look
    public float maxLookX;
    // highest up we can look
    public float minLookX;
    // Current x rotation of the camera
    private float rotX;
    private Camera camera;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        //Get Components
        camera = camera.main;
        rb = GetComponents<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector3(x, rb.velocity.y, z);
    }

    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;
    }
}

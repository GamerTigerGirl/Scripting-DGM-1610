using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 20.0f;
    public float turnSpeed = 50.0f;
    public float hInput;
    public float vInput;

    public float xRange = -14.09f;
    public float yRange = 5.00f;

    public GameObject projectile;
    public Transform launcher;
    public Vector3 offest = new Vector3(0,1,0);

    //public float health;

    // Update is called once per frame
    void Update()
    {

        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.back, turnSpeed * hInput * Time.deltaTime);
        transform.Translate(Vector3.up * speed * vInput * Time.deltaTime);
        // Created a wall on the -x side
        if(transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        // Created a wall on the x side
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3( xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.y > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.z);
        }
        if(transform.position.y < -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.z);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, launcher.transform.position, launcher.transform.rotation);
        }
    }
}
